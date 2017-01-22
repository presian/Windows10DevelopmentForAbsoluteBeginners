using Newtonsoft.Json;

namespace HeroExplorer.Models.Comic
{

    public class Image
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("extension")]
        public string Extension { get; set; }
    }

}