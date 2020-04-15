using System;
using System.IO;
using System.Text;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaziesMansion
{
    internal static class SaveUtility
    {
        private static string BasePath => Application.persistentDataPath;
        private const string SaveExtension = ".dat";
        private const int ImageSize = 256;

        /// <returns>If saving the game with the current name would overwrite other data</returns>
        public static bool NoClobber(PersistentData saveData)
            => !File.Exists(Path.Combine(BasePath, saveData.SaveData.Slot.ToString() + SaveExtension));

        public static void SaveGame(PersistentData saveData)
        {
            if(null == saveData)
                throw new ArgumentNullException(nameof(saveData));
            if(saveData.SaveData.Slot == SaveSlot.Temporary)
            {
                // TODO: find an open slot or complain?
                Debug.LogWarning("Attempted to save to the Temporary slot.", saveData);
                return;
            }
            var path = Path.Combine(BasePath, saveData.SaveData.Slot.ToString() + SaveExtension);
            Debug.Log($"Saving to \"{path}\"");
            saveData.SaveData.ImageInformation = GenerateSaveTexture();
            File.WriteAllText(path, encoding: Encoding.UTF8, contents: JsonUtility.ToJson(saveData));
        }

        public static PersistentData LoadSave(SaveSlot slot)
        {
            var path = GetSaveGamePath(slot);
            if(!File.Exists(path))
                throw new FileNotFoundException("Save path does not exist.", path);
            var data = ScriptableObject.CreateInstance<PersistentData>();
            JsonUtility.FromJsonOverwrite(File.ReadAllText(path, Encoding.UTF8), data);
            Hydrate(data);
            return data;
        }

        public static bool TryLoadSave(SaveSlot slot, out PersistentData data)
        {
            data = null;
            var path = GetSaveGamePath(slot);
            if(!File.Exists(path))
                return false;
            data = ScriptableObject.CreateInstance<PersistentData>();
            JsonUtility.FromJsonOverwrite(File.ReadAllText(path, Encoding.UTF8), data);
            Hydrate(data);
            return true;
        }

        private static void Hydrate(PersistentData data)
        {
            if(null != data.SaveData.ImageInformation)
            {
                var bytes = Encoding.UTF8.GetBytes(data.SaveData.ImageInformation);
                var texture = new Texture2D(ImageSize, ImageSize);
                texture.LoadRawTextureData(bytes);
                texture.Apply();
                Debug.Log(texture.width);
                data.SaveData.Image = Sprite.Create(texture, new Rect(0, 0, ImageSize, ImageSize), new Vector2(0.5f, 0.5f));
            }
        }

        public static void LoadGame(PersistentData data)
        {
            PersistentData.Instance = data;
            data.Volatile.JustLoadedGame = true;
            SceneManager.LoadScene(data.CurrentLevel);
        }

        public static string GetSaveGamePath(SaveSlot slot)
            => Path.Combine(BasePath, slot.ToString() + SaveExtension);

        public static string GenerateSaveTexture()
        {
            var screenTexture = ScreenCapture.CaptureScreenshotAsTexture();
            var isLandscape = screenTexture.height < screenTexture.width;
            var y0 = isLandscape ? 0 : (screenTexture.height - screenTexture.width / 2);
            var x0 = isLandscape ? (screenTexture.width - screenTexture.height) / 2 : 0;
            var dimension = isLandscape ? screenTexture.height : screenTexture.width;

            var pixels = screenTexture.GetPixels(x0, y0, dimension, dimension);
            var texture = new Texture2D(dimension, dimension);
            texture.SetPixels(pixels);
            texture.Resize(ImageSize, ImageSize);
            texture.Apply();

            var bytes = texture.GetRawTextureData();
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
