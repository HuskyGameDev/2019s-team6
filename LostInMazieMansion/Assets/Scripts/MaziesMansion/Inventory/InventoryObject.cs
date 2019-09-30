using System;
using UnityEngine;

namespace MaziesMansion
{
    [CreateAssetMenu(fileName = "New Inventory Item", menuName = "Mazie/Inventory Item")]
    [Serializable]
    internal sealed class InventoryObject : ScriptableObject
    {
        public Sprite ItemSprite;

        public string Name;

        public bool IsEssential;

        public string ID;
    }
}
