using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Data.Json.Colors_Patterns.Objects;
using Data.Objects;
using Utils;

public class Program
{
    public static void Main(string[] args)
    {
        /*string json_config_path = "data/json/colors_patterns/config/config.json";
        string jsonConfigString = File.ReadAllText(json_config_path, System.Text.Encoding.Default);

        string json_data_path = "data/json/colors_patterns/raw/sgs_codingDaVinci_20220329.json";
        string jsonDataString = File.ReadAllText(json_data_path, System.Text.Encoding.Default);

        ConfigRoot jConfigColPat = JsonConvert.DeserializeObject<ConfigRoot>(jsonConfigString);
        JsonRoot jRootColPat = JsonConvert.DeserializeObject<JsonRoot>(jsonDataString);

        List<ItemCard> itemCards = new List<ItemCard>();

        for (int i = 0; i < jConfigColPat._out[0]._guids.Count; i++)
        {
            string currGuid = jConfigColPat._out[0]._guids[i];
            foreach (OutputParameter outParam in jRootColPat._out)
            {
                if (outParam._guid == currGuid)
                {
                    itemCards.Add(new ItemCard(outParam, jConfigColPat._out[0]._savePath));
                    break;
                }
            }
        }

        Console.WriteLine("t");*/
    }
}