using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace Ripmuz
{

	public partial class Form1 : Form
	{
		public class SettingsObject
		{
			public string DestinationFolder { get; set; }
		}

		// VAR
		static public string tempFolderPath { get; protected set; }
		static protected string settingsFilePath = "RipmuzSettings.json";
		static public SettingsObject settings { get; set; }

		public Process youtubedl = new Process();


		// FUNC

		// TODO: Maybe use https://github.com/SnGmng/YoutubeDL-NET for youtube-dl
		//		 and a nuget ffmpeg package too
		public Form1()
		{
			InitializeComponent();

			tempFolderPath = Path.Combine(Path.GetTempPath(), @"Ripmuz\");
            settingsFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Ripmuz\RipmuzSettings.json");
            LoadSettingsFromFile();

			if (settings.DestinationFolder == "" || settings.DestinationFolder == null || !Directory.Exists(settings.DestinationFolder))
				settings.DestinationFolder = Directory.GetCurrentDirectory();
			destFolderLabel.Text = "Dest folder: " + settings.DestinationFolder;

			SaveSettingsToFile();

			youtubedl.StartInfo.FileName = "./ThirdPartyBin/youtube-dl.exe";
			youtubedl.StartInfo.UseShellExecute = false;
			youtubedl.StartInfo.CreateNoWindow = true;
			youtubedl.StartInfo.RedirectStandardInput = true;
			youtubedl.StartInfo.RedirectStandardOutput = true;
			youtubedl.StartInfo.RedirectStandardError = true;
			youtubedl.EnableRaisingEvents = true;

			youtubedl.OutputDataReceived += new DataReceivedEventHandler(OnYoutubeDLOutput);
			youtubedl.Exited += new EventHandler(OnYoutubeDLExit);

			UpdateYoutubeDL();
		}

        public bool LoadSettingsFromFile()
        {
			// read JSON directly from a file
			if (File.Exists(settingsFilePath))
            {
                var serializer = new JsonSerializer();
                using (StreamReader file = File.OpenText(settingsFilePath))
                {
                    settings = (SettingsObject)serializer.Deserialize(file, typeof(SettingsObject));
                }

				if (settings == null) // ensure we have usable settings at least
					settings = new SettingsObject();

                return true;
            }

			// ensure we have usable settings at least
			settings = new SettingsObject();
            return false;
        }

        public bool SaveSettingsToFile()
        {
			if (Path.GetDirectoryName(settingsFilePath).Length > 0)
				Directory.CreateDirectory(Path.GetDirectoryName(settingsFilePath));

            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(settingsFilePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, settings);
            }

            return true;
        }

        private void urlTextBox_TextChanged(object sender, EventArgs e)
		{
			if (urlTextBox.Text.Contains("youtu.be") || urlTextBox.Text.Contains("youtube.com"))
			{
				YoutubeDownloadItem newDownload = new YoutubeDownloadItem(urlTextBox.Text);

				newDownload.youtubedl.OutputDataReceived += new DataReceivedEventHandler(OnYoutubeDLOutput);
				newDownload.youtubedl.ErrorDataReceived += new DataReceivedEventHandler(OnYoutubeDLOutput);
				newDownload.ffmpeg.OutputDataReceived += new DataReceivedEventHandler(OnFfmpegOutput);
				newDownload.ffmpeg.ErrorDataReceived += new DataReceivedEventHandler(OnFfmpegOutput);

				youtubeDownloadPanel.Controls.Add(newDownload);

				urlTextBox.Clear();
			}
		}

		public void UpdateYoutubeDL()
		{
			youtubedl.StartInfo.Arguments = "-U";

			youtubedl.Start();
			youtubedl.BeginOutputReadLine();
			youtubedl.BeginErrorReadLine();
		}

		public void OnYoutubeDLExit(object sender, EventArgs e)
		{
			if (destFolderLabel.InvokeRequired)
				destFolderLabel.Invoke(new EventHandler(OnYoutubeDLExit), new object[] { sender, e });
			else
			{
				if (youtubedl.ExitCode == 0)
				{
				}
				else
				{
				}

				try
                {
					youtubedl.CancelOutputRead();
					youtubedl.CancelErrorRead();
                }
				catch (System.InvalidOperationException)
                {
                    richTextBox1.AppendText("\nFailed cancelling youtube-dl Output/Error read.");
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    richTextBox1.ScrollToCaret();
                }
                youtubedl.Close();
			}
		}

		public void OnYoutubeDLOutput(object sender, DataReceivedEventArgs e)
		{

            if (e.Data != null && e.Data.Length > 0 && e.Data.Contains("Waiting for file handle to be closed")) // Need to close youtube-dl
            {
				youtubedl.StandardInput.WriteLine();
				youtubedl.StandardInput.Flush();

                Thread.Sleep(4000);

                //youtubedl.CancelOutputRead();
                //youtubedl.CancelErrorRead();
                youtubedl.Close();

                //// is this enough ?

                youtubedl.Start();
                //youtubedl.BeginOutputReadLine();
                //youtubedl.BeginErrorReadLine();
            }

            if (richTextBox1.InvokeRequired)
			{
				DataReceivedEventHandler d = new DataReceivedEventHandler(OnYoutubeDLOutput);
				richTextBox1.Invoke(d, new object[] { sender, e });
			}
			else if (e.Data != null && e.Data.Length > 0)
			{
				richTextBox1.AppendText("\nyoutube-dl: " + e.Data);
				richTextBox1.SelectionStart = richTextBox1.Text.Length;
				richTextBox1.ScrollToCaret();
			}
		}

		public void OnFfmpegOutput(object sender, DataReceivedEventArgs e)
		{
			if (richTextBox1.InvokeRequired)
			{
				DataReceivedEventHandler d = new DataReceivedEventHandler(OnFfmpegOutput);
				richTextBox1.Invoke(d, new object[] { sender, e });
			}
			else if (e.Data != null && e.Data.Length > 0)
			{
				richTextBox1.AppendText("\nffmpeg: " + e.Data);
				richTextBox1.SelectionStart = richTextBox1.Text.Length;
				richTextBox1.ScrollToCaret();
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

		private void chooseDestFolderButton_Click(object sender, EventArgs e)
		{
			destFolderBrowserDialog.ShowDialog();
			Form1.settings.DestinationFolder = destFolderBrowserDialog.SelectedPath;
			destFolderLabel.Text = "Dest folder: " + Form1.settings.DestinationFolder;

			SaveSettingsToFile();
		}
	}
}
