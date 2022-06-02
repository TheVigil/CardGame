using Newtonsoft.Json;
using System.Collections.Generic;

namespace Data.Json.Colors_Patterns.Objects
{
    public class JsonRoot
    {
        [JsonProperty(PropertyName = "output-parameters")]
        public List<OutputParameter> _out { get; set; }
    }
}