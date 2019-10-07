using UnityEngine;

namespace MaziesMansion
{
    [RequireComponent(typeof(SpriteRenderer))]
    #if UNITY_EDITOR
    [ExecuteInEditMode]
    #endif
    internal sealed class InWorldItem : MonoBehaviour
    {
        public InventoryObject Item;

        private void Start()
        {
            if(PersistentData.Instance.Inventory.HasCollectedItem(Item))
            {
                gameObject.SetActive(false);
                return;
            }

            if(TryGetComponent<SpriteRenderer>(out var renderer))
            {
                renderer.sprite = Item.ItemSprite;
            }
        }

        public void PickUpItem()
        {
            PersistentData.Instance.Inventory.AddItem(Item);
            gameObject.SetActive(false);
        }

        public void InspectItem()
        {
            // TODO
        }

        #if UNITY_EDITOR
        private void OnValidate()
        {
            if(null == Item)
                return;
            if(TryGetComponent<SpriteRenderer>(out var renderer))
            {
                renderer.sprite = Item.ItemSprite;
            }
        }
        #endif
    }
}
