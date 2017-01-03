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
using _45_AdeptlyAdaptiveChallenge.DataModels;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace _45_AdeptlyAdaptiveChallenge.Templates
{
    public sealed partial class NewsItemListDataTemplate : UserControl
    {
        private List<NewsItem> news = new List<NewsItem>();
        public NewsItemListDataTemplate()
        {
            this.InitializeComponent();
        }

        public List<NewsItem> News
        {
            get
            {
                return this.news;
            }
            set
            {
                this.news = value;
            }
        }
    }
}
