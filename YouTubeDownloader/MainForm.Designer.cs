namespace YouTubeDownloader
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            OutputFolderSelectButton = new Button();
            YouTubeLinkLabel = new Label();
            OutputFolderLabel = new Label();
            YouTubeLinkTextBox = new TextBox();
            OutputFolderTextBox = new TextBox();
            OutputFolderSelectDialog = new FolderBrowserDialog();
            DownloadTypeComboBox = new ComboBox();
            DownloadTypeLabel = new Label();
            StatusStrip = new StatusStrip();
            StatusLabel = new ToolStripStatusLabel();
            StatusTextLabel = new ToolStripStatusLabel();
            SpringLabel = new ToolStripStatusLabel();
            CopyrightVersionLabel = new ToolStripStatusLabel();
            DownloadButton = new Button();
            DownloadProgressBar = new ProgressBar();
            MenuStrip = new MenuStrip();
            LanguageMenuStrip = new ToolStripMenuItem();
            EnglishMenuStrip = new ToolStripMenuItem();
            ItalianMenuStrip = new ToolStripMenuItem();
            CancelButton = new Button();
            StatusStrip.SuspendLayout();
            MenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // OutputFolderSelectButton
            // 
            resources.ApplyResources(OutputFolderSelectButton, "OutputFolderSelectButton");
            OutputFolderSelectButton.Name = "OutputFolderSelectButton";
            OutputFolderSelectButton.UseVisualStyleBackColor = true;
            OutputFolderSelectButton.Click += OutputFolderSelectButton_Click;
            // 
            // YouTubeLinkLabel
            // 
            resources.ApplyResources(YouTubeLinkLabel, "YouTubeLinkLabel");
            YouTubeLinkLabel.Name = "YouTubeLinkLabel";
            // 
            // OutputFolderLabel
            // 
            resources.ApplyResources(OutputFolderLabel, "OutputFolderLabel");
            OutputFolderLabel.Name = "OutputFolderLabel";
            // 
            // YouTubeLinkTextBox
            // 
            resources.ApplyResources(YouTubeLinkTextBox, "YouTubeLinkTextBox");
            YouTubeLinkTextBox.Name = "YouTubeLinkTextBox";
            // 
            // OutputFolderTextBox
            // 
            resources.ApplyResources(OutputFolderTextBox, "OutputFolderTextBox");
            OutputFolderTextBox.Name = "OutputFolderTextBox";
            // 
            // OutputFolderSelectDialog
            // 
            resources.ApplyResources(OutputFolderSelectDialog, "OutputFolderSelectDialog");
            // 
            // DownloadTypeComboBox
            // 
            DownloadTypeComboBox.DisplayMember = "0";
            DownloadTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            DownloadTypeComboBox.FormattingEnabled = true;
            DownloadTypeComboBox.Items.AddRange(new object[] { resources.GetString("DownloadTypeComboBox.Items"), resources.GetString("DownloadTypeComboBox.Items1"), resources.GetString("DownloadTypeComboBox.Items2") });
            resources.ApplyResources(DownloadTypeComboBox, "DownloadTypeComboBox");
            DownloadTypeComboBox.Name = "DownloadTypeComboBox";
            // 
            // DownloadTypeLabel
            // 
            resources.ApplyResources(DownloadTypeLabel, "DownloadTypeLabel");
            DownloadTypeLabel.Name = "DownloadTypeLabel";
            // 
            // StatusStrip
            // 
            StatusStrip.ImageScalingSize = new Size(24, 24);
            StatusStrip.Items.AddRange(new ToolStripItem[] { StatusLabel, StatusTextLabel, SpringLabel, CopyrightVersionLabel });
            resources.ApplyResources(StatusStrip, "StatusStrip");
            StatusStrip.Name = "StatusStrip";
            StatusStrip.SizingGrip = false;
            // 
            // StatusLabel
            // 
            StatusLabel.Name = "StatusLabel";
            resources.ApplyResources(StatusLabel, "StatusLabel");
            // 
            // StatusTextLabel
            // 
            StatusTextLabel.Name = "StatusTextLabel";
            resources.ApplyResources(StatusTextLabel, "StatusTextLabel");
            // 
            // SpringLabel
            // 
            SpringLabel.Name = "SpringLabel";
            resources.ApplyResources(SpringLabel, "SpringLabel");
            SpringLabel.Spring = true;
            // 
            // CopyrightVersionLabel
            // 
            CopyrightVersionLabel.Name = "CopyrightVersionLabel";
            resources.ApplyResources(CopyrightVersionLabel, "CopyrightVersionLabel");
            // 
            // DownloadButton
            // 
            resources.ApplyResources(DownloadButton, "DownloadButton");
            DownloadButton.Name = "DownloadButton";
            DownloadButton.UseVisualStyleBackColor = true;
            DownloadButton.Click += DownloadButton_Click;
            // 
            // DownloadProgressBar
            // 
            resources.ApplyResources(DownloadProgressBar, "DownloadProgressBar");
            DownloadProgressBar.Name = "DownloadProgressBar";
            // 
            // MenuStrip
            // 
            MenuStrip.ImageScalingSize = new Size(24, 24);
            MenuStrip.Items.AddRange(new ToolStripItem[] { LanguageMenuStrip });
            resources.ApplyResources(MenuStrip, "MenuStrip");
            MenuStrip.Name = "MenuStrip";
            MenuStrip.RenderMode = ToolStripRenderMode.System;
            // 
            // LanguageMenuStrip
            // 
            LanguageMenuStrip.DropDownItems.AddRange(new ToolStripItem[] { EnglishMenuStrip, ItalianMenuStrip });
            LanguageMenuStrip.Name = "LanguageMenuStrip";
            resources.ApplyResources(LanguageMenuStrip, "LanguageMenuStrip");
            // 
            // EnglishMenuStrip
            // 
            EnglishMenuStrip.Name = "EnglishMenuStrip";
            resources.ApplyResources(EnglishMenuStrip, "EnglishMenuStrip");
            EnglishMenuStrip.Click += EnglishMenuStrip_Click;
            // 
            // ItalianMenuStrip
            // 
            ItalianMenuStrip.Name = "ItalianMenuStrip";
            resources.ApplyResources(ItalianMenuStrip, "ItalianMenuStrip");
            ItalianMenuStrip.Click += ItalianMenuStrip_Click;
            // 
            // CancelButton
            // 
            resources.ApplyResources(CancelButton, "CancelButton");
            CancelButton.Name = "CancelButton";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // MainForm
            // 
            AcceptButton = DownloadButton;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(CancelButton);
            Controls.Add(DownloadProgressBar);
            Controls.Add(DownloadButton);
            Controls.Add(StatusStrip);
            Controls.Add(MenuStrip);
            Controls.Add(DownloadTypeLabel);
            Controls.Add(DownloadTypeComboBox);
            Controls.Add(OutputFolderTextBox);
            Controls.Add(YouTubeLinkTextBox);
            Controls.Add(OutputFolderLabel);
            Controls.Add(YouTubeLinkLabel);
            Controls.Add(OutputFolderSelectButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = MenuStrip;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            FormClosing += MainForm_FormClosing;
            StatusStrip.ResumeLayout(false);
            StatusStrip.PerformLayout();
            MenuStrip.ResumeLayout(false);
            MenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button OutputFolderSelectButton;
        private Label YouTubeLinkLabel;
        private Label OutputFolderLabel;
        private TextBox YouTubeLinkTextBox;
        private TextBox OutputFolderTextBox;
        private FolderBrowserDialog OutputFolderSelectDialog;
        private ComboBox DownloadTypeComboBox;
        private Label DownloadTypeLabel;
        private StatusStrip StatusStrip;
        private ToolStripStatusLabel StatusLabel;
        private Button DownloadButton;
        private ToolStripStatusLabel CopyrightVersionLabel;
        private ToolStripStatusLabel SpringLabel;
        private ProgressBar DownloadProgressBar;
        private ToolStripStatusLabel StatusTextLabel;
        private MenuStrip MenuStrip;
        private ToolStripMenuItem LanguageMenuStrip;
        private ToolStripMenuItem EnglishMenuStrip;
        private ToolStripMenuItem ItalianMenuStrip;
        private Button CancelButton;
    }
}
