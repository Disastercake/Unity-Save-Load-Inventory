using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ButtonLoadGame : MonoBehaviour
{
    public void OnClick()
    {
        GameSaveData data = null;

        if (FileManager.TryLoad(out data))
        {
            GameManager.Instance.SetGameSaveData(data);
            Debug.Log("Load SUCCESS.");
            try { Messenger.Broadcast(Messages.GameLoaded); } catch { }
        }
        else
        {
            Debug.Log("Load FAIL.");
        }
    }
}
