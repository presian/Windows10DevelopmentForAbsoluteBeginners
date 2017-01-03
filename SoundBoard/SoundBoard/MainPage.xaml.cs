// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainPage.xaml.cs" company="PresianDanailov">
//   Null
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoundBoard
{
    using System;
    using System.Collections.Generic;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    using SoundBoard.Factories;
    using SoundBoard.Models;

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
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            this.MenuItems = MenuItemsFactory.MakeMenuItems();
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the menu items.
        /// </summary>
        public List<MenuItem> MenuItems
        {
            get
            {
                return this.menuItems;
            }

            private set
            {
                this.menuItems = value;
            }
        }

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
            
        }

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
    }
}
