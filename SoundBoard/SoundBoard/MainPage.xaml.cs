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

    using SoundBoard.Factories;
    using SoundBoard.Models;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
            this.menuItems = MenuItemsFactory.MakeMenuItems();
            this.sounds = new ObservableCollection<Sound>();
            SoundItemsFactory.GetSounds(this.sounds);
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
    }
}
