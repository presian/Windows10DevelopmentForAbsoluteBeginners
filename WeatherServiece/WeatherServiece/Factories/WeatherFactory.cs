// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeatherFactory.cs" company="PresianDanailov">
//   Null
// </copyright>
// <summary>
//   The weather factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WeatherServiece.Factories
{
    using System.Net.Http;
    using System.Runtime.Serialization.Json;
    using System.Threading.Tasks;

    using WeatherServiece.Models;

    /// <summary>
    /// The weather factory.
    /// </summary>
    public static class WeatherFactory
    {
        /// <summary>
        /// The get weather.
        /// </summary>
        /// <param name="latitude">
        /// The latitude.
        /// </param>
        /// <param name="longitude">
        /// The longitude.
        /// </param>
        /// <returns>
        /// The <see cref="RootObject"/>.
        /// </returns>
        public static async Task<RootObject> GetWeatherAsync(string latitude, string longitude)
        {
            var http = new HttpClient();

            var pattern = "http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&units=metric&APPID={2}";
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