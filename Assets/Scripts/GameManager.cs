using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There was more than one GameManager component in the scene.  There can only be one!  Slaying the weakest now...");
            Destroy(this); // Only destroy component in case the GameObject it's attached to is important.
        }

        InitializeCommands();
    }

    private void Start()
    {
        try { Messenger.Broadcast(Messages.ShopChanged); } catch { }
    }

    private void InitializeCommands()
    {
        ItemDatabase.LoadItemDatabase();
    }

    private GameSaveData _GameSaveData = new GameSaveData();
    public void SetGameSaveData(GameSaveData data)
    {
        _GameSaveData = data;
    }

    public GameSaveData GetGameSaveData()
    {
        return _GameSaveData;
    }

    public static class PlayerInventory
    {
        public static void Add(string id, int quantity)
        {
            Instance._GameSaveData.PlayerInventory.Add(id, quantity);
            try { Messenger.Broadcast(Messages.PlayerInventoryChanged); } catch { }
        }

        public static void Remove(string id, int quantity)
        {
            Instance._GameSaveData.PlayerInventory.Remove(id, quantity);
            try { Messenger.Broadcast(Messages.PlayerInventoryChanged); } catch { }
        }
    }
}
