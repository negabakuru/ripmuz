namespace Ripmuz
{
	partial class YoutubeDownloadItem
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.startButton = new System.Windows.Forms.Button();
            this.thumbnailPictureBox = new System.Windows.Forms.PictureBox();
            this.infosPanel = new System.Windows.Forms.TableLayoutPanel();
            this.urlLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.fromToPanel = new System.Windows.Forms.TableLayoutPanel();
            this.fromLabel = new System.Windows.Forms.Label();
            this.toLabel = new System.Windows.Forms.Label();
            this.fromTextBox = new System.Windows.Forms.RichTextBox();
            this.toTextBox = new System.Windows.Forms.RichTextBox();
            this.metadataPanel = new System.Windows.Forms.TableLayoutPanel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.artistLabel = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.artistTextBox = new System.Windows.Forms.TextBox();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailPictureBox)).BeginInit();
            this.infosPanel.SuspendLayout();
            this.fromToPanel.SuspendLayout();
            this.metadataPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.ColumnCount = 3;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 199F));
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 457F));
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainPanel.Controls.Add(this.startButton, 2, 0);
            this.mainPanel.Controls.Add(this.thumbnailPictureBox, 0, 0);
            this.mainPanel.Controls.Add(this.infosPanel, 1, 0);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RowCount = 1;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainPanel.Size = new System.Drawing.Size(780, 154);
            this.mainPanel.TabIndex = 0;
            // 
            // startButton
            // 
            this.startButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.startButton.Location = new System.Drawing.Point(680, 65);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Download";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Visible = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // thumbnailPictureBox
            // 
            this.thumbnailPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thumbnailPictureBox.Location = new System.Drawing.Point(3, 3);
            this.thumbnailPictureBox.Name = "thumbnailPictureBox";
            this.thumbnailPictureBox.Size = new System.Drawing.Size(193, 148);
            this.thumbnailPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.thumbnailPictureBox.TabIndex = 3;
            this.thumbnailPictureBox.TabStop = false;
            // 
            // infosPanel
            // 
            this.infosPanel.ColumnCount = 1;
            this.infosPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.infosPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.infosPanel.Controls.Add(this.urlLabel, 0, 0);
            this.infosPanel.Controls.Add(this.statusLabel, 0, 1);
            this.infosPanel.Controls.Add(this.fromToPanel, 0, 2);
            this.infosPanel.Controls.Add(this.metadataPanel, 0, 3);
            this.infosPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infosPanel.Location = new System.Drawing.Point(199, 0);
            this.infosPanel.Margin = new System.Windows.Forms.Padding(0);
            this.infosPanel.Name = "infosPanel";
            this.infosPanel.RowCount = 4;
            this.infosPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.42466F));
            this.infosPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.57534F));
            this.infosPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.infosPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.infosPanel.Size = new System.Drawing.Size(457, 154);
            this.infosPanel.TabIndex = 4;
            // 
            // urlLabel
            // 
            this.urlLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(214, 10);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(29, 13);
            this.urlLabel.TabIndex = 0;
            this.urlLabel.Text = "URL";
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(210, 42);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(37, 13);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.Text = "Status";
            // 
            // fromToPanel
            // 
            this.fromToPanel.ColumnCount = 4;
            this.fromToPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.62069F));
            this.fromToPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.37931F));
            this.fromToPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.fromToPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 158F));
            this.fromToPanel.Controls.Add(this.fromLabel, 0, 0);
            this.fromToPanel.Controls.Add(this.toLabel, 2, 0);
            this.fromToPanel.Controls.Add(this.fromTextBox, 1, 0);
            this.fromToPanel.Controls.Add(this.toTextBox, 3, 0);
            this.fromToPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fromToPanel.Location = new System.Drawing.Point(0, 64);
            this.fromToPanel.Margin = new System.Windows.Forms.Padding(0);
            this.fromToPanel.Name = "fromToPanel";
            this.fromToPanel.RowCount = 1;
            this.fromToPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.fromToPanel.Size = new System.Drawing.Size(457, 32);
            this.fromToPanel.TabIndex = 2;
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.fromLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromLabel.Location = new System.Drawing.Point(33, 0);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(40, 32);
            this.fromLabel.TabIndex = 0;
            this.fromLabel.Text = "From";
            this.fromLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.toLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toLabel.Location = new System.Drawing.Point(270, 0);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(25, 32);
            this.toLabel.TabIndex = 1;
            this.toLabel.Text = "To";
            this.toLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fromTextBox
            // 
            this.fromTextBox.DetectUrls = false;
            this.fromTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fromTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromTextBox.Location = new System.Drawing.Point(79, 3);
            this.fromTextBox.Multiline = false;
            this.fromTextBox.Name = "fromTextBox";
            this.fromTextBox.Size = new System.Drawing.Size(146, 26);
            this.fromTextBox.TabIndex = 2;
            this.fromTextBox.Text = "00:00:00";
            // 
            // toTextBox
            // 
            this.toTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toTextBox.Location = new System.Drawing.Point(301, 3);
            this.toTextBox.Name = "toTextBox";
            this.toTextBox.Size = new System.Drawing.Size(153, 26);
            this.toTextBox.TabIndex = 3;
            this.toTextBox.Text = "00:00:00";
            // 
            // metadataPanel
            // 
            this.metadataPanel.ColumnCount = 2;
            this.metadataPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.86031F));
            this.metadataPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.13969F));
            this.metadataPanel.Controls.Add(this.titleLabel, 0, 0);
            this.metadataPanel.Controls.Add(this.artistLabel, 0, 1);
            this.metadataPanel.Controls.Add(this.titleTextBox, 1, 0);
            this.metadataPanel.Controls.Add(this.artistTextBox, 1, 1);
            this.metadataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metadataPanel.Location = new System.Drawing.Point(3, 99);
            this.metadataPanel.Name = "metadataPanel";
            this.metadataPanel.RowCount = 2;
            this.metadataPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.metadataPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.metadataPanel.Size = new System.Drawing.Size(451, 52);
            this.metadataPanel.TabIndex = 3;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(3, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(35, 26);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Title";
            // 
            // artistLabel
            // 
            this.artistLabel.AutoSize = true;
            this.artistLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.artistLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artistLabel.Location = new System.Drawing.Point(3, 26);
            this.artistLabel.Name = "artistLabel";
            this.artistLabel.Size = new System.Drawing.Size(40, 26);
            this.artistLabel.TabIndex = 1;
            this.artistLabel.Text = "Artist";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTextBox.Location = new System.Drawing.Point(60, 3);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(388, 26);
            this.titleTextBox.TabIndex = 2;
            // 
            // artistTextBox
            // 
            this.artistTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.artistTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artistTextBox.Location = new System.Drawing.Point(60, 29);
            this.artistTextBox.Name = "artistTextBox";
            this.artistTextBox.Size = new System.Drawing.Size(388, 26);
            this.artistTextBox.TabIndex = 3;
            // 
            // YoutubeDownloadItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "YoutubeDownloadItem";
            this.Size = new System.Drawing.Size(780, 154);
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailPictureBox)).EndInit();
            this.infosPanel.ResumeLayout(false);
            this.infosPanel.PerformLayout();
            this.fromToPanel.ResumeLayout(false);
            this.fromToPanel.PerformLayout();
            this.metadataPanel.ResumeLayout(false);
            this.metadataPanel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private System.Windows.Forms.Label urlLabel;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.PictureBox thumbnailPictureBox;
		private System.Windows.Forms.TableLayoutPanel infosPanel;
		private System.Windows.Forms.TableLayoutPanel fromToPanel;
		private System.Windows.Forms.Label fromLabel;
		private System.Windows.Forms.Label toLabel;
		private System.Windows.Forms.RichTextBox fromTextBox;
		private System.Windows.Forms.RichTextBox toTextBox;
		private System.Windows.Forms.TableLayoutPanel metadataPanel;
		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.Label artistLabel;
		private System.Windows.Forms.TextBox titleTextBox;
		private System.Windows.Forms.TextBox artistTextBox;
	}
}
