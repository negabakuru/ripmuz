using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace Ripmuz
{
	public partial class YoutubeDownloadItem : UserControl
	{
		public enum DLStatus
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


		public Process youtubedl = new Process();
		public Process ffmpeg = new Process();

		public DLStatus status = DLStatus.Idle;

		protected JObject infosJSONObject;
		protected string url;
		protected string filename;
		protected string outputFilePath;
		protected string tempFileName;
		protected string tempFilePath;
		protected int duration;



		//
		// FUNC
		//


		public YoutubeDownloadItem()
		{
			InitializeComponent();
		}

		public YoutubeDownloadItem(string itemUrl, RichTextBox outputTextBox = null)
		{
			InitializeComponent();

			ffmpeg.StartInfo.FileName = "./ThirdPartyBin/ffmpeg.exe";
			ffmpeg.StartInfo.UseShellExecute = false;
			ffmpeg.StartInfo.CreateNoWindow = true;
			ffmpeg.StartInfo.RedirectStandardOutput = true;
			ffmpeg.StartInfo.RedirectStandardError = true;
			ffmpeg.EnableRaisingEvents = true;

			ffmpeg.OutputDataReceived += new DataReceivedEventHandler(OnFfmpegOutput);
			ffmpeg.Exited += new EventHandler(OnFfmpegExit);

			url = itemUrl;
			urlLabel.Text = url;

			youtubedl.StartInfo.FileName = "./ThirdPartyBin/youtube-dl.exe";
			youtubedl.StartInfo.UseShellExecute = false;
			youtubedl.StartInfo.CreateNoWindow = true;
			youtubedl.StartInfo.RedirectStandardOutput = true;
			youtubedl.StartInfo.RedirectStandardError = true;
			youtubedl.EnableRaisingEvents = true;

			youtubedl.OutputDataReceived += new DataReceivedEventHandler(OnYoutubeDLOutput);
			youtubedl.Exited += new EventHandler(OnYoutubeDLExit);

			GetVideoInfos();
		}

		~YoutubeDownloadItem()
		{
			youtubedl.Close();
			ffmpeg.Close();
		}

		protected void CleanUpFiles()
		{
			if (File.Exists(tempFilePath))
				File.Delete(tempFilePath);

            //if (Form1.settings.DestinationFolder != Directory.GetCurrentDirectory() && File.Exists(filename))
			// Move output from temp folder to destination folder
            if (File.Exists(Path.Combine(Form1.tempFolderPath, filename)))
				File.Move(Path.Combine(Form1.tempFolderPath, filename), Path.Combine(Form1.settings.DestinationFolder, filename));
		}

		// FFMPEG

		protected void ApplyPostProcess()
		{
			status = DLStatus.PostProcess;
			string title = titleTextBox.Text;
			string artist = artistTextBox.Text;
			title = title.Replace("\"", "\\\"");
			artist = artist.Replace("\"", "\\\"");

			// sample: "-i \"test.mp3\" -y -c:a copy -ss 00:00:00 -to 00:01:00 -metadata title=\"To Be Heroine OP\" -metadata artist=\"Dunno\" \"ok.mp3\""
			if (fromTextBox.Text != "00:00:00" || toTextBox.Text != TimeSpan.FromSeconds(duration).ToString(@"hh\:mm\:ss"))
			{
				ffmpeg.StartInfo.Arguments = "-i \"" + tempFilePath + "\" -y -c:a copy ";
				ffmpeg.StartInfo.Arguments += "-ss " + fromTextBox.Text + " -to " + toTextBox.Text + " ";
				ffmpeg.StartInfo.Arguments += "-metadata title=\"" + title + "\" ";
				ffmpeg.StartInfo.Arguments += "-metadata artist=\"" + artist + "\" ";
				ffmpeg.StartInfo.Arguments += "\"" + outputFilePath + "\"";
				Console.WriteLine("time " + ffmpeg.StartInfo.Arguments);
			}
			else
			{
				ffmpeg.StartInfo.Arguments = "-i \"" + tempFilePath + "\" -y -c:a copy ";
				ffmpeg.StartInfo.Arguments += "-metadata title=\"" + title + "\" ";
				ffmpeg.StartInfo.Arguments += "-metadata artist=\"" + artist + "\" ";
				ffmpeg.StartInfo.Arguments += "\"" + outputFilePath + "\"";
				Console.WriteLine("norm " + ffmpeg.StartInfo.Arguments);
			}

			ffmpeg.Start();
			ffmpeg.BeginOutputReadLine();
			ffmpeg.BeginErrorReadLine();
		}

		protected void OnFfmpegOutput(object sender, DataReceivedEventArgs e)
		{

		}

		protected void OnFfmpegExit(object sender, EventArgs e)
		{
			if (statusLabel.InvokeRequired)
				statusLabel.Invoke(new EventHandler(OnFfmpegExit), new object[] { sender, e });
			else if (status == DLStatus.PostProcess)
			{
				if (ffmpeg.ExitCode == 0)
				{
					statusLabel.Text = "Success";
					status = DLStatus.Done;
					startButton.Visible = false;
					CleanUpFiles();
				}
				else
				{
					status = DLStatus.Idle;
					statusLabel.Text = "Error " + ffmpeg.ExitCode.ToString();
					startButton.Text = "Try again";
				}

				ffmpeg.CancelOutputRead();
				ffmpeg.CancelErrorRead();
				ffmpeg.Close();
			}
		}

			// FFMPEG


			protected void GetVideoInfos()
		{
			status = DLStatus.GettingInfos;

			youtubedl.StartInfo.Arguments = "--print-json --skip-download -o \"%(title)s_temp.%(ext)s\" \"" + this.url + "\"";

			youtubedl.Start();
			youtubedl.BeginOutputReadLine();
			youtubedl.BeginErrorReadLine();
		}

		protected void DownloadMp3()
		{
			status = DLStatus.Downloading;

			youtubedl.StartInfo.Arguments = "--newline -f bestaudio -x --audio-format mp3 --audio-quality 0 --embed-thumbnail -o \"" + Form1.tempFolderPath + "%(title)s_temp.%(ext)s\" \"" + this.url + "\"";

			youtubedl.Start();
			youtubedl.BeginOutputReadLine();
			youtubedl.BeginErrorReadLine();
		}

		protected void FillInfosFromJson()
		{
			// winforms don't seem to be able to display .webp images :/
			var thumbnails = (JArray)infosJSONObject.GetValue("thumbnails");
			// Avoid .webp images since they're not natively supported
			string thumbnailURL = "";
			int maxHeight = 0;
			for (int i = 0; i < thumbnails.Count; ++i)
			{
				var curThumb = (JObject)thumbnails[i];
				if (curThumb.GetValue("url").ToString().ToLower().Contains(".webp") == false &&
					((JValue)curThumb.GetValue("height")).Value<int>() > maxHeight)
				{
					maxHeight = ((JValue)curThumb.GetValue("height")).Value<int>();
					thumbnailURL = ((JValue)curThumb.GetValue("url")).Value<string>();
					if (thumbnailURL.IndexOf('?') > -1)
						thumbnailURL = thumbnailURL.Remove(thumbnailURL.IndexOf('?'), (thumbnailURL.Length - thumbnailURL.IndexOf('?')));
				}
			}

			//thumbnailPictureBox.ImageLocation = thumbnailURL;
			thumbnailPictureBox.LoadAsync(thumbnailURL);

            tempFileName = ((JValue)infosJSONObject.GetValue("_filename")).Value<string>();
			tempFileName = tempFileName.Substring(0, tempFileName.LastIndexOf('.') + 1) + "mp3";
			foreach (char c in System.IO.Path.GetInvalidFileNameChars())
				tempFileName = tempFileName.Replace(c, ' ');
			tempFilePath = Path.Combine(Form1.tempFolderPath, tempFileName);

			string title = ((JValue)infosJSONObject.GetValue("title")).Value<string>();
			filename = title + ".mp3";
			foreach (char c in System.IO.Path.GetInvalidFileNameChars())
				filename = filename.Replace(c, ' ');
			outputFilePath = Path.Combine(Form1.tempFolderPath, filename);
			titleTextBox.Text = title;

			var artist = (JValue)infosJSONObject.GetValue("artist");
			artistTextBox.Text = artist != null ? artist.Value<string>() : "";

			duration = ((JValue)infosJSONObject.GetValue("duration")).Value<int>();
			TimeSpan endTime = TimeSpan.FromSeconds(duration);
			toTextBox.Text = endTime.ToString(@"hh\:mm\:ss");
		}

		public void OnYoutubeDLExit(object sender, EventArgs e)
		{
			if (statusLabel.InvokeRequired)
				statusLabel.Invoke(new EventHandler(OnYoutubeDLExit), new object[] { sender, e });
			else if (status == DLStatus.GettingInfos)
			{
				//// ready to download
				//statusLabel.Text = "Ready";
				//startButton.Visible = true;
				//FillInfosFromJson();

				youtubedl.CancelOutputRead();
				youtubedl.CancelErrorRead();
				youtubedl.Close();
			}
			else if (status == DLStatus.Downloading)
			{
				if (youtubedl.ExitCode == 0)
				{
					statusLabel.Text = "Trimming and adding metadata";
					ApplyPostProcess();
				}
				else
				{
					status = DLStatus.Idle;
					statusLabel.Text = "Exited " + youtubedl.ExitCode.ToString();
					startButton.Text = "Try again";
				}

				youtubedl.CancelOutputRead();
				youtubedl.CancelErrorRead();
				youtubedl.Close();
			}
		}

		public void OnYoutubeDLOutput(object sender, DataReceivedEventArgs e)
		{
			if (InvokeRequired)
				Invoke(new DataReceivedEventHandler(OnYoutubeDLOutput), new object[] { sender, e });
			else if (status == DLStatus.GettingInfos && !string.IsNullOrEmpty(e.Data))
			{
				infosJSONObject = JObject.Parse(e.Data);

                // ready to download
                FillInfosFromJson();
                statusLabel.Text = "Ready";
                startButton.Visible = true;
            }
            else if (status == DLStatus.Downloading && !string.IsNullOrEmpty(e.Data))
			{
				if (e.Data.Contains("[download] "))
				{
					// Display download progress percentage
					string progress = e.Data.Split(new char[] { ' ' })[1];
					statusLabel.Text = progress == "100%" ? "Converting..." : progress;
				}
			}
		}

		private void startButton_Click(object sender, EventArgs e)
		{
			if (status == DLStatus.Downloading)
			{
				youtubedl.Kill();
				status = DLStatus.Idle;
				statusLabel.Text = "Ready";
				startButton.Text = "Download";
			}
			else if (status == DLStatus.PostProcess)
			{
				youtubedl.Kill();
				status = DLStatus.Idle;
				statusLabel.Text = "Ready";
				startButton.Text = "Download";
			}
			else
			{
				DownloadMp3();
				statusLabel.Text = "Dowloading...";
				startButton.Text = "Cancel";
			}
		}
	}
}
