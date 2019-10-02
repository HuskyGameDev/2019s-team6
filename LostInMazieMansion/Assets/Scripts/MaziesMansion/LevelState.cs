using UnityEngine;

namespace MaziesMansion
{
    /// <summary>Tracks the game state within a single level</summary>
    internal sealed class LevelState : MonoBehaviour
    {
        // TODO: track game state

        public GameObject PauseInterface = null;
        public GameObject InventoryInterface = null;

        private bool _isGamePaused = false;
        private bool _isInventoryOpen = false;
        public bool IsGamePaused
        {
            get => _isGamePaused;
            set
            {
                _isGamePaused = value;
                PauseInterface.SetActive(_isGamePaused);
                if(_isGamePaused)
                    Time.timeScale = 0;
                else if(!IsInventoryOpen)
                    Time.timeScale = 1;
            }
        }

        public bool IsInventoryOpen
        {
            get => _isInventoryOpen;
            set
            {
                _isInventoryOpen = value;
                InventoryInterface.SetActive(_isInventoryOpen);
                Time.timeScale = _isInventoryOpen ? 0 : 1;
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
            if(Input.GetKeyDown(KeyCode.Tab) && !IsGamePaused)
                IsInventoryOpen = !IsInventoryOpen;
        }
    }
}
