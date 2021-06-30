using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ItemShop : MonoBehaviour
{
    [SerializeField]
    private ItemScrollView _ItemScrollView = null;

    private List<ItemData> _itemList = null;

    private void OnEnable()
    {
        try { Messenger.AddListener(Messages.GameLoaded, OnGameLoad); } catch { }
    }

    private void OnDisable()
    {
        try { Messenger.RemoveListener(Messages.GameLoaded, OnGameLoad); } catch { }
    }

    private void OnDestroy()
    {
        try { Messenger.RemoveListener(Messages.GameLoaded, OnGameLoad); } catch { }
    }

    private void OnGameLoad()
    {

    }

    public void SetList(List<ItemData> itemList)
    {
        _itemList = itemList;

        _ItemScrollView.SetList(_itemList);
    }
}
