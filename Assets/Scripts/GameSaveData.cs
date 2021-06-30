using System.Collections.Generic;

/// <summary>
/// All persistent game data that is saved to a savefile.
/// For use with GameManager and FileManager.  All game logic should go through GameManager to get or set this information.
/// </summary>
[System.Serializable]
public class GameSaveData
{
    [Newtonsoft.Json.JsonProperty]
    public string PlayerName = string.Empty;

    [Newtonsoft.Json.JsonProperty]
    public Dictionary<string, int> PlayerInventory = new Dictionary<string, int>();

    [Newtonsoft.Json.JsonProperty]
    public int PlayerGold = 0;
}
