using UnityEngine;

namespace MaziesMansion
{
    /// <summary>Tracks the game state within a single level</summary>
    internal sealed class LevelState : MonoBehaviour
    {
        // TODO: track game state

        public GameObject PauseInterface = null;

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
                    if(!global::Inventory.IsInvOpen)
                    {
                        Time.timeScale = 1;
                    }
                    Debug.Log("Resume");
                }
            }
        }

        private void Start()
        {
            var save = PersistentData.Instance;
            if(null != save.Volatile.TargetDoorName)
            {
                // the player object should be moved in front of a door.
                var targetDoor = GameObject.Find(save.Volatile.TargetDoorName);
                var player = GameObject.FindObjectOfType<Player>();
                if(null != targetDoor && null != player && targetDoor.TryGetComponent(out Door door))
                    door.Place(player.gameObject);
                save.Volatile.TargetDoorName = null;
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
