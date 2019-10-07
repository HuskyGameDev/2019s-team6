using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaziesMansion
{
    internal static class SaveUtility
    {
        private static string BasePath => Application.persistentDataPath;
        private const string SaveExtension = ".dat";

        /// <returns>If saving the game with the current name would overwrite other data</returns>
        public static bool NoClobber(PersistentData saveData)
            => !File.Exists(Path.Combine(BasePath, saveData.SaveName + SaveExtension));

        public static void SaveGame(PersistentData saveData)
        {
            if(null == saveData)
                throw new ArgumentNullException(nameof(saveData));
            var path = Path.Combine(BasePath, saveData.SaveName + SaveExtension);
            Debug.Log($"Saving to \"{path}\"");
            File.WriteAllText(path, encoding: Encoding.UTF8, contents: JsonUtility.ToJson(saveData));
        }

        public static PersistentData LoadSave(string path)
        {
            if(!File.Exists(path))
                throw new FileNotFoundException("Save path does not exist.", path);
            return JsonUtility.FromJson<PersistentData>(File.ReadAllText(path, Encoding.UTF8));
        }

        public static void LoadGame(PersistentData data)
        {
            PersistentData.Instance = data;
            SceneManager.LoadScene(data.CurrentLevel);
        }

        public static IEnumerable<string> GetSaveGamePaths()
            => Directory.EnumerateFiles(BasePath, $"*{SaveExtension}");
    }
}
