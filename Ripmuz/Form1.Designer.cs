namespace Ripmuz
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.urlTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.urlTextBox = new System.Windows.Forms.TextBox();
			this.urlLabel = new System.Windows.Forms.Label();
			this.destFolderLabel = new System.Windows.Forms.Label();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.youtubeDownloadPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.outputFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ytdlpFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ffmpegFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autoUpdateYtdlpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.destFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.tableLayoutPanel1.SuspendLayout();
			this.urlTableLayoutPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.72012F));
			this.tableLayoutPanel1.Controls.Add(this.urlTableLayoutPanel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.593407F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 430F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
			this.tableLayoutPanel1.TabIndex = 2;
			this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
			// 
			// urlTableLayoutPanel
			// 
			this.urlTableLayoutPanel.ColumnCount = 4;
			this.urlTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.52553F));
			this.urlTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.47447F));
			this.urlTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 365F));
			this.urlTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
			this.urlTableLayoutPanel.Controls.Add(this.urlTextBox, 1, 0);
			this.urlTableLayoutPanel.Controls.Add(this.urlLabel, 0, 0);
			this.urlTableLayoutPanel.Controls.Add(this.destFolderLabel, 2, 0);
			this.urlTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.urlTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.urlTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
			this.urlTableLayoutPanel.Name = "urlTableLayoutPanel";
			this.urlTableLayoutPanel.RowCount = 1;
			this.urlTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.urlTableLayoutPanel.Size = new System.Drawing.Size(800, 20);
			this.urlTableLayoutPanel.TabIndex = 3;
			this.urlTableLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
			// 
			// urlTextBox
			// 
			this.urlTextBox.AllowDrop = true;
			this.urlTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.urlTextBox.Location = new System.Drawing.Point(83, 0);
			this.urlTextBox.Margin = new System.Windows.Forms.Padding(0);
			this.urlTextBox.Name = "urlTextBox";
			this.urlTextBox.Size = new System.Drawing.Size(245, 20);
			this.urlTextBox.TabIndex = 4;
			this.urlTextBox.TextChanged += new System.EventHandler(this.urlTextBox_TextChanged);
			// 
			// urlLabel
			// 
			this.urlLabel.AutoSize = true;
			this.urlLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.urlLabel.Location = new System.Drawing.Point(3, 0);
			this.urlLabel.Name = "urlLabel";
			this.urlLabel.Size = new System.Drawing.Size(77, 20);
			this.urlLabel.TabIndex = 5;
			this.urlLabel.Text = "Enter URL";
			this.urlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// destFolderLabel
			// 
			this.destFolderLabel.AutoSize = true;
			this.destFolderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.destFolderLabel.Location = new System.Drawing.Point(331, 0);
			this.destFolderLabel.Name = "destFolderLabel";
			this.destFolderLabel.Size = new System.Drawing.Size(359, 20);
			this.destFolderLabel.TabIndex = 7;
			this.destFolderLabel.Text = "Dest Folder:";
			this.destFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 20);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.AutoScroll = true;
			this.splitContainer1.Panel1.Controls.Add(this.youtubeDownloadPanel);
			this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
			this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
			this.splitContainer1.Size = new System.Drawing.Size(800, 430);
			this.splitContainer1.SplitterDistance = 300;
			this.splitContainer1.SplitterWidth = 5;
			this.splitContainer1.TabIndex = 5;
			// 
			// youtubeDownloadPanel
			// 
			this.youtubeDownloadPanel.AutoScroll = true;
			this.youtubeDownloadPanel.AutoSize = true;
			this.youtubeDownloadPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.youtubeDownloadPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.youtubeDownloadPanel.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
			this.youtubeDownloadPanel.Location = new System.Drawing.Point(0, 24);
			this.youtubeDownloadPanel.Margin = new System.Windows.Forms.Padding(0);
			this.youtubeDownloadPanel.Name = "youtubeDownloadPanel";
			this.youtubeDownloadPanel.Size = new System.Drawing.Size(800, 0);
			this.youtubeDownloadPanel.TabIndex = 5;
			this.youtubeDownloadPanel.WrapContents = false;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 6;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.outputFolderToolStripMenuItem,
            this.ytdlpFolderToolStripMenuItem,
            this.ffmpegFolderToolStripMenuItem,
            this.autoUpdateYtdlpToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.settingsToolStripMenuItem.Text = "Settings";
			// 
			// outputFolderToolStripMenuItem
			// 
			this.outputFolderToolStripMenuItem.Name = "outputFolderToolStripMenuItem";
			this.outputFolderToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.outputFolderToolStripMenuItem.Text = "Output Folder";
			this.outputFolderToolStripMenuItem.Click += new System.EventHandler(this.outputFolderToolStripMenuItem_Click);
			// 
			// ytdlpFolderToolStripMenuItem
			// 
			this.ytdlpFolderToolStripMenuItem.Name = "ytdlpFolderToolStripMenuItem";
			this.ytdlpFolderToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.ytdlpFolderToolStripMenuItem.Text = "yt-dlp Folder";
			this.ytdlpFolderToolStripMenuItem.Click += new System.EventHandler(this.ytdlpFolderToolStripMenuItem_Click);
			// 
			// ffmpegFolderToolStripMenuItem
			// 
			this.ffmpegFolderToolStripMenuItem.Name = "ffmpegFolderToolStripMenuItem";
			this.ffmpegFolderToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.ffmpegFolderToolStripMenuItem.Text = "ffmpeg Folder";
			this.ffmpegFolderToolStripMenuItem.Click += new System.EventHandler(this.ffmpegFolderToolStripMenuItem_Click);
			// 
			// autoUpdateYtdlpToolStripMenuItem
			// 
			this.autoUpdateYtdlpToolStripMenuItem.Checked = true;
			this.autoUpdateYtdlpToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.autoUpdateYtdlpToolStripMenuItem.Name = "autoUpdateYtdlpToolStripMenuItem";
			this.autoUpdateYtdlpToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.autoUpdateYtdlpToolStripMenuItem.Text = "Auto update yt-dlp";
			// 
			// richTextBox1
			// 
			this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBox1.Location = new System.Drawing.Point(0, 0);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.richTextBox1.Size = new System.Drawing.Size(800, 125);
			this.richTextBox1.TabIndex = 3;
			this.richTextBox1.Text = "";
			// 
			// destFolderBrowserDialog
			// 
			this.destFolderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
			this.destFolderBrowserDialog.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Ripmuz";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.urlTableLayoutPanel.ResumeLayout(false);
			this.urlTableLayoutPanel.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel urlTableLayoutPanel;
		private System.Windows.Forms.TextBox urlTextBox;
		private System.Windows.Forms.Label urlLabel;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.FlowLayoutPanel youtubeDownloadPanel;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.FolderBrowserDialog destFolderBrowserDialog;
		private System.Windows.Forms.Label destFolderLabel;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem outputFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ytdlpFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ffmpegFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem autoUpdateYtdlpToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
	}
}

