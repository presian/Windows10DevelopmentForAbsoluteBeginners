// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainPage.xaml.cs" company="PresianDanailov">
//   Null
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;

namespace SoundBoard
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using SoundBoard.Enumerations;
    using SoundBoard.Factories;
    using SoundBoard.Models;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.ApplicationModel.DataTransfer;
    using Windows.Storage;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// The menu items.
        /// </summary>
        private List<MenuItem> menuItems;

        /// <summary>
        /// The sounds.
        /// </summary>
        private ObservableCollection<Sound> sounds;

        private ObservableCollection<Sound> allSounds;

        private ObservableCollection<Sound> suggestions;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
            this.menuItems = MenuItemsFactory.MakeMenuItems();
            this.sounds = new ObservableCollection<Sound>();
            SoundItemsFactory.GetSounds(this.sounds);
            this.allSounds = new ObservableCollection<Sound>();
            SoundItemsFactory.GetSounds(this.allSounds);
            this.suggestions = new ObservableCollection<Sound>();
            this.BackButton.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Gets the menu items.
        /// </summary>
        public List<MenuItem> MenuItems => this.menuItems;

        /// <summary>
        /// Gets the sounds.
        /// </summary>
//        public ObservableCollection<Sound> Sounds => this.sounds;

        /// <summary>
        /// The main navigation_ on selection changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MainMenu_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var menuItem = sender as ListBox;
            var item = menuItem?.SelectedItem as MenuItem;
            if (item != null)
            {
                SoundItemsFactory.GetSounds(this.sounds, item.Category);
                this.CategoryTitle.Text = item.Category.ToString();
            }
            
            this.BackButton.Visibility = Visibility.Visible;
        }

        public ObservableCollection<Sound> Sounds => sounds;

        /// <summary>
        /// The hamburger button_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void HamburgerButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.ContentWrapper.IsPaneOpen = !this.ContentWrapper.IsPaneOpen;
        }

        /// <summary>
        /// The back button_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.GoBack();
        }

        private void GoBack()
        {
            SoundItemsFactory.GetSounds(this.sounds);
            this.MainMenu.SelectedItem = null;
            this.CategoryTitle.Text = "AllSounds";
            BackButton.Visibility = Visibility.Collapsed;
        }

        private void SoundGridView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var sound = e.ClickedItem as Sound;
            if (sound != null)
            {
                MyMediaElement.Source = new Uri(sound.AudioFile);
            }
        }

        private async void SoundGridView_DropAsync(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();

                if (items.Any())
                {
                    var storageFile = items[0] as StorageFile;
                    var contentType = storageFile.ContentType;

                    StorageFolder folder = ApplicationData.Current.LocalFolder;

                    if(contentType == AudioContentTypes.Wav || contentType == AudioContentTypes.Mpeg)
                    {
                        var newFile = await storageFile.CopyAsync(folder, storageFile.Name, NameCollisionOption.GenerateUniqueName);
                        MyMediaElement.SetSource(await storageFile.OpenAsync(FileAccessMode.Read), contentType);
                        MyMediaElement.Play();
                    }
                }
            }
        }

        private void SoundGridView_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
            e.DragUIOverride.Caption = "Drop .wav or .mpeg file for playing";
            e.DragUIOverride.IsCaptionVisible = true;
            e.DragUIOverride.IsContentVisible = true;
            e.DragUIOverride.IsGlyphVisible = true;
        }

        private void Search_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if(string.IsNullOrEmpty(args.QueryText))
            {
                this.GoBack();
            }
            else
            {
                SoundItemsFactory.GetSoundsByName(this.sounds, args.QueryText);
                this.CategoryTitle.Text = args.QueryText;
                this.BackButton.Visibility = Visibility.Visible;
            }
        }

        private void Search_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (string.IsNullOrEmpty(sender.Text))
            {
                this.GoBack();
            }
            else
            {
                this.Search.ItemsSource = this.allSounds
                .Where(s => s.Name.ToLower().StartsWith(sender.Text.ToLower()))
                .Select(s => s.Name);
            }
        }
    }
}
