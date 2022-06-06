using System;
using Newtonsoft.Json;

namespace Data.Json.Colors_Patterns.Objects
{
    public class Dimensions
    {
        [JsonProperty(PropertyName = "teil")]
        public string _part { get; set; }

        [JsonProperty(PropertyName = "typ")]
        public string _width_height { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string _dim_value { get; set; }

        [JsonProperty(PropertyName = "unit")]
        public string _unit { get; set; }
    }
}