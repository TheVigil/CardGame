using System.IO;
using System.Collections;
using System.Collections.Generic;
using Data.Json.Colors_Patterns.Objects;
using Newtonsoft.Json;
using UnityEngine;

namespace Data.Json.Deserializer
{
    [CreateAssetMenu(fileName = "New Deserializer", menuName = "Deserializer")]
    public class JDeserializer : ScriptableObject
    {
        public string _json_path = "";

        public T Root<T>()
        {
            string jString = File.ReadAllText(_json_path, System.Text.Encoding.Default);
            T jRoot = JsonConvert.DeserializeObject<T>(jString);

            return jRoot;
        }
    }
}
