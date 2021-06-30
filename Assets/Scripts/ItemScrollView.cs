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
    private List<ListItemButton> _buttonPool = new List<ListItemButton>();

    public void SetList(List<ItemData> itemList)
    {
        _itemList = itemList;
        UpdateGui();
    }

    private void UpdateGui()
    {
        if (_itemList?.Count <= 0)
        {
            HideAllButtons();
            return;
        }
        else
        {
            HideAllButtons();

            foreach (var item in _itemList)
            {
                var b = GetButton();


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
        _buttonPool.Add(button);

        return button;
    }

    private void HideAllButtons()
    {
        foreach (var b in _buttonPool)
        {
            b.SetItem(null);
        }
    }
}
