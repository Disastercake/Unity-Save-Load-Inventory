using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private ItemScrollView _ItemScrollView = null;

    private List<ItemData> _itemList = null;

    private void OnEnable()
    {
        try { Messenger.AddListener(Messages.GameLoaded, UpdatePlayerInventory); } catch { }
        try { Messenger.AddListener(Messages.PlayerInventoryChanged, UpdatePlayerInventory); } catch { }
    }

    private void OnDisable()
    {
        try { Messenger.RemoveListener(Messages.GameLoaded, UpdatePlayerInventory); } catch { }
        try { Messenger.RemoveListener(Messages.PlayerInventoryChanged, UpdatePlayerInventory); } catch { }
    }

    private void OnDestroy()
    {
        try { Messenger.RemoveListener(Messages.GameLoaded, UpdatePlayerInventory); } catch { }
        try { Messenger.RemoveListener(Messages.PlayerInventoryChanged, UpdatePlayerInventory); } catch { }
    }

    private void UpdatePlayerInventory()
    {
        var inventory = GameManager.Instance._GameSaveData.PlayerInventory;

        //for (int i = 0; i < length; i++)
        //{

        //}
    }

    private void SetList(List<ItemData> itemList)
    {
        _itemList = itemList;

        //_ItemScrollView.SetList(_itemList);
    }



}
