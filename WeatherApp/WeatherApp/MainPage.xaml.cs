using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using WeatherApp.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WeatherApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void WeatherButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            var access = await Geolocator.RequestAccessAsync();
//            if (access == GeolocationAccessStatus.Denied)
//            {
//                throw new ArgumentException("Location service is not avaible!");
//            }

            var locator =  new Geolocator();
            var location = await locator.GetGeopositionAsync();
            
            if (location.Coordinate != null)
            {
                var http = new HttpClient();

                var pattern = "http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&units=metric&APPID={2}";
                var latitude = location.Coordinate.Point.Position.Latitude;
                var longitude = location.Coordinate.Point.Position.Longitude;
                var apiKey = "5d5fea655547814ec89883e0d4337475";

                var requestUri =string.Format(pattern, latitude, longitude, apiKey);
                var apiResponse = await http.GetStreamAsync(requestUri);
                var apiRes = http.GetAsync(requestUri).Result.Content.ReadAsStringAsync();
                var jsonWorker = new DataContractJsonSerializer(typeof(RootObject));
                var weatherObject = (RootObject)jsonWorker.ReadObject(apiResponse);
                var a = weatherObject;

                var imgSrcPattern = "http://openweathermap.org/img/w/{0}.png";
                var imgSrc = string.Format(imgSrcPattern, weatherObject.Weather[0].Icon);
                this.WeatherIcon.Source = new BitmapImage(new Uri(imgSrc));
            }
        }
    }
}
