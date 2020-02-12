using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MaziesMansion
{
    internal sealed class InventoryItemDisplayer : MonoBehaviour
    {
        public InventoryObject InventoryObject;

        public Image ItemRenderer;

        private UseButton UseButton;
        private DiscardButton DiscardButton;
        private Player player;

        private void Start()
        {
            if(null == InventoryObject)
            {
                Destroy(gameObject);
                return;
            }

            ItemRenderer.sprite = InventoryObject.ItemSprite;

            UseButton = GetComponentInChildren<UseButton>();
            DiscardButton = GetComponentInChildren<DiscardButton>();
            UseButton.gameObject.SetActive(false);
            DiscardButton.gameObject.SetActive(false);
        }

        public void OnInteract()
        {
            UseButton.gameObject.SetActive(!UseButton.gameObject.activeSelf);

            // Set which InventoryObject was clicked
            UseButton.SetItemToUse(InventoryObject);

            DiscardButton.gameObject.SetActive(!DiscardButton.gameObject.activeSelf);
        }
    }
}
