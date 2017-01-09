using System.Runtime.Serialization;

namespace WeatherServiece.Models
{
    [DataContract]
    public class Sys
    {
        [DataMember(Name = "country")]
        public string Country { get; set; }

        [DataMember(Name = "sunrise")]
        public int Sunrise { get; set; }

        [DataMember(Name = "sunset")]
        public int Sunset { get; set; }
    }
}