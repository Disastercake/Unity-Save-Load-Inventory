using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListItemButton : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI _nameComp = null;
    [SerializeField]
    private TMPro.TextMeshProUGUI _descriptionComp = null;

    private ItemData _itemData = null;

    public void SetItem(ItemData item)
    {
        _itemData = item;

        _nameComp.text = item != null ? item.Name : "EMPTY";
        _descriptionComp.text = item != null ? item.Description : "No description...";

        gameObject.SetActive(item != null);
    }
}
