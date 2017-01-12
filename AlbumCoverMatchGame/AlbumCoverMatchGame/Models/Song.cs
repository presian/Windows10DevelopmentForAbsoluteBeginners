namespace AlbumCoverMatchGame.Models
{
    using Windows.Storage;
    using Windows.UI.Xaml.Media.Imaging;

    /// <summary>
    /// The song
    /// </summary>
    public class Song
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Artist { get; set; }

        public string Album { get; set; }

        public StorageFile File { get; set; }

        public bool Selected { get; set; }

        public bool Used { get; set; }

        public BitmapImage AlbumCover { get; set; }
    }
}