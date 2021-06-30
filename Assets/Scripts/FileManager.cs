using System.IO;
using System.Xml;

/// <summary>
/// The File Manager deals with the saving and loading of game files.
/// </summary>
public static class FileManager
{
    #region Private

    private const string SAVE_FILE_NAME = "savefile";

    private static string SaveDirectoryPath()
    {
        var path = ReplaceBackslashWithSeparator(UnityEngine.Application.persistentDataPath);
        return path;
    }

    /// <summary>
    /// The entire path for the save file.
    /// Convenience method for: Path.Combine(SaveDirectoryPath, SAVE_FILE_NAME);
    /// </summary>
    private static string SaveFilePath()
    {
        var path = Path.Combine(SaveDirectoryPath(), SAVE_FILE_NAME);
        return path;
    }

    /// <summary>
    /// For some reason the persistent data path does not have the correct path separator.
    /// This fixes that.
    /// </summary>
    private static string ReplaceBackslashWithSeparator(string path)
    {
        path = path.Replace('/', Path.DirectorySeparatorChar);
        return path;
    }

    private static void HandleDirectory()
    {
        var path = SaveDirectoryPath();

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
    }

    private static bool SaveFileDirectoryExists()
    {
        bool success = true;

        try
        {
            if (!Directory.Exists(SaveDirectoryPath()))
            {
                //if it doesn't, create it
                Directory.CreateDirectory(SaveDirectoryPath());

                success = true;
            }
        }
        catch (System.Exception e)
        {
            if (UnityEngine.Debug.isDebugBuild) { UnityEngine.Debug.LogError(e); }

            success = false;
        }

        return success;
    }

    private static bool SaveFileExists()
    {
        bool exists = true;

        try
        {
            var fullPath = Path.Combine(SaveDirectoryPath(), SAVE_FILE_NAME);
            exists = File.Exists(fullPath);
        }
        catch (System.Exception e)
        {
            if (UnityEngine.Debug.isDebugBuild) { UnityEngine.Debug.LogError(e); }
            exists = false;
        }

        return exists;
    }

    private static string SerializeWithJson<T>(T o)
    {
        string serialized = string.Empty;

        //Newtonsoft.Json.Formatting formatting = new Newtonsoft.Json.Formatting();

        //Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings();
        //settings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All;

        serialized = Newtonsoft.Json.JsonConvert.SerializeObject(o, Newtonsoft.Json.Formatting.None, new Newtonsoft.Json.JsonSerializerSettings
        {
            TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All
        });

        return serialized;
    }

    #endregion

    #region Public

    /// <summary>
    /// Saves the settings file.
    /// Saves this before anything else.
    /// </summary>
    public static bool TrySave(GameSaveData saveData)
    {
        if (saveData == null) return false;

        try
        {
            HandleDirectory();

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(saveData, Newtonsoft.Json.Formatting.None);

            var writer = new StreamWriter(SaveFilePath(), false);
            writer.WriteLine(json);
            writer.Close();
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.LogError(e);
            return false;
        }

        return true;
    }

    /// <summary>
    /// Saves the settings file.
    /// Saves this before anything else.
    /// </summary>
    public static bool TryLoad(out GameSaveData gameData)
    {
        gameData = null;
        if (!SaveFileExists()) return false;
        
        var settings = new Newtonsoft.Json.JsonSerializerSettings { TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All, Formatting = Newtonsoft.Json.Formatting.None };

        var loadedString = File.ReadAllText(Path.Combine(SaveDirectoryPath(), SAVE_FILE_NAME));

        gameData = Newtonsoft.Json.JsonConvert.DeserializeObject<GameSaveData>(loadedString, settings);

        return gameData == null;
    }

    #endregion
}
