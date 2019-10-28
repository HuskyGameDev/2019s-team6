using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;
using UnityEngine.UI;

namespace MaziesMansion
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Menu Actions")]
    internal sealed class MenuActions : ScriptableObject
    {
        public void NewGame()
        {
            SaveUtility.LoadGame(PersistentData.Default);
        }

        public void LoadTargetScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }

        /// <summary>Changes the quality of the game based on the argument given in the drop down tab.</summary>
        public void SetQuality (int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }

        /// <summary>Toggles fullscreen.</summmary>
        public void SetFullscreen (bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
        }

        public float Volume
        {
            get
            {
                var masterBus = RuntimeManager.GetBus("/");
                masterBus.getVolume(out var volume);
                return volume;
            }
            set
            {
                var masterBus = RuntimeManager.GetBus("/");
                masterBus.setVolume(value);
            }
        }

        public void SetVolume (Slider slider)
        {
            Volume = slider.value;
        }

        public void QuitGame()
        {
            Debug.Log("Quitting");
            Application.Quit();
        }
    }
}
