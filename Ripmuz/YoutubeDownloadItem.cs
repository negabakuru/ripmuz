using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Threading;

using YoutubeDLSharp;
using YoutubeDLSharp.Metadata;
using YoutubeDLSharp.Options;

using Xabe.FFmpeg;
using Xabe.FFmpeg.Events;

namespace Ripmuz
{
	public partial class YoutubeDownloadItem : UserControl
	{
		public enum DlStatus
		{
			Idle,
			GettingInfos,
			Downloading,
			PostProcess,
			Done
		}


		//
		// VAR
		//
		public YoutubeDL YtDlp { get; }
		private readonly IProgress<DownloadProgress> _downloadProgress;
		private readonly IProgress<string> _downloadProgressOutput;
		private readonly CancellationTokenSource _downloadCancellationTokenSource;

		private readonly CancellationTokenSource _conversionCancellationTokenSource;

		public DlStatus Status = DlStatus.Idle;

		protected VideoData VideoData;
		protected string Url;
		protected string SafeFilenameNoExt;
		protected string OutputFilePath;
		protected string TempFilePath;
		protected float Duration;
		private string _tempFilePath;


		//
		// FUNC
		//
		public YoutubeDownloadItem(string itemUrl, IProgress<string> progressOutput)
		{
			YtDlp = new YoutubeDL
			{
				YoutubeDLPath = Form1.Settings.YtDlpPath,
				FFmpegPath = Form1.Settings.FfmpegPath,
				OutputFolder = Form1.Settings.DestinationFolder,
				OverwriteFiles = true
			};

			InitializeComponent();

			_downloadProgress = new Progress<DownloadProgress>(ShowDownloadProgress);
			_downloadCancellationTokenSource = new CancellationTokenSource();

			_conversionCancellationTokenSource = new CancellationTokenSource();

			Url = itemUrl;
			_downloadProgressOutput = progressOutput;
			urlLabel.Text = Url;

			GetVideoInfos();
		}

		protected async Task GetVideoInfos()
		{
			Status = DlStatus.GettingInfos;

			var res = await YtDlp.RunVideoDataFetch(Url);
			VideoData = res.Data;

			var thumbnails = res.Data.Thumbnails;
			// Avoid .webp images since they're not natively supported
			var thumbnailUrl = "";
			var maxHeight = 0;
			foreach (var thumbnail in thumbnails)
			{
				if (!thumbnail.Url.ToLower().Contains(".webp") && thumbnail.Height > maxHeight)
				{
					maxHeight = (int)thumbnail.Height;
					thumbnailUrl = thumbnail.Url;
					if (thumbnailUrl.IndexOf('?') > -1)
						thumbnailUrl = thumbnailUrl.Remove(thumbnailUrl.IndexOf('?'),
							(thumbnailUrl.Length - thumbnailUrl.IndexOf('?')));
				}
			}

			thumbnailPictureBox.LoadAsync(thumbnailUrl);

			var title = res.Data.Title;
			titleTextBox.Text = title;
			var artist = res.Data.Artist;
			artistTextBox.Text = artist;
			var album = res.Data.Album;
			albumTextBox.Text = album;

			SafeFilenameNoExt = title;
			foreach (var c in Path.GetInvalidFileNameChars())
				SafeFilenameNoExt = SafeFilenameNoExt.Replace(c, ' ');

			if (res.Data.Duration != null)
				Duration = (float)res.Data.Duration;
			var endTime = TimeSpan.FromSeconds(Duration);
			toTextBox.Text = endTime.ToString(@"hh\:mm\:ss");


			statusLabel.Text = "Ready";
			startButton.Visible = true;
		}

		private async void startButton_Click(object sender, EventArgs e)
		{
			switch (Status)
			{
				case DlStatus.Downloading:
					_downloadCancellationTokenSource.Cancel();
					Status = DlStatus.Idle;
					statusLabel.Text = "Ready";
					startButton.Text = "Download";
					break;
				case DlStatus.PostProcess:
					_conversionCancellationTokenSource.Cancel();
					Status = DlStatus.Idle;
					statusLabel.Text = "Ready";
					startButton.Text = "Download";
					break;
				case DlStatus.Idle:
				case DlStatus.GettingInfos:
				case DlStatus.Done:
				default:
					statusLabel.Text = "Dowloading...";
					startButton.Text = "Cancel";
					await DownloadMp3();
					break;
			}
		}

		protected async Task DownloadMp3()
		{
			Status = DlStatus.Downloading;

			var options = new OptionSet
			{
				AudioFormat = AudioConversionFormat.Best,
				AudioQuality = 0,
				EmbedThumbnail = true,
				Output = Form1.TempFolderPath + "%(title)s_temp.%(ext)s",
			};

			try
			{
				var res = await YtDlp.RunAudioDownload(Url, AudioConversionFormat.Best, _downloadCancellationTokenSource.Token, _downloadProgress,
					_downloadProgressOutput, options);
				_tempFilePath = res.Data;
				var safeFileName = SafeFilenameNoExt + Path.GetExtension(_tempFilePath);
				OutputFilePath = Path.Combine(Form1.Settings.DestinationFolder, safeFileName);
			}
			catch (Exception ex)
			{
				Status = DlStatus.Idle;
				statusLabel.Text = "Error: " + ex.Message;
				startButton.Text = "Try again";
			}

			await ApplyPostProcess();
		}

		protected async Task ApplyPostProcess()
		{
			Status = DlStatus.PostProcess;
			statusLabel.Text = "Trimming and adding metadata";

			var title = titleTextBox.Text;
			var artist = artistTextBox.Text;
			var album = albumTextBox.Text;
			title = title.Replace("\"", "\\\"");
			artist = artist.Replace("\"", "\\\"");
			album = album.Replace("\"", "\\\"");

			//var mediaInfo = await FFmpeg.GetMediaInfo(TempFilePath);

			var conversion = FFmpeg.Conversions.New();
			conversion.AddParameter($"-i {_tempFilePath}", ParameterPosition.PreInput);
			if (fromTextBox.Text != "00:00:00" || toTextBox.Text != TimeSpan.FromSeconds(Duration).ToString(@"hh\:mm\:ss"))
			{
				conversion.AddParameter($"-ss {fromTextBox.Text}", ParameterPosition.PostInput);
				conversion.AddParameter($"-to {toTextBox.Text}", ParameterPosition.PostInput);
			}
			conversion.AddParameter("-c:a copy", ParameterPosition.PostInput);
			conversion.AddParameter($"-metadata title=\"{title}\" ", ParameterPosition.PostInput);
			conversion.AddParameter($"-metadata artist=\"{artist}\" ", ParameterPosition.PostInput);
			conversion.AddParameter($"-metadata album=\"{album}\" ", ParameterPosition.PostInput);
			conversion.SetOverwriteOutput(true);
			conversion.SetOutput(OutputFilePath);
			Console.WriteLine(conversion.ToString());

			conversion.OnDataReceived += (sender, args) => { Console.WriteLine(args.Data); };
			conversion.OnProgress += (sender, args) =>
			{
				statusLabel.Invoke((ConversionProgressEventHandler)((s, a) => { statusLabel.Text = a.Percent.ToString();}), new []{ sender, args });
			};

			try
			{
				await conversion.Start(_conversionCancellationTokenSource.Token);
				Status = DlStatus.Done;
				statusLabel.Text = "Success";
				startButton.Visible = false;

				CleanUpFiles();
			}
			catch (Exception ex)
			{
				Status = DlStatus.Idle;
				statusLabel.Text = $"Error {ex.Message}";
				startButton.Text = "Try again";
			}
		}

		private void ShowDownloadProgress(DownloadProgress p)
		{
			// Display download progress percentage
			var progress = (p.Progress * 100.0f).ToString(CultureInfo.InvariantCulture);
			statusLabel.Text = progress;
		}

		protected void CleanUpFiles()
		{
			if (File.Exists(_tempFilePath))
				File.Delete(_tempFilePath);
		}

	}
}