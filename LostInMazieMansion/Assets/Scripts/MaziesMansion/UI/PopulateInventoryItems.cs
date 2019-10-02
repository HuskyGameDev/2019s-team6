using UnityEngine;

namespace MaziesMansion
{
    internal sealed class PopulateInventoryItems : MonoBehaviour
    {
        public InventoryItemDisplayer DisplayerPrefab = null;

        public bool ShowEssentialItems = true;

        private void OnEnable()
        {
            #if UNITY_EDITOR
            if(!Application.isPlaying)
                return;
            #endif

            var inventory = PersistentData.Instance.Inventory;
            if(!(ShowEssentialItems ? inventory.IsEssentialListDirty : inventory.IsClutterListDirty))
                return;

            for(var i = transform.childCount - 1; i >= 0; i -= 1)
                Destroy(transform.GetChild(i).gameObject);
            var items = ShowEssentialItems ? inventory.EssentialList : inventory.ClutterList;
            foreach(var item in items)
            {
                var obj = Instantiate(DisplayerPrefab, Vector3.zero, Quaternion.identity, transform);
                obj.InventoryObject = item;
            }
        }
    }
}
