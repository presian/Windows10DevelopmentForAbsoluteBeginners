using System.Collections.Generic;
using Newtonsoft.Json;

namespace HeroExplorer.Models
{

    public class CharacterDataContainer
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
        public List<Character> Results { get; set; }
    }

}