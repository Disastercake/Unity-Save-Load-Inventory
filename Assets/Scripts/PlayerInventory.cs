using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private ItemScrollView _ItemScrollView = null;

    private ItemGroup _itemList = null;

    private void Awake()
    {
        _ItemScrollView.OnButtonClick += new ItemScrollView.OnClickHandler(OnButtonClick);
    }

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

    private void OnButtonClick(ListItemButton button)
    {
        GameManager.PlayerInventory.Remove(button.Id, 1);
    }

    private void UpdatePlayerInventory()
    {
        var inventory = GameManager.Instance.GetGameSaveData().PlayerInventory;

        SetList(inventory);
    }

    private void SetList(ItemGroup itemList)
    {
        _itemList = itemList;

        _ItemScrollView.SetList(itemList);
    }
}
