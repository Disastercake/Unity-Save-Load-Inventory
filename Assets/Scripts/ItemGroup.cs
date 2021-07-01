using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Newtonsoft.Json.JsonObject]
/// <summary>
/// A group of items and their quantities.
/// </summary>
public class ItemGroup
{
    public delegate void EventHandler();
    /// <summary>
    /// Broadcast when changed.
    /// </summary>
    public event EventHandler OnChange;

    [Newtonsoft.Json.JsonProperty]
    public Dictionary<string, int> Group { get; private set; } = new Dictionary<string, int>();

    public ItemGroup() { }

    public int ItemTypeCount()
    {
        return Group.Count;
    }

    public int TotelItemCount()
    {
        int count = 0;

        foreach (var item in Group)
            count += item.Value;

        return count;
    }

    public ItemGroup(Dictionary<string, int> group)
    {
        Set(group);
    }

    /// <summary>
    /// Overwrites the current group.  Send null to clear the group.
    /// </summary>
    public void Set(Dictionary<string, int> group)
    {
        if (group == Group) return;

        if (group != null)
        {
            Group = group;
            OnChange?.Invoke();
        }
        else
            Clear();
    }

    /// <summary>
    /// Adds the group to the current.
    /// </summary>
    public void Add(Dictionary<string, int> group)
    {
        if (group == null) return;
        if (group.Count == 0) return;

        foreach (var item in group)
        {
            int q;

            if (Group.TryGetValue(item.Key, out q))
                Group[item.Key] = q + item.Value;
            else
                Group.Add(item.Key, item.Value);
        }

        OnChange?.Invoke();
    }

    /// <summary>
    /// Removes specified amount.  Clamps to 0 if lower.
    /// </summary>
    public void Add(string id, int amount)
    {
        if (amount <= 0) return;

        int q;

        if (Group.TryGetValue(id, out q))
            Group[id] = q + amount;
        else
            Group.Add(id, amount);

        OnChange?.Invoke();
    }

    /// <summary>
    /// Removes specified amount.  Send a positive value;  Clamps to 0 if lower.
    /// </summary>
    public void Remove(string id, int amount)
    {
        if (amount <= 0) return;

        int q;

        if (Group.TryGetValue(id, out q))
        {
            if (q - amount > 0)
                Group[id] = q - amount;
            else
                Group.Remove(id);
        }

        OnChange?.Invoke();
    }

    /// <summary>
    /// Clears the group completely.
    /// </summary>
    public void Clear()
    {
        if (Group != null)
            Group.Clear();
        else
            Group = new Dictionary<string, int>();

        OnChange?.Invoke();
    }

    public List<string> GetAllItemId()
    {
        return Group.Keys.ToList();
    }
}
