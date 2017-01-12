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
    using Windows.UI;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Media.Imaging;

    using AlbumCoverMatchGame.Models;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Song> songs;

        private ObservableCollection<StorageFile> allSongs;

        private bool isMusicPlaying = false;

        private int round = 0;

        public MainPage()
        {
            this.InitializeComponent();
            this.Songs = new ObservableCollection<Song>();
            this.AllSongs = new ObservableCollection<StorageFile>();
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

        public ObservableCollection<StorageFile> AllSongs
        {
            get
            {
                return this.allSongs;
            }

            set
            {
                this.allSongs = value;
            }
        }

        public bool IsMusicPlaying
        {
            get
            {
                return this.isMusicPlaying;
            }

            set
            {
                this.isMusicPlaying = value;
            }
        }

        public int Round
        {
            get
            {
                return this.round;
            }

            set
            {
                this.round = value;
            }
        }

        private async void PageLoadedAsync(Object sender, RoutedEventArgs e)
        {
            this.StartupProgress.IsActive = true;
            await this.SetupMusicListAsync();
            await this.PrepareNewGameAsync();
            this.StartupProgress.IsActive = false;
            this.StartCooldown();
        }

        private async Task SetupMusicListAsync()
        {
            StorageFolder folder = KnownFolders.MusicLibrary;
            await this.RetriveFileInFolderAsync(folder);
        }

        private async Task PrepareNewGameAsync()
        {
            this.Songs.Clear();

            var randomSongs = await this.PicRandomSongsAsync();
            await this.PopulateSongListAsync(randomSongs);
        }

        private async Task RetriveFileInFolderAsync(StorageFolder parent)
        {
            var files = await parent.GetFilesAsync();
            foreach (var file in files)
            {
                if (file.FileType.ToLower() == ".mp3")
                {
                    this.AllSongs.Add(file);
                }
            }

            foreach (var folder in await parent.GetFoldersAsync())
            {
                await this.RetriveFileInFolderAsync(folder);
            }
        }

        private async Task<List<StorageFile>> PicRandomSongsAsync()
        {
            Random random = new Random();
            var randomSongs = new List<StorageFile>();
            var loopIndex = 0;
            while (randomSongs.Count < 10 && this.AllSongs.Count > loopIndex)
            {
                var index = random.Next(this.AllSongs.Count);
                var randomSong = this.AllSongs[index];

                MusicProperties songProp = await randomSong.Properties.GetMusicPropertiesAsync();

                bool isDuplicated = false;
                foreach (var song in randomSongs)
                {
                    var currentSongProp = await song.Properties.GetMusicPropertiesAsync();
                    if (!string.IsNullOrEmpty(songProp.Album) && currentSongProp.Album == songProp.Album)
                    {
                        isDuplicated = true;
                    }
                }

                if (!isDuplicated)
                {
                    randomSongs.Add(randomSong);
                }

                loopIndex++;
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
                                   AlbumCover = albumCover,
                                   File = file,
                                   Used = false
                               };
                this.Songs.Add(song);
                id++;
            }
        }

        private void SongGridViewItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.IsMusicPlaying)
            {
                this.Round++;
                this.StartCooldown();
            }
        }

        private void PlayAgainButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void CountDownCompleted(object sender, object e)
        {
            if (!this.IsMusicPlaying)
            {
                var song = this.PickSong();
                this.MyMediaElement.SetSource(await song.File.OpenAsync(FileAccessMode.Read), song.File.ContentType);
                this.StartCountdown();
                this.IsMusicPlaying = true;
            }
            else
            {
                this.MyMediaElement.Stop();
            }
        }

        private Song PickSong()
        {
            Random random = new Random();
            var unusedSongs = this.Songs.Where(s => s.Used == false);
            var randomIndex = random.Next(unusedSongs.Count());
            var randomSong = unusedSongs.ElementAt(randomIndex);
            randomSong.Used = true;

            return randomSong;
        }

        private void StartCooldown()
        {
            this.IsMusicPlaying = false;
            SolidColorBrush brush = new SolidColorBrush(Colors.Blue);
            this.MyProgressBar.Foreground = brush;
            this.InstructionBlock.Text = string.Format("Get ready for round {0} ...", this.round + 1);
            this.InstructionBlock.Foreground = brush;

            this.CountDown.Begin();
        }

        private void StartCountdown()
        {
            this.IsMusicPlaying = true;
            SolidColorBrush brush = new SolidColorBrush(Colors.Red);
            this.MyProgressBar.Foreground = brush;
            this.InstructionBlock.Text = "GO!";
            this.InstructionBlock.Foreground = brush;

            this.CountDown.Begin();
        }
    }
}
