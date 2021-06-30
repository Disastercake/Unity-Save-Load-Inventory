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

    private void InitializeCommands()
    {
        ItemDatabase.LoadItemDatabase();
    }

    public GameSaveData _GameSaveData { get; private set; } = new GameSaveData();
    public void SetGameSaveData(GameSaveData data)
    {
        _GameSaveData = null;
    }
}
