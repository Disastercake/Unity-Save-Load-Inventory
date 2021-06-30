using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ItemScrollView : MonoBehaviour
{
    [SerializeField]
    private ListItemButton _buttonPrefab = null;

    [SerializeField]
    private Transform _contentParent = null;

    private List<ItemData> _itemList = null;
    private List<ListItemButton> _buttonPool = null;

    public void SetList(List<ItemData> itemList)
    {
        _itemList = itemList;


    }
}
