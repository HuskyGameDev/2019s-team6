
using System;
using MaziesMansion;

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
}
