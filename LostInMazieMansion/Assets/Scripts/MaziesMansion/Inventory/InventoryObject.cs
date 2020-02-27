using System;
using UnityEngine;

namespace MaziesMansion
{
    [CreateAssetMenu(fileName = "New Inventory Item", menuName = "Mazie/Inventory/Item")]
    [Serializable]
    public class InventoryObject : ScriptableObject
    {
        /// <summary>Unique ID of the item</summary>
        public string ID;

        /// <summary>Is the item an essential item? (e.g., the flashlight)</summary>
        public bool IsEssential;

        /// <summary>The item's icon</summary>
        public Sprite ItemSprite;

        /// <summary>The item's name in the inventory.</summary>
        public string Name;

        /// <summary>The flavor text in the inventory.</summary>
        public string FlavorText;

        public virtual void OnUse() {}

        public override string ToString() => ID;
    }
}
