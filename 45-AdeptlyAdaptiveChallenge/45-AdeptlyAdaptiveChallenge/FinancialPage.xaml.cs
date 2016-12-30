// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FinancialPage.xaml.cs" company="PresianDanailov">
//   Presian Danailov
// </copyright>
// <summary>
//   An empty page that can be used on its own or navigated to within a Frame.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238
namespace _45_AdeptlyAdaptiveChallenge
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FinancialPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialPage"/> class.
        /// </summary>
        public FinancialPage()
        {
            App.State.CurrentPageTitle = "Financial";
            App.State.ShowBackButton = false;
            this.InitializeComponent();
        }
    }
}
