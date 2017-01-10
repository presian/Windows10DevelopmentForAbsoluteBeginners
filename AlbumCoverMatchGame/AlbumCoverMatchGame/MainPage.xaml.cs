// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409
namespace AlbumCoverMatchGame
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;

    using Windows.Storage;
    using Windows.Storage.FileProperties;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Imaging;

    using AlbumCoverMatchGame.Models;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Song> songs;

        public MainPage()
        {
            this.InitializeComponent();
        }

        public ObservableCollection<Song> Songs
        {
            get
            {
                return this.songs;
            }

            set
            {
                this.songs = value;
            }
        }

        public async void ButtonClickAsync(Object sender, RoutedEventArgs e)
        {
            StorageFolder folder = KnownFolders.MusicLibrary;
            var allSongs = new ObservableCollection<StorageFile>();
            await this.RetriveFileInFolderAsync(allSongs, folder);
            var randomSongs = await this.PicRandomSongsAsync(allSongs);
            await this.PopulateSongListAsync(randomSongs);
        }

        private async Task RetriveFileInFolderAsync(ObservableCollection<StorageFile> list, StorageFolder parent)
        {
            foreach (var file in await parent.GetFilesAsync())
            {
                if (file.FileType == ".mp3")
                {
                    list.Add(file);
                }

                foreach (var folder in await parent.GetFoldersAsync())
                {
                    await this.RetriveFileInFolderAsync(list, folder);
                }
            }
        }

        private async Task<List<StorageFile>> PicRandomSongsAsync(ObservableCollection<StorageFile> allSongs)
        {
            Random random = new Random();
            var randomSongs = new List<StorageFile>();

            while (randomSongs.Count < 10)
            {
                var index = random.Next(allSongs.Count);
                var randomSong = allSongs[index];

                MusicProperties songProp = await randomSong.Properties.GetMusicPropertiesAsync();

                bool isDuplicated = false;
                foreach (var song in randomSongs)
                {
                    var currentSongProp = await song.Properties.GetMusicPropertiesAsync();
                    if (!string.IsNullOrEmpty(songProp.Album) || currentSongProp.Album == songProp.Album)
                    {
                        isDuplicated = true;
                    }
                }

                if (!isDuplicated)
                {
                    randomSongs.Add(randomSong);
                }
            }

            return randomSongs;
        }

        private async Task PopulateSongListAsync(List<StorageFile> files)
        {
            int id = 1;
            foreach (var file in files)
            {
                MusicProperties songProp = await file.Properties.GetMusicPropertiesAsync();
                StorageItemThumbnail currentThumbnail = await file.GetThumbnailAsync(
                    ThumbnailMode.MusicView,
                    200,
                    ThumbnailOptions.UseCurrentScale);

                var albumCover = new BitmapImage();
                albumCover.SetSource(currentThumbnail);

                var song = new Song
                               {
                                   Id = id,
                                   Title = songProp.Title,
                                   Artist = songProp.Artist,
                                   Album = songProp.Album,
                                   AlbumCover = albumCover
                               };
                this.Songs.Add(song);
                id++;
            }
        }
    }
}
