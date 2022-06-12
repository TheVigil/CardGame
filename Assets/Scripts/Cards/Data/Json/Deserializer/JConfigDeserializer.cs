using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.Json.Deserializer;
using Data.Json.Colors_Patterns.Objects;

public class JConfigDeserializer : MonoBehaviour
{
    public JDeserializer _deserializer;
    private static ConfigRoot _jConfig;

    // Start is called before the first frame update
    void Start()
    {
        _jConfig = _deserializer.Root<ConfigRoot>();
    }

    public static ConfigRoot JConfig
    {
        get { return _jConfig; }
    }
}
