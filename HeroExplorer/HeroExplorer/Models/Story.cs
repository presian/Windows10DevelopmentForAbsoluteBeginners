using Newtonsoft.Json;

namespace HeroExplorer.Models
{

    public class Story
    {
        [JsonProperty("resourceURI")]
        public string ResourceUri{ get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

}