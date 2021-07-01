using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ListItemButton : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI _nameComp = null;
    [SerializeField]
    private TMPro.TextMeshProUGUI _descriptionComp = null;

    public delegate void OnClickHandler(ListItemButton button);
    public OnClickHandler OnClick;

    public ItemData _ItemData { get; private set; } = null;
    public int Quantity { get; private set; } = 0;
    public string Id { get; private set; } = string.Empty;

    public void SetItem(string id, int quantity)
    {
        if (string.IsNullOrEmpty(id))
        {
            Reset();
            return;
        }

        Id = id;

        ItemData itemdata = null;

        if (ItemDatabase.TryGet(id, out itemdata))
            _ItemData = itemdata;

        if (itemdata != null)
        {
            Quantity = quantity;
            _nameComp.text = string.Format("{0} x{1}", _ItemData.Name, quantity);
            _descriptionComp.text = _ItemData.Description;
        }
        else
        {
            Reset();
        }

        gameObject.SetActive(_ItemData != null);
    }

    public void Reset()
    {
        Quantity = 0;
        Id = string.Empty;
        _ItemData = null;

        _nameComp.text = "EMPTY";
        _descriptionComp.text = "No item...";
    }

    public void _OnClick()
    {
        OnClick?.Invoke(this);
    }
}
