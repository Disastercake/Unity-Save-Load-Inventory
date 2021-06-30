using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ListItemButton : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI _nameComp = null;
    [SerializeField]
    private TMPro.TextMeshProUGUI _descriptionComp = null;

    public ItemData _ItemData { get; private set; } = null;

    public void SetItem(ItemData item)
    {
        _ItemData = item;

        _nameComp.text = item != null ? item.Name : "EMPTY";
        _descriptionComp.text = item != null ? item.Description : "No description...";

        gameObject.SetActive(item != null);
    }
}
