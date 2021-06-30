using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ItemShop : MonoBehaviour
{
    [SerializeField]
    private ItemScrollView _ItemScrollView = null;

    private Dictionary<ItemData, int> _itemList = null;

    private void OnEnable()
    {
        try { Messenger.AddListener(Messages.ShopChanged, OnShopChange); } catch { }
    }

    private void OnDisable()
    {
        try { Messenger.RemoveListener(Messages.ShopChanged, OnShopChange); } catch { }
    }

    private void OnDestroy()
    {
        try { Messenger.RemoveListener(Messages.ShopChanged, OnShopChange); } catch { }
    }

    private void OnShopChange()
    {
        var items = ItemDatabase.GetRandomItems(20);


    }

    private void SetList(Dictionary<ItemData, int> itemList)
    {
        _itemList = itemList;

        _ItemScrollView.SetList(_itemList);
    }



}
