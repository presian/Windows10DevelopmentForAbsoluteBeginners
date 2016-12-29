using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using _45_AdeptlyAdaptiveChallenge.DataModels;

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
            App.State.StateUpdate += this.OnStateUpdate;

            // This sets selected item by default in main menu to first element of list vew
            this.MainMenu.SelectedIndex = 0;
            this.Pages.Navigate(typeof(FinancialPage));
        }

        //TODO: Try to bind state to view directly
        private void OnStateUpdate(object sender, EventArgs eventArgs)
        {
            var state = sender as ApplicationState;
            if (state != null)
            {
                this.Title.Text = state.CurrentPageTitle;
                if (state.ShowBackButton)
                {
                    this.BackArrow.Visibility = Visibility.Visible;
                    this.Title.Margin = new Thickness(0,0,0,0);
                }
                else
                {
                    this.BackArrow.Visibility = Visibility.Collapsed;
                    this.Title.Margin = new Thickness(20, 0, 20, 0);
                }
            }
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
//                                this.Title.Text = "Financial";
                                break;
                            case "FoodNavigationItem":
                                this.Pages.Navigate(typeof(FoodPage));
//                                this.Title.Text = "Food";
                                break;
                        }
                }  
            }

            this.LeftMenu.IsPaneOpen = false;
        }

        private void BackArrow_Click(object sender, RoutedEventArgs e)
        {
            if (this.Pages.CanGoBack)
            {
                this.Pages.GoBack();
            }
        }
    }
}
