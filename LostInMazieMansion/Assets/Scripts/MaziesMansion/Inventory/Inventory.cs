using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaziesMansion
{

    [Serializable]
    internal class CollectedObjectsDictionary: SerializableDictionary<string, bool> {}

    [Serializable]
    internal sealed class Inventory
    {
        // these must be true to force a redraw the next time the interface is opened.
        [NonSerialized]
        public bool IsEssentialListDirty = true;

        [NonSerialized]
        public bool IsClutterListDirty = true;

        [SerializeField]
        public List<InventoryObject> EssentialList = new List<InventoryObject>();

        [SerializeField]
        public List<InventoryObject> ClutterList = new List<InventoryObject>();

        [SerializeField]
        private CollectedObjectsDictionary CollectedObjects = new CollectedObjectsDictionary();

        public void AddItem(InventoryObject item)
        {
            if(item.IsEssential)
            {
                EssentialList.Add(item);
                IsEssentialListDirty = true;
            }
            else
            {
                ClutterList.Add(item);
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

        public void RemoveItem(string itemID)
        {
            foreach(var item in EssentialList)
                if(item.ID == itemID)
                {
                    CollectedObjects[itemID] = false;
                    EssentialList.Remove(item);
                    IsEssentialListDirty = true;
                    return;
                }
            foreach(var item in ClutterList)
                if(item.ID == itemID)
                {
                    CollectedObjects[itemID] = false;
                    ClutterList.Remove(item);
                    IsClutterListDirty = true;
                    return;
                }
            Debug.Log($"Could not find item \"{itemID}\" when removing");
        }

        public bool HasCollectedItem(InventoryObject obj) => CollectedObjects.ContainsKey(obj.ID);
        public bool HasCollectedItem(string objectID) => CollectedObjects.ContainsKey(objectID);
        public bool HasItem(InventoryObject obj) => CollectedObjects.TryGetValue(obj.ID, out var isInInventory) ? isInInventory : false;
        public bool HasItem(string objectID) => CollectedObjects.TryGetValue(objectID, out var isInInventory) ? isInInventory : false;
    }
}
