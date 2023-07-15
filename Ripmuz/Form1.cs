using System;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

using Newtonsoft.Json;
using YoutubeDLSharp;
using Xabe.FFmpeg;

namespace Ripmuz
{
	public partial class Form1 : Form
	{
		public class SettingsObject
		{
			public string DestinationFolder { get; set; }
			public string YtDlpPath { get; set; }
			public string FfmpegPath { get; set; }
		}

		public bool Started { get; set; }

		public static string TempFolderPath { get; protected set; }
		protected static string SettingsFilePath = "RipmuzSettings.json";
		public static SettingsObject Settings { get; set; }

		public YoutubeDL YtDlp = new YoutubeDL();

		public Form1()
		{
			Started = false;
			InitializeComponent();

			TempFolderPath = Path.Combine(Path.GetTempPath(), @"Ripmuz\");
			SettingsFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
				@"Ripmuz\RipmuzSettings.json");
			LoadSettingsFromFile();

			if (string.IsNullOrEmpty(Settings.DestinationFolder) || !Directory.Exists(Settings.DestinationFolder))
				Settings.DestinationFolder = Directory.GetCurrentDirectory();
			destFolderLabel.Text = $"Dest folder: {Settings.DestinationFolder}";

			SaveSettingsToFile();

			YtDlp.YoutubeDLPath = Settings.YtDlpPath;
			YtDlp.FFmpegPath = Settings.FfmpegPath;
			YtDlp.OutputFolder = Settings.DestinationFolder;
			YtDlp.OverwriteFiles = true;

			FFmpeg.SetExecutablesPath(Form1.Settings.FfmpegPath);

			Start();
		}

		public bool LoadSettingsFromFile()
		{
			// read JSON directly from a file
			if (File.Exists(SettingsFilePath))
			{
				var serializer = new JsonSerializer();
				using (StreamReader file = File.OpenText(SettingsFilePath))
				{
					Settings = (SettingsObject)serializer.Deserialize(file, typeof(SettingsObject));
				}

				if (Settings == null) // ensure we have usable settings at least
					Settings = new SettingsObject();

				return true;
			}

			// ensure we have usable settings at least
			Settings = new SettingsObject();
			return false;
		}

		public bool SaveSettingsToFile()
		{
			if (Path.GetDirectoryName(SettingsFilePath).Length > 0)
				Directory.CreateDirectory(Path.GetDirectoryName(SettingsFilePath));

			// serialize JSON directly to a file
			using (StreamWriter file = File.CreateText(SettingsFilePath))
			{
				JsonSerializer serializer = new JsonSerializer();
				serializer.Serialize(file, Settings);
			}

			FFmpeg.SetExecutablesPath(Form1.Settings.FfmpegPath);

			return true;
		}

		private async void Start()
		{
			await UpdateBinaries();

			Started = true;
		}

		public async Task UpdateBinaries()
		{
			await YtDlp.RunUpdate();

			//var ffmpegProgress = new Progress<ProgressInfo>();
			//ffmpegProgress.ProgressChanged += (sender, info) =>
			//{
			// Console.WriteLine($"ffmpeg download: {info.DownloadedBytes}/{info.TotalBytes}");
			//};
			//await FFmpegDownloader.GetLatestVersion(FFmpegVersion.Official, Settings.FfmpegPath, ffmpegProgress);
		}


		private void urlTextBox_TextChanged(object sender, EventArgs e)
		{
			if (urlTextBox.Text.Contains("youtu.be") || urlTextBox.Text.Contains("youtube.com"))
			{
				var itemProgress = new Progress<string>();
				itemProgress.ProgressChanged += (o, s) => { Console.WriteLine(s); };
				var newDownload = new YoutubeDownloadItem(urlTextBox.Text, itemProgress);
				youtubeDownloadPanel.Controls.Add(newDownload);

				urlTextBox.Clear();
			}
		}

		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
		{
		}

		private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
		{
		}

		private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void outputFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			destFolderBrowserDialog.ShowDialog();
			Form1.Settings.DestinationFolder = destFolderBrowserDialog.SelectedPath;
			destFolderLabel.Text = $"Dest folder: {Form1.Settings.DestinationFolder}";

			SaveSettingsToFile();
		}

		private void ytdlpFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var dialogResult = openFileDialog1.ShowDialog();
			if (dialogResult != DialogResult.OK) return;

			Settings.YtDlpPath = openFileDialog1.FileName;
			SaveSettingsToFile();
		}

		private void ffmpegFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var dialogResult = openFileDialog1.ShowDialog();
			if (dialogResult != DialogResult.OK) return;

			Settings.FfmpegPath = Path.GetDirectoryName(openFileDialog1.FileName);
			SaveSettingsToFile();
		}
	}
}