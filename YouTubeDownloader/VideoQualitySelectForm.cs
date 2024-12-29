using YoutubeExplode.Videos.Streams;

namespace YouTubeDownloader
{
    public partial class VideoQualitySelectForm : Form
    {
        //
        // Members
        //
        #region Members

        // Video quality index
        public int VideoQualityIndex { get; private set; }

        #endregion

        //
        // Constructor
        //
        #region Constructor

        public VideoQualitySelectForm(IEnumerable<VideoOnlyStreamInfo> VideoStreams)
        {
            InitializeComponent();

            foreach (var video_stream in VideoStreams)
            {
                VideoQualityComboBox.Items.Add(
                    $"{video_stream.VideoQuality.Label} ({video_stream.Bitrate})"
                );

            }
            VideoQualityComboBox.SelectedIndex = 0;
        }

        #endregion

        //
        // GUI events
        //
        #region GUI events

        // Confirm button click
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            VideoQualityIndex = VideoQualityComboBox.SelectedIndex;
            Close();
        }

        #endregion
    }
}
