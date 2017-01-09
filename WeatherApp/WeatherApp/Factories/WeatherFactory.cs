// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeatherFactory.cs" company="PresianDanailov">
//   Null
// </copyright>
// <summary>
//   The weather factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WeatherApp.Factories
{
    using System;
    using System.Net.Http;
    using System.Runtime.Serialization.Json;
    using System.Threading.Tasks;

    using Windows.Devices.Geolocation;

    using WeatherApp.Models;

    /// <summary>
    /// The weather factory.
    /// </summary>
    public static class WeatherFactory
    {
        /// <summary>
        /// The get weather.
        /// </summary>
        /// <returns>
        /// The <see cref="RootObject"/>.
        /// </returns>
        public static async Task<RootObject> GetWeatherAsync()
        {
            var access = await Geolocator.RequestAccessAsync();
            if (access == GeolocationAccessStatus.Denied)
            {
                throw new ArgumentException("Location service is not available!");
            }

            var locator = new Geolocator();
            var location = await locator.GetGeopositionAsync();

            if (location.Coordinate == null)
            {
                throw new ArgumentNullException($"Coordinate", "Location coordinates are not available!");
            }

            var http = new HttpClient();

            var pattern = "http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&units=metric&APPID={2}";
            var latitude = location.Coordinate.Point.Position.Latitude;
            var longitude = location.Coordinate.Point.Position.Longitude;
            var apiKey = "5d5fea655547814ec89883e0d4337475";

            var requestUri = string.Format(pattern, latitude, longitude, apiKey);
            var apiResponse = await http.GetStreamAsync(requestUri);
            var apiRes = http.GetAsync(requestUri)
                .Result.Content.ReadAsStringAsync();
            var jsonWorker = new DataContractJsonSerializer(typeof(RootObject));
            var weatherObject = (RootObject)jsonWorker.ReadObject(apiResponse);

            return weatherObject;
        }
    }
}