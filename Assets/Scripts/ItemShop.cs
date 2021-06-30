using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ItemShop : MonoBehaviour
{
    [SerializeField]
    private ItemScrollView _ItemScrollView = null;

    private List<ItemData> _itemList = null;

    public void SetList(List<ItemData> itemList)
    {
        _itemList = itemList;

        _ItemScrollView.SetList(_itemList);
    }
}
