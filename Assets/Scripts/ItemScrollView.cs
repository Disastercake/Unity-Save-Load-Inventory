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

    private ItemGroup _itemList = null;
    private List<ListItemButton> _buttonPool = new List<ListItemButton>();

    public delegate void OnClickHandler(ListItemButton button);
    public OnClickHandler OnButtonClick;

    public void SetList(ItemGroup itemList)
    {
        if (_itemList == itemList) return; // If no change, do nothing.

        if (_itemList != null)
            _itemList.OnChange -= UpdateGui; // Unsubscribe from the current.

        _itemList = itemList; // Set new.
        
        if (_itemList != null)
            _itemList.OnChange += new ItemGroup.EventHandler(UpdateGui); // Subscribe to the new.
        
        UpdateGui();
    }

    private void UpdateGui()
    {
        if (_itemList == null)
        {
            HideAllButtons();
            return;
        }
        else if (_itemList.ItemTypeCount() <= 0)
        {
            HideAllButtons();
            return;
        }
        else
        {
            HideAllButtons();

            foreach (var item in _itemList.Group)
            {
                var b = GetButton();
                b.SetItem(item.Key, item.Value);
            }
        }
    }

    private ListItemButton GetButton()
    {
        foreach (var b in _buttonPool)
        {
            if (b._ItemData == null)
                return b;
        }

        var button = Instantiate(_buttonPrefab, _contentParent);
        button.OnClick += new ListItemButton.OnClickHandler(ButtonClicked);
        _buttonPool.Add(button);

        return button;
    }

    private void ButtonClicked(ListItemButton button)
    {
        OnButtonClick?.Invoke(button);
    }

    private void HideAllButtons()
    {
        foreach (var b in _buttonPool)
        {
            b.SetItem(null, 0);
            b.gameObject.SetActive(false);
        }
    }
}
