using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Newtonsoft.Json.JsonObject]
public class ItemData
{
    public string Id { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;

    public ItemData(string id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
}
