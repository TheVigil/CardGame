using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.Json.Deserializer;
using Data.Json.Colors_Patterns.Objects;

public class JDataDeserializer : MonoBehaviour
{
    public JDeserializer _deserializer;
    private static JsonRoot _jData;

    // Start is called before the first frame update
    void Start()
    {
        _jData = _deserializer.Root<JsonRoot>();
    }

    public static JsonRoot JData
    {
        get { return _jData; }
    }
}
