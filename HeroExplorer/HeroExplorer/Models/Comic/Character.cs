using Newtonsoft.Json;

namespace HeroExplorer.Models.Comic
{

    public class Character
    {
        [JsonProperty("resourceURI")]
        public string ResourceUri { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

}