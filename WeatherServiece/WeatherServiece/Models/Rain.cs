using System.Runtime.Serialization;

namespace WeatherServiece.Models
{
    [DataContract]
    public class Rain
    {
        [DataMember(Name = "3h")]
        public int ThreeHours { get; set; }
    }
}