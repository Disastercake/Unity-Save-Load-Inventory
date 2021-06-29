using System.Collections.Generic;

namespace SoulSaga
{
    /// <summary>
    /// All persistent game data that is saved to a savefile.
    /// For use with GameManager and FileManager.  All game logic should go through GameManager to get or set this information.
    /// </summary>
    [System.Serializable]
    public class GameData
    {
        [Newtonsoft.Json.JsonProperty]
        public string PlayerName = string.Empty;

        [Newtonsoft.Json.JsonProperty]
        public Dictionary<int, int> PlayerInventory = new Dictionary<int, int>();

        [Newtonsoft.Json.JsonProperty]
        public int PlayerGold = 0;
    }
}
