using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaziesMansion
{
    /// <summary>Tracks the game state within a single level</summary>
    internal sealed class LevelState : MonoBehaviour
    {
        // TODO: track game state

        public GameObject MenuBackgroundInterface = null;
        public GameObject[] MenuInterfaces = new GameObject[3];
        public GameObject PauseInterface = null;
        public GameObject InventoryInterface = null;

        public GameObject InteractButton = null;

        public FadeInOut FadeInOutInterface = null;

        private Player Player = null;

        private bool _isGamePaused = false;
        private bool _isInventoryOpen = false;
        private bool _isInteractionOpen = false;

        private static int _openInterfaceCount = 0;
        public static bool IsPaused => _openInterfaceCount > 0;

        public static LevelState Instance;

        public bool IsGamePaused
        {
            get => _isGamePaused;
            set
            {
                if(_isGamePaused != value)
                    _openInterfaceCount += value ? 1 : -1;
                _isGamePaused = value;
                MenuBackgroundInterface.SetActive(_isGamePaused);
                PauseInterface.SetActive(true);
                foreach (var item in MenuInterfaces)
                    item.SetActive(false);
            }
        }

        public bool IsInventoryOpen
        {
            get => _isInventoryOpen;
            set
            {
                if(_isInventoryOpen != value)
                    _openInterfaceCount += value ? 1 : -1;
                _isInventoryOpen = value;
                InventoryInterface.SetActive(_isInventoryOpen);
            }
        }

        public bool IsInteractionOpen
        {
            get => _isInteractionOpen;
            set
            {
                Player?.StopAnimation();
                if(IsInteractionOpen != value)
                    _openInterfaceCount += value ? 1 : -1;
                _isInteractionOpen = value;
            }
        }

        private void Awake()
        {
            _openInterfaceCount = 0;
            Instance = this;
            Player = FindObjectOfType<Player>();
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
            if(save.Volatile.JustLoadedGame)
            {
                save.Volatile.JustLoadedGame = false;
                if(save.PlayerLocation.z >= 0)
                {
                    var player = GameObject.FindObjectOfType<Player>();
                    player.transform.position = save.PlayerLocation;
                }
            }
        }

        private void OnDestroy()
        {
            Instance = null;
        }

        private void Update()
        {
            // toggle pausing while the game is running
            if(Input.GetKeyDown(KeyCode.Escape))
                IsGamePaused = !IsGamePaused;
            // toggle inventory while the game is running and not paused and not in another screen.
            else if(!IsInteractionOpen && !IsGamePaused && Input.GetKeyDown(KeyCode.Tab))
                IsInventoryOpen = !IsInventoryOpen;
        }

        public void TransitionToLevel(string sceneName, string targetDoor = null)
        {
            if(null != targetDoor)
                PersistentData.Instance.Volatile.TargetDoorName = targetDoor;
            if(null == FadeInOutInterface)
                TransitionToLevelImmediate(sceneName);
            else
                FadeInOutInterface.TriggerTransition(sceneName);
        }

        public void TransitionToLevelImmediate(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
