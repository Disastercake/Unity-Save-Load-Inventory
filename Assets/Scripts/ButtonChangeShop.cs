using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ButtonChangeShop : MonoBehaviour
{
    public void OnClick()
    {
        try { Messenger.Broadcast(Messages.ShopChanged); } catch { }
    }
}
