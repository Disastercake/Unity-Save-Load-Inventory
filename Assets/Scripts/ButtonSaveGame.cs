using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ButtonSaveGame : MonoBehaviour
{
    public void OnClick()
    {
        if (FileManager.TrySave(GameManager.Instance.GetGameSaveData()))
        {
            Debug.Log("Save SUCCESS.");
            try { Messenger.Broadcast(Messages.GameSaved); } catch { }
        }
        else
        {
            Debug.Log("Save FAIL.");
        }
    }
}
