using System.Runtime.Serialization;

namespace WeatherApp.Models
{
    [DataContract(Name = "Coord")]
    public class Coordinates
    {
        [DataMember(Name = "lon")]
        public double Longitude { get; set; }

        [DataMember(Name = "lat")]
        public double Latitude { get; set; }
    }
}