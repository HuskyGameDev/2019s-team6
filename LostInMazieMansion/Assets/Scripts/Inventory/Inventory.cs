using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaziesMansion
{
    [Serializable]
    internal sealed class Inventory
    {
        public LinkedList<InventoryObject> EssentialList = new LinkedList<InventoryObject>();

        public LinkedList<InventoryObject> ClutterList = new LinkedList<InventoryObject>();

        [SerializeField]
        private Dictionary<string, bool> PickedUpItems = new Dictionary<string, bool>();

        public void AddItem(InventoryObject item)
        {
            if(item.IsEssential)
                EssentialList.AddLast(item);
            else
                ClutterList.AddLast(item);
            PickedUpItems[item.ID] = true;
        }

        public bool HasPickedUpItem(InventoryObject obj) => PickedUpItems.ContainsKey(obj.ID);
        public bool HasItem(InventoryObject obj) => PickedUpItems.TryGetValue(obj.ID, out var isInInventory) ? isInInventory : false;
    }
}
