using System.Collections.Generic;
using Newtonsoft.Json;

namespace HeroExplorer.Models.Comic
{

    public class ComicDataContainer
    {
        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("results")]
        public List<Comic> Comics { get; set; }
    }

}