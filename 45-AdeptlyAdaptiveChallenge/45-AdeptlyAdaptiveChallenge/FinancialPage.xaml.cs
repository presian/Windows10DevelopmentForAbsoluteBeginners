// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FinancialPage.xaml.cs" company="PresianDanailov">
//   Presian Danailov
// </copyright>
// <summary>
//   An empty page that can be used on its own or navigated to within a Frame.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using _45_AdeptlyAdaptiveChallenge.DataModels;
using _45_AdeptlyAdaptiveChallenge.Enumerations;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238
namespace _45_AdeptlyAdaptiveChallenge
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FinancialPage : Page
    {
        private List<NewsItem> news;
        private Categories category = Categories.Financial;


        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialPage"/> class.
        /// </summary>
        public FinancialPage()
        {
            App.State.CurrentPageTitle = "Financial";
            App.State.ShowBackButton = false;
            App.State.ActiveNavigationButtonIndex = 0;
            this.News = App.Factory.GetItemsByCategory(this.Category);
            this.InitializeComponent();
        }

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

        public Categories Category => category;
    }
}
