using UnityEngine;

namespace MaziesMansion
{
    /// <summary>Tracks the game state within a single level</summary>
    internal sealed class LevelState : MonoBehaviour
    {
        // TODO: track game state

        public GameObject PauseInterface;

        private bool _isGamePaused = false;
        public bool IsGamePaused
        {
            get => _isGamePaused;
            set
            {
                _isGamePaused = value;
                PauseInterface.SetActive(_isGamePaused);
                if(_isGamePaused)
                {
                    // pause
                    Time.timeScale = 0;
                    Debug.Log("Pause");
                } else
                {
                    // resume
                    if(!Inventory.IsInvOpen)
                    {
                        Time.timeScale = 1;
                    }
                    Debug.Log("Resume");
                }
            }
        }

        private void Update()
        {
            // toggle pausing while the game is running
            if(Input.GetKeyDown(KeyCode.Escape))
                IsGamePaused = !IsGamePaused;
        }
    }
}
