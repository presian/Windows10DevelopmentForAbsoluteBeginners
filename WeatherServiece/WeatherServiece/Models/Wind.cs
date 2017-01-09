using System.Runtime.Serialization;

namespace WeatherServiece.Models
{
    [DataContract]
    public class Wind
    {
        [DataMember(Name = "speed")]
        public double Speed { get; set; }
        
        [DataMember(Name = "deg")]
        public double Degrees{ get; set; }
    }
}