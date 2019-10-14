using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaziesMansion
{
    [Serializable]
    internal sealed class Inventory
    {
        // these must be true to force a redraw the next time the interface is opened.
        public bool IsEssentialListDirty = true;
        public bool IsClutterListDirty = true;

        public LinkedList<InventoryObject> EssentialList = new LinkedList<InventoryObject>();

        public LinkedList<InventoryObject> ClutterList = new LinkedList<InventoryObject>();

        [SerializeField]
        private Dictionary<string, bool> CollectedObjects = new Dictionary<string, bool>();

        public void AddItem(InventoryObject item)
        {
            if(item.IsEssential)
            {
                EssentialList.AddLast(item);
                IsEssentialListDirty = true;
            }
            else
            {
                ClutterList.AddLast(item);
                IsClutterListDirty = true;
            }
            CollectedObjects[item.ID] = true;
        }

        public void RemoveItem(InventoryObject item)
        {
            CollectedObjects[item.ID] = false;
            if(item.IsEssential)
            {
                EssentialList.Remove(item);
                IsEssentialListDirty = true;
            } else
            {
                ClutterList.Remove(item);
                IsClutterListDirty = true;
            }
        }

        public bool HasCollectedItem(InventoryObject obj) => CollectedObjects.ContainsKey(obj.ID);
        public bool HasCollectedItem(string objectID) => CollectedObjects.ContainsKey(objectID);
        public bool HasItem(InventoryObject obj) => CollectedObjects.TryGetValue(obj.ID, out var isInInventory) ? isInInventory : false;
        public bool HasItem(string objectID) => CollectedObjects.TryGetValue(objectID, out var isInInventory) ? isInInventory : false;
    }
}
