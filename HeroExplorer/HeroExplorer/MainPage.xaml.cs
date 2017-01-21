using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using HeroExplorer.Facades;
using HeroExplorer.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HeroExplorer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Character> characters;


        public MainPage()
        {
            this.InitializeComponent();
            this.Characters = new ObservableCollection<Character>();
        }

        public ObservableCollection<Character> Characters
        {
            get
            {
                return this.characters;
            }

            private set
            {
                this.characters = value;
            }
        }

        private async void MainPage_OnLoadedAsync(object sender, RoutedEventArgs e)
        {
            this.MyProgressRing.IsActive = true;
            this.MyProgressRing.Visibility = Visibility.Visible;
            this.Attribution.Text = string.Empty;

            while (this.Characters.Count < 10)
            {
                Task t = Marvel.PupulateMarvelCharactersAsync(this.Characters);
                await t;
            }

            this.MyProgressRing.IsActive = false;
            this.MyProgressRing.Visibility = Visibility.Collapsed;
            this.Attribution.Text = (Marvel.DataWrapper != null) ? Marvel.DataWrapper.AttributionText : "";
        }

        private void MasterListView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var selecetdCharacter = e.ClickedItem as Character;

            if (selecetdCharacter == null)
            {
                return;
            }

            this.DetailDescriptionTextBlock.Text = selecetdCharacter.Description;
            this.DetailNameTextBlock.Text = selecetdCharacter.Name;

            var largeImage = new BitmapImage();
            var uri = new Uri(selecetdCharacter.Thumbnail.Large, UriKind.Absolute);
            largeImage.UriSource = uri;
            this.DetailImage.Source = largeImage;
        }
    }
}
