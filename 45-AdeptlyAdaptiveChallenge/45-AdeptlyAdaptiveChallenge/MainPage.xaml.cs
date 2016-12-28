using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _45_AdeptlyAdaptiveChallenge
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.MainMenu.Focus(FocusState.Programmatic);
            // This sets selected item by default in main menu to first element of list vew
            this.MainMenu.SelectedIndex = 0; 
            this.Pages.Navigate(typeof(FinancialPage));
        }

        private void HamburgerMenuButton_Click(object sender, RoutedEventArgs e)
        {
            this.LeftMenu.IsPaneOpen = !this.LeftMenu.IsPaneOpen;
        }

        private void MainMenu_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = (StackPanel) e.ClickedItem;
            if (item != null)
            {
                if (item.Parent.GetType() == typeof(ListViewItem))
                {
                    var parent = item.Parent as ListViewItem;
                    if (parent != null)
                        switch (parent.Name)
                        {
                            case "FinancialNavigationItem":
                                this.Pages.Navigate(typeof(FinancialPage));
                                break;
                            case "FoodNavigationItem":
                                this.Pages.Navigate(typeof(FoodPage));
                                break;
                        }
                }  
            }

            this.LeftMenu.IsPaneOpen = false;
        }
    }
}
