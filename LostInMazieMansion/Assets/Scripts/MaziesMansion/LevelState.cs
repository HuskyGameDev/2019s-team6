using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaziesMansion
{
    /// <summary>Tracks the game state within a single level</summary>
    internal sealed class LevelState : MonoBehaviour
    {
#region Menu Interface Variables
        public GameObject MenuBackgroundInterface = null;
        public GameObject[] MenuInterfaces = new GameObject[3];
        public GameObject PauseInterface = null;
        public GameObject InventoryInterface = null;

        /// <summary>The black overlay used for fading out the level.</summary>
        public FadeInOut FadeInOutInterface = null;
#endregion

        /// <summary>The overlay that appears for the player to interact with objects in the scene.</summary>
        public GameObject InteractButton = null;

        /// <summary>A reference to the player in this scene.</summary>
        private Player Player = null;

        public InterfaceStateAccessor InterfaceState;
        public event Action OnInteractionOpen;

        public static bool IsPaused => Instance?.InterfaceState[InterfaceType.AnyInterface] ?? true;

        public static LevelState Instance;

        private void Awake()
        {
            Instance = this;
            if(!ObjectUtility.TryFindObjectOfType(out Player))
                Debug.Log("Player is not present in the scene.", this);
            InterfaceState = new InterfaceStateAccessor(Player);
            InterfaceState.OnPauseMenuStateChanged += value => {
                MenuBackgroundInterface.SetActive(value);
                PauseInterface.SetActive(value);
                foreach(var item in MenuInterfaces)
                    item.SetActive(!value);
            };
            InterfaceState.OnInventoryMenuStateChanged += InventoryInterface.SetActive;
        }

        private void OnDestroy()
        {
            Instance = null;
        }

        private void Start()
        {
            var save = PersistentData.Instance;
            if(null != save.Volatile.TargetDoorName)
            {
                // the player object should be moved in front of a door.
                if(null != Player && ObjectUtility.TryFindComponent(save.Volatile.TargetDoorName, out Door door))
                    door.Place(Player.gameObject);
                save.Volatile.TargetDoorName = null;
            }
            if(save.Volatile.JustLoadedGame)
            {
                save.Volatile.JustLoadedGame = false;
                Player.transform.position = save.PlayerLocation;
            }

            // update current level when we load in
            save.CurrentLevel = SceneManager.GetActiveScene().name;
        }

        private void Update()
        {
            // toggle pausing while the game is running
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(InterfaceState[InterfaceType.Escapable])
                    InterfaceState.Close(InterfaceType.Escapable);
                else
                    InterfaceState.Open(InterfaceType.PauseMenu, new CloseableUIObject(PauseInterface));
            }
            else if(Input.GetKeyDown(KeyCode.Tab) && !InterfaceState[~InterfaceType.Inventory])
            {
                // toggle inventory while any other UI is not open.
                InterfaceState.Toggle(InterfaceType.Inventory, new CloseableUIObject(InventoryInterface));
            }
        }

        /// <summary>Load the target scene with a fade in/out.</summary>
        public void TransitionToLevel(string sceneName, string targetDoor = null)
        {
            if(null != targetDoor)
                PersistentData.Instance.Volatile.TargetDoorName = targetDoor;
            if(null == FadeInOutInterface)
                SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            else
                FadeInOutInterface.TriggerTransition(sceneName);
        }

        public void ClosePauseMenu()
        {
            // TODO: move this somewhere better
            InterfaceState.Close(InterfaceType.PauseMenu);
        }
    }
}
