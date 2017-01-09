// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeatherController.cs" company="PresianDanailov">
//   Null
// </copyright>
// <summary>
//   Defines the WeatherController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WeatherServiece.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using WeatherServiece.Factories;

    /// <summary>
    /// The weather controller.
    /// </summary>
    public class WeatherController : Controller
    {
        /// <summary>
        /// The index.
        /// </summary>
        /// <param name="lat">
        /// The lat.
        /// </param>
        /// <param name="lon">
        /// The lon.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public async Task<ActionResult> Index(double lat, double lon)
        {
            var latitude = $"{lat:f2}";
            var longitude = $"{lon:f2}";
            var weatherObject = await WeatherFactory.GetWeatherAsync(latitude, longitude);
            this.ViewBag.Temp = weatherObject.MainWeather.Temperature;
            this.ViewBag.Description = weatherObject.Weather[0].Description;
            this.ViewBag.Name = weatherObject.Name;
            this.ViewBag.Now = DateTime.Now.ToShortTimeString();
            return this.View();
        }
    }
}
