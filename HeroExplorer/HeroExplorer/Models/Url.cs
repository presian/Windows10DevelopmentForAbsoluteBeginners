using Newtonsoft.Json;

namespace HeroExplorer.Models
{

    public class Url
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string UrlString { get; set; }
    }

}