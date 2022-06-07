using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Data.Json.Colors_Patterns.Objects
{
    public class JMaterial
    {
        [JsonProperty(PropertyName = "term")]
        public string _term { get; set; }

        [JsonProperty(PropertyName = "related")]
        public List<MatRelation> _related { get; set; }
    }
}