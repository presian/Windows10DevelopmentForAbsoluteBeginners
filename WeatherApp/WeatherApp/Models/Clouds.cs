using System.Runtime.Serialization;

namespace WeatherApp.Models
{
    [DataContract(Name = "Clouds")]
    public class Clouds
    {
        [DataMember(Name = "all")]
        public int All { get; set; }
    }
}