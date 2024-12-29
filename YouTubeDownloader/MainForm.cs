using System.Reflection;
using System.Resources;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace YouTubeDownloader
{
    public partial class MainForm : Form
    {
        //
        // Constants
        //
        #region Constants

        // Download types
        const int DOWNLOAD_TYPE_MIN_VAL = 0;
        const int DOWNLOAD_TYPE_AUDIO = 0;
        const int DOWNLOAD_TYPE_VIDEO_HIGHEST = 1;
        const int DOWNLOAD_TYPE_VIDEO_CUSTOM = 2;
        const int DOWNLOAD_TYPE_MAX_VAL = 3;

        // Values for setting minimum/maximum progress
        const int DOWNLOAD_PROGRESS_MIN_VAL = 0;
        const int DOWNLOAD_PROGRESS_MAX_VAL = -1;

        // Download type to file extension mapping
        private readonly Dictionary<int, string> DOWNLOAD_TYPE_TO_FILE_EXT = new Dictionary<int, string>
        {
            { DOWNLOAD_TYPE_AUDIO, "mp3" },
            { DOWNLOAD_TYPE_VIDEO_HIGHEST, "mp4" },
            { DOWNLOAD_TYPE_VIDEO_CUSTOM, "mp4" },
        };

        #endregion

        //
        // Members
        //
        #region Members

        private CancellationTokenSource downloadCancellation;
        private ResourceManager resourceManager;

        #endregion

        //
        // Constructor
        //
        #region Constructor

        public MainForm()
        {
            InitializeComponent();
            InitializeResource();

            ShowCopyrightAndVersion();
            LoadSettings();

            downloadCancellation = null;
        }

        #endregion

        //
        // GUI events
        //
        #region GUI events

        // Form closing
        private void MainForm_FormClosing(object sender, EventArgs e)
        {
            SaveSettings();
        }

        // Output folder select button
        private void OutputFolderSelectButton_Click(object sender, EventArgs e)
        {
            DialogResult res = OutputFolderSelectDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                OutputFolderTextBox.Text = OutputFolderSelectDialog.SelectedPath;
            }
        }

        // English menu item click
        private void EnglishMenuStrip_Click(object sender, EventArgs e)
        {
            SetLanguage("en");
        }

        // Italian menu item click
        private void ItalianMenuStrip_Click(object sender, EventArgs e)
        {
            SetLanguage("it");
        }

        // Cancel button
        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (downloadCancellation is null)
            {
                return;
            }
            downloadCancellation.Cancel();
        }

        // Download button
        private async void DownloadButton_Click(object sender, EventArgs e)
        {
            string output_folder = OutputFolderTextBox.Text;
            if (!Path.Exists(output_folder))
            {
                ShowError(resourceManager.GetString("OutputFolderErr"));
                return;
            }

            string youtube_url = YouTubeLinkTextBox.Text;
            if (youtube_url == "")
            {
                ShowError(resourceManager.GetString("YouTubeUrlErr"));
                return;
            }

            int download_type = DownloadTypeComboBox.SelectedIndex;
            if (download_type < DOWNLOAD_TYPE_MIN_VAL || download_type >= DOWNLOAD_TYPE_MAX_VAL)
            {
                ShowError(resourceManager.GetString("DownloadTypeErr"));
                return;
            }

            downloadCancellation = new CancellationTokenSource();

            await DownloadVideoAsync(youtube_url, output_folder, download_type, downloadCancellation.Token);
        }

        #endregion

        //
        // Private methods
        //
        #region Private methods

        // Load settings
        private void LoadSettings()
        {
            // Output folder
            string output_folder = Properties.Settings.Default.OutputFolder;
            if (Path.Exists(output_folder))
            {
                OutputFolderTextBox.Text = output_folder;
            }
            else
            {
                OutputFolderTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }

            // Download type
            int type = Properties.Settings.Default.DownloadType;
            if (type >= DOWNLOAD_TYPE_MIN_VAL && type < DOWNLOAD_TYPE_MAX_VAL)
            {
                DownloadTypeComboBox.SelectedIndex = type;
            }
            else
            {
                DownloadTypeComboBox.SelectedIndex = DOWNLOAD_TYPE_AUDIO;
            }
        }

        // Save settings
        private void SaveSettings()
        {
            Properties.Settings.Default.DownloadType = DownloadTypeComboBox.SelectedIndex;
            Properties.Settings.Default.OutputFolder = OutputFolderTextBox.Text;
            Properties.Settings.Default.Save();
        }

        // Download video
        private async Task DownloadVideoAsync(
            string YoutubeUrl,
            string OutputFolder,
            int DownloadType,
            CancellationToken cancellationToken
        )
        {
            SetGuiEnabled(false);

            SetDownloadProgress(DOWNLOAD_PROGRESS_MIN_VAL);
            SetStatusText(resourceManager.GetString("FetchingStatus"));

            try
            {
                var youtube = new YoutubeClient();
                var video = await youtube.Videos.GetAsync(YoutubeUrl, cancellationToken);

                string file_path = GetOutputFilePath(video, OutputFolder, DownloadType);

                var stream_manifest = await youtube.Videos.Streams.GetManifestAsync(video.Id, cancellationToken);
                var audio_stream_info = stream_manifest.GetAudioOnlyStreams().GetWithHighestBitrate();

                // Audio-only download
                if (DownloadType == DOWNLOAD_TYPE_AUDIO)
                {
                    SetStatusText(resourceManager.GetString("DownloadStatus"));

                    await youtube.Videos.Streams.DownloadAsync(
                        audio_stream_info,
                        file_path,
                        new Progress<double>(p => SetDownloadProgress((int)(p * 100))),
                        cancellationToken
                    );
                }
                // Video + Audio download
                else
                {
                    var video_streams = stream_manifest.GetVideoOnlyStreams()
                        .Where(s => s.Container == YoutubeExplode.Videos.Streams.Container.Mp4);

                    IStreamInfo video_stream_info;
                    if (DownloadType == DOWNLOAD_TYPE_VIDEO_HIGHEST)
                    {
                        video_stream_info = video_streams.GetWithHighestVideoQuality();
                    }
                    else
                    {
                        var video_quality_select_form = new VideoQualitySelectForm(video_streams);
                        video_quality_select_form.ShowDialog();

                        video_stream_info = video_streams.ElementAt(video_quality_select_form.VideoQualityIndex);
                    }

                    SetStatusText(resourceManager.GetString("DownloadStatus"));

                    var stream_infos = new IStreamInfo[] { audio_stream_info, video_stream_info };
                    await youtube.Videos.DownloadAsync(
                        stream_infos,
                        new ConversionRequestBuilder(file_path).Build(),
                        new Progress<double>(p => SetDownloadProgress((int)(p * 100))),
                        cancellationToken
                    );
                }

                SetDownloadProgress(DOWNLOAD_PROGRESS_MAX_VAL);
                SetStatusText(resourceManager.GetString("IdleStatus"));

                ShowInfo(resourceManager.GetString("DownloadSuccess"));
            }
            catch (OperationCanceledException)
            {
                SetDownloadProgress(DOWNLOAD_PROGRESS_MIN_VAL);
                SetStatusText(resourceManager.GetString("IdleStatus"));
            }
            catch (Exception ex)
            {
                SetDownloadProgress(DOWNLOAD_PROGRESS_MAX_VAL);
                SetStatusText(resourceManager.GetString("Error"));

                ShowError($"{resourceManager.GetString("DownloadErr")} {ex.Message}");
            }

            SetGuiEnabled(true);
        }

        // Get output file path
        private string GetOutputFilePath(Video Video, string OutputFolder, int DownloadType)
        {
            string sanitized_title = string.Join("", Video.Title.Split(Path.GetInvalidFileNameChars()));
            string file_name = $"{sanitized_title}.{DOWNLOAD_TYPE_TO_FILE_EXT[DownloadType]}";
            return Path.Join(OutputFolder, file_name);
        }

        // Initialize resource
        private void InitializeResource()
        {
            string res_name = "YouTubeDownloader.Properties.lang_" +
                System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            resourceManager = new ResourceManager(
                res_name,
                Assembly.GetExecutingAssembly()
            );
        }

        // Show copyright and version
        private void ShowCopyrightAndVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            string copyright = assembly.GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright;
            string version = assembly.GetName().Version.ToString();

            CopyrightVersionLabel.Text = $"v{version} - {copyright}";
        }

        // Set language
        private void SetLanguage(string cCulture)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cCulture);

            string youtube_url = YouTubeLinkTextBox.Text;
            string output_folder = OutputFolderTextBox.Text;
            int download_type = DownloadTypeComboBox.SelectedIndex;

            this.Controls.Clear();
            InitializeComponent();
            InitializeResource();

            YouTubeLinkTextBox.Text = youtube_url;
            OutputFolderTextBox.Text = output_folder;
            DownloadTypeComboBox.SelectedIndex = download_type;

            ShowCopyrightAndVersion();
        }

        // Enable/Disable GUI
        private void SetGuiEnabled(bool enabled)
        {
            CancelButton.Enabled = !enabled;
            DownloadButton.Enabled = enabled;
            DownloadTypeComboBox.Enabled = enabled;
            LanguageMenuStrip.Enabled = enabled;
            OutputFolderSelectButton.Enabled = enabled;
            OutputFolderTextBox.Enabled = enabled;
            YouTubeLinkTextBox.Enabled = enabled;

            if (enabled)
            {
                CancelButton.Hide();
                DownloadButton.Show();
            }
            else
            {
                DownloadButton.Hide();
                CancelButton.Show();
            }
        }

        // Set download progress
        private void SetDownloadProgress(int Progress)
        {
            DownloadProgressBar.Value = Progress == DOWNLOAD_PROGRESS_MAX_VAL ? DownloadProgressBar.Maximum : Progress;
        }

        // Set status text
        private void SetStatusText(string? Text)
        {
            StatusTextLabel.Text = Text;
        }

        // Show error message box
        private void ShowError(string? Text)
        {
            MessageBox.Show(
                Text,
                resourceManager.GetString("Error"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        // Show info message box
        private void ShowInfo(string? Text)
        {
            MessageBox.Show(
                Text,
                resourceManager.GetString("Info"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        #endregion

    }
}
