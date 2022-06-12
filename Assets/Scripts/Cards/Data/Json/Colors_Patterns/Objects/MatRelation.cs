using System;
using Newtonsoft.Json;

namespace Data.Json.Colors_Patterns.Objects
{
    public class MatRelation
    {
        [JsonProperty(PropertyName = "typ")]
        public string _gndNum { get; set; }

        [JsonProperty(PropertyName = "term")]
        public string _termNum { get; set; }
    }
}