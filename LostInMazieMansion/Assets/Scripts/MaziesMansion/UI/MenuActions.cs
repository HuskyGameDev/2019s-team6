using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaziesMansion
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Menu Actions")]
    internal sealed class MenuActions : ScriptableObject
    {
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

        public void QuitGame()
        {
            Debug.Log("Quitting");
            Application.Quit();
        }
    }
}
