using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemDatabase
{
    private static Dictionary<string, ItemData> _database = new Dictionary<string, ItemData>();

    public static bool TryGet(string id, out ItemData item)
    {
        return _database.TryGetValue(id, out item);
    }

    /// <summary>
    /// Clears current ItemDatabase and loads item list.
    /// </summary>
    public static void LoadItemDatabase()
    {
        string id;

        id = "potion01";
        _database.Add(id, new ItemData(id, "Red Potion", "A potion bubbling with red liquid."));

        id = "potion02";
        _database.Add(id, new ItemData(id, "Blue Potion", "A blue liquid with the smell of blueberries."));

        id = "potion03";
        _database.Add(id, new ItemData(id, "Purple Potion", "A purple concotion with a bitter taste."));
    }
}
