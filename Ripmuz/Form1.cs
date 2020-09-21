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

namespace Ripmuz
{
	public partial class Form1 : Form
	{
		// VAR

		static public string destFolder;

		public Process youtubedl = new Process();


		// FUNC

		public Form1()
		{
			InitializeComponent();

			destFolder = Directory.GetCurrentDirectory();
			destFolderLabel.Text = "Dest folder: " + destFolder;

			youtubedl.StartInfo.FileName = "./ThirdPartyBin/youtube-dl.exe";
			youtubedl.StartInfo.UseShellExecute = false;
			youtubedl.StartInfo.CreateNoWindow = true;
			youtubedl.StartInfo.RedirectStandardOutput = true;
			youtubedl.StartInfo.RedirectStandardError = true;
			youtubedl.EnableRaisingEvents = true;

			youtubedl.OutputDataReceived += new DataReceivedEventHandler(OnYoutubeDLOutput);
			youtubedl.Exited += new EventHandler(OnYoutubeDLExit);

			UpdateYoutubeDL();
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

				youtubedl.CancelOutputRead();
				youtubedl.CancelErrorRead();
				youtubedl.Close();
			}
		}

		public void OnYoutubeDLOutput(object sender, DataReceivedEventArgs e)
		{
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
			destFolder = destFolderBrowserDialog.SelectedPath;
			destFolderLabel.Text = "Dest folder: " + destFolder;
		}
	}
}
