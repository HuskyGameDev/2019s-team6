using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaziesMansion
{
    [Flags]
    internal enum InterfaceType
    {
        NoneOpen = 0,
        PauseMenu = 1 << 0,
        Inventory = 1 << 1,
        Interaction = 1 << 2,
        FadeInOut = 1 << 3,
        AnyInterface = ~NoneOpen,
    }

    internal struct InterfaceStateAccessor
    {
        public InterfaceType interfaceState;
        private Player player;

        public event Action<bool> OnPauseMenuStateChanged;
        public event Action<bool> OnInventoryMenuStateChanged;
        public event Action<bool> OnInteractionUIStateChanged;
        public event Action<bool> OnFadeInOutUIStateChanged;

        public event Action<bool> OnAnyInterfaceStateChanged;

        internal InterfaceStateAccessor(Player player)
        {
            interfaceState = InterfaceType.NoneOpen;
            this.player = player;

            OnPauseMenuStateChanged = null;
            OnInventoryMenuStateChanged = null;
            OnInteractionUIStateChanged = null;
            OnFadeInOutUIStateChanged = null;
            OnAnyInterfaceStateChanged = null;
        }

        public bool this[InterfaceType interfaceType]
        {
            get => (interfaceState & interfaceType) != InterfaceType.NoneOpen;
            set
            {
                if(value != this[interfaceType])
                {
                    // dispatch events if the interface state changed
                    switch(interfaceType)
                    {
                        case InterfaceType.PauseMenu:
                            OnPauseMenuStateChanged?.Invoke(value);
                            break;
                        case InterfaceType.Inventory:
                            OnInventoryMenuStateChanged?.Invoke(value);
                            break;
                        case InterfaceType.Interaction:
                            OnInteractionUIStateChanged?.Invoke(value);
                            break;
                        case InterfaceType.FadeInOut:
                            OnFadeInOutUIStateChanged?.Invoke(value);
                            break;
                        default:
                            throw new ArgumentException($"Unsupported interface type {interfaceType}");
                    }
                    OnAnyInterfaceStateChanged?.Invoke(value);
                }
                // update the interface state.
                if(value)
                    interfaceState |= interfaceType;
                else
                    interfaceState &= ~interfaceType;
            }
        }

        public bool Toggle(InterfaceType interfaceType) => this[interfaceType] = !this[interfaceType];
        public void Open(InterfaceType interfaceType) => this[interfaceType] = true;
        public void Close(InterfaceType interfaceType) => this[interfaceType] = false;
    }

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
                if(save.PlayerLocation.z >= 0)
                    Player.transform.position = save.PlayerLocation;
            }
        }

        private void Update()
        {
            // toggle pausing while the game is running
            if(Input.GetKeyDown(KeyCode.Escape))
                InterfaceState.Toggle(InterfaceType.PauseMenu);
            // toggle inventory while any other UI is not open.
            else if(!InterfaceState[~InterfaceType.Inventory] && Input.GetKeyDown(KeyCode.Tab))
                InterfaceState.Toggle(InterfaceType.Inventory);
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
    }
}
