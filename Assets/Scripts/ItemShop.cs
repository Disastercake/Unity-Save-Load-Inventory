using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ItemShop : MonoBehaviour
{
    [SerializeField]
    private ItemScrollView _ItemScrollView = null;

    private ItemGroup _itemList = null;

    private void Awake()
    {
        _ItemScrollView.OnButtonClick += new ItemScrollView.OnClickHandler(OnButtonClick);
    }

    private void OnButtonClick(ListItemButton button)
    {
        GameManager.PlayerInventory.Add(button.Id, 1);
        _itemList.Remove(button.Id, 1);
    }

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

        SetList(items);
    }

    private void SetList(ItemGroup itemList)
    {
        _itemList = itemList;

        _ItemScrollView.SetList(itemList);
    }
}
