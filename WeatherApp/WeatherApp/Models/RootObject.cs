using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WeatherApp.Models
{
    [DataContract]
    public class RootObject
    {
        [DataMember(Name = "coord")]
        public Coordinates Coordinates { get; set; }

        [DataMember(Name = "sys")]
        public Sys Sys { get; set; }

        [DataMember(Name = "weather")]
        public List<Weather> Weather { get; set; }

        [DataMember(Name = "main")]
        public MainWeather MainWeather { get; set; }

        [DataMember(Name = "wind")]
        public Wind Wind { get; set; }

        [DataMember(Name = "rain")]
        public Rain Rain { get; set; }

        [DataMember(Name = "clouds")]
        public Clouds Clouds { get; set; }

        [DataMember(Name = "dt")]
        public int Timestamp { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "cod")]
        public int Cod { get; set; }
    }
}