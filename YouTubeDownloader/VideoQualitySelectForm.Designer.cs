namespace YouTubeDownloader
{
    partial class VideoQualitySelectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoQualitySelectForm));
            VideoQualityLabel = new Label();
            VideoQualityComboBox = new ComboBox();
            ConfirmButton = new Button();
            SuspendLayout();
            // 
            // VideoQualityLabel
            // 
            resources.ApplyResources(VideoQualityLabel, "VideoQualityLabel");
            VideoQualityLabel.Name = "VideoQualityLabel";
            // 
            // VideoQualityComboBox
            // 
            VideoQualityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            VideoQualityComboBox.FormattingEnabled = true;
            resources.ApplyResources(VideoQualityComboBox, "VideoQualityComboBox");
            VideoQualityComboBox.Name = "VideoQualityComboBox";
            // 
            // ConfirmButton
            // 
            resources.ApplyResources(ConfirmButton, "ConfirmButton");
            ConfirmButton.Name = "ConfirmButton";
            ConfirmButton.UseVisualStyleBackColor = true;
            ConfirmButton.Click += ConfirmButton_Click;
            // 
            // VideoQualitySelectForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            ControlBox = false;
            Controls.Add(ConfirmButton);
            Controls.Add(VideoQualityComboBox);
            Controls.Add(VideoQualityLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "VideoQualitySelectForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label VideoQualityLabel;
        private ComboBox VideoQualityComboBox;
        private Button ConfirmButton;
    }
}