
using System;
using System.Collections.Generic;
using MaziesMansion;
using UnityEngine;

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
        Dialogue = 1 << 4,
        AnyInterface = ~NoneOpen,
        Escapable = PauseMenu | Inventory | Interaction
    }

    internal struct InterfaceStateAccessor
    {
        public InterfaceType interfaceState;
        private Player player;

        public event Action<bool> OnPauseMenuStateChanged;
        public event Action<bool> OnInventoryMenuStateChanged;
        public event Action<bool> OnInteractionUIStateChanged;
        public event Action<bool> OnDialogueUIStateChanged;
        public event Action<bool> OnFadeInOutUIStateChanged;

        public event Action<bool> OnAnyInterfaceStateChanged;

        private Dictionary<InterfaceType,ISet<ICloseableUI>> openObjects;

        internal InterfaceStateAccessor(Player player)
        {
            interfaceState = InterfaceType.NoneOpen;
            this.player = player;
            openObjects = new Dictionary<InterfaceType, ISet<ICloseableUI>>
            {
                [InterfaceType.PauseMenu] = new HashSet<ICloseableUI>(),
                [InterfaceType.Inventory] = new HashSet<ICloseableUI>(),
                [InterfaceType.Interaction] = new HashSet<ICloseableUI>(),
                [InterfaceType.FadeInOut] = new HashSet<ICloseableUI>(),
                [InterfaceType.Dialogue] = new HashSet<ICloseableUI>(),
            };

            OnPauseMenuStateChanged = null;
            OnInventoryMenuStateChanged = null;
            OnInteractionUIStateChanged = null;
            OnDialogueUIStateChanged = null;
            OnFadeInOutUIStateChanged = null;
            OnAnyInterfaceStateChanged = null;
        }

        public bool this[InterfaceType interfaceType]
        {
            get => (interfaceState & interfaceType) != InterfaceType.NoneOpen;
            set
            {
                if(InterfaceType.NoneOpen == interfaceType)
                    return;
                if(value != this[interfaceType])
                {
                    // dispatch events if the interface state changed
                    foreach(var type in IndividualTypes(interfaceType))
                    {
                        switch(type)
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
                            case InterfaceType.Dialogue:
                                OnDialogueUIStateChanged?.Invoke(value);
                                break;
                            case InterfaceType.FadeInOut:
                                OnFadeInOutUIStateChanged?.Invoke(value);
                                break;
                            default:
                                throw new ArgumentException($"Unsupported interface type {interfaceType}");
                        }
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

        public bool Toggle(InterfaceType interfaceType, ICloseableUI ui)
        {
            if(this[interfaceType])
            {
                Close(interfaceType);
                return false;
            } else
            {
                Open(interfaceType, ui);
                return true;
            }
        }
        public void Open(InterfaceType interfaceType, ICloseableUI ui)
        {
            this[interfaceType] = true;
            openObjects[interfaceType].Add(ui);
        }
        public void Close(InterfaceType interfaceType)
        {
            this[interfaceType] = false;
            foreach(var type in IndividualTypes(interfaceType))
                foreach(var ui in openObjects[type])
                    ui.Close();
        }

        public void Clear(InterfaceType interfaceType)
        {
            this[interfaceType] = false;
        }

        private static IEnumerable<InterfaceType> IndividualTypes(InterfaceType interfaceType)
        {
            if(interfaceType.HasFlag(InterfaceType.PauseMenu))
                yield return InterfaceType.PauseMenu;
            if(interfaceType.HasFlag(InterfaceType.Inventory))
                yield return InterfaceType.Inventory;
            if(interfaceType.HasFlag(InterfaceType.Interaction))
                yield return InterfaceType.Interaction;
            if(interfaceType.HasFlag(InterfaceType.Dialogue))
                yield return InterfaceType.Dialogue;
            if(interfaceType.HasFlag(InterfaceType.FadeInOut))
                yield return InterfaceType.FadeInOut;
        }
    }
}
