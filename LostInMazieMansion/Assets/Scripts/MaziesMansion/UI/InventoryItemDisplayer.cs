using UnityEngine;
using UnityEngine.UI;

namespace MaziesMansion
{
    internal sealed class InventoryItemDisplayer : MonoBehaviour
    {
        public InventoryObject InventoryObject;

        public Image ItemRenderer;

        private Player player;

        private void Start()
        {
            if(null == InventoryObject)
            {
                Destroy(gameObject);
                return;
            }

            ItemRenderer.sprite = InventoryObject.ItemSprite;
        }

        public void OnInteract()
        {
            // use the associated object if there is one.
            InventoryObject?.OnUse();
        }
    }
}
