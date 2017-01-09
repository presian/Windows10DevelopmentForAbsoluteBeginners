// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Clouds.cs" company="">
//   
// </copyright>
// <summary>
//   The clouds.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace WeatherServiece.Models
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The clouds.
    /// </summary>
    [DataContract(Name = "Clouds")]
    public class Clouds
    {
        /// <summary>
        /// Gets or sets the all.
        /// </summary>
        [DataMember(Name = "all")]
        public int All { get; set; }
    }
}