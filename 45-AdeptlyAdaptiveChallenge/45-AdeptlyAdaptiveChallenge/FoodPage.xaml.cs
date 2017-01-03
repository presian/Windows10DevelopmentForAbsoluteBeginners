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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238
namespace _45_AdeptlyAdaptiveChallenge
{
    using _45_AdeptlyAdaptiveChallenge.DataModels;
    using _45_AdeptlyAdaptiveChallenge.Enumerations;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FoodPage : Page
    {
        /// <summary>
        /// The category.
        /// </summary>
        private Categories category = Categories.Food;

        /// <summary>
        /// The news.
        /// </summary>
        private List<NewsItem> news = new List<NewsItem>();

        /// <summary>
        /// Initializes a new instance of the <see cref="FoodPage"/> class.
        /// </summary>
        public FoodPage()
        {
            App.State.CurrentPageTitle = "Food";
            App.State.ShowBackButton = true;
            App.State.ActiveNavigationButtonIndex = 1;
            this.News = App.Factory.GetItemsByCategory(this.category);
            this.InitializeComponent();
        }

        /// <summary>
        /// The category.
        /// </summary>
        public Categories Category => this.category;

        /// <summary>
        /// Gets the news.
        /// </summary>
        public List<NewsItem> News
        {
            get
            {
                return this.news;
            }

            private set
            {
                this.news = value;
            }
        }
    }
}
