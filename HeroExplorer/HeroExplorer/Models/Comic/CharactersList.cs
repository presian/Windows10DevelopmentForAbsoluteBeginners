﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace HeroExplorer.Models.Comic
{

    public class CharactersList
    {
        [JsonProperty("available")]
        public int Available { get; set; }

        [JsonProperty("collectionURI")]
        public string CollectionUri { get; set; }

        [JsonProperty("items")]
        public List<Character> Items { get; set; }

        [JsonProperty("returned")]
        public int Returned { get; set; }
    }

}