using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Data.Json.Colors_Patterns.Objects
{
    public class ConfigRoot
    {
        [JsonProperty(PropertyName = "config-params")]
        public List<ConfigParameter> _out { get; set; }
    }
}