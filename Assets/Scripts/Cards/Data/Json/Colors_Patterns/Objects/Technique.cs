using System;
using Newtonsoft.Json;

namespace Data.Json.Colors_Patterns.Objects
{
    public class Technique
    {
        [JsonProperty(PropertyName = "term")]
        public string _term { get; set; }
    }
}