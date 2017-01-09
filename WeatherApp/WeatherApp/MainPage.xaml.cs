// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainPage.xaml.cs" company="PresianDanailov">
//   sdf
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WeatherApp
{
    using System;

    using Windows.UI.Notifications;

    using WeatherApp.Factories;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Imaging;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
            this.SetWeatherData();
        }

        /// <summary>
        /// The weather button click async.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// when location is not available
        /// </exception>
        private async void SetWeatherData()
        {
            var weatherObject = await WeatherFactory.GetWeatherAsync();

            // Original
            // var imgSrcPattern = "http://openweathermap.org/img/w/{0}.png";
            var imgSrcPattern = "ms-appx:///Assets/Weather/{0}.png";
            var imgSrc = string.Format(imgSrcPattern, weatherObject.Weather[0].Icon);
            this.WeatherIcon.Source = new BitmapImage(new Uri(imgSrc));
            var resultTextFromat = "{0}/{1}/{2}";
            this.WeatherText.Text = string.Format(
                resultTextFromat,
                weatherObject.Name,
                ((int)weatherObject.MainWeather.Temperature).ToString(),
                weatherObject.Weather[0].Description);
            var latitude = weatherObject.Coordinates.Latitude;
            var longitude = weatherObject.Coordinates.Longitude;

            var uri = string.Format($"http://localhost:53570/weather?lat={latitude}&lon={longitude}");
            var titleContent = new Uri(uri);
            var interval = PeriodicUpdateRecurrence.HalfHour;
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.StartPeriodicUpdate(titleContent, interval);
        }
    }
}
