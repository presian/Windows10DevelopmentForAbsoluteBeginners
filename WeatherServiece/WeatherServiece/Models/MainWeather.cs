using System.Runtime.Serialization;

namespace WeatherServiece.Models
{
    [DataContract(Name = "Main")]
    public class MainWeather
    {
        [DataMember(Name = "temp")]
        public double Temperature { get; set; }

        [DataMember(Name = "humidity")]
        public int Humidity { get; set; }

        [DataMember(Name = "pressure")]
        public int Pressure { get; set; }

        [DataMember(Name = "temp_min")]
        public double MinimalTemperature { get; set; }

        [DataMember(Name = "temp_max")]
        public double MaximalTemperature { get; set; }
    }
}