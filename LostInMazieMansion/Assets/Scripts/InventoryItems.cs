using UnityEngine;
using UnityEngine.UI;

public class InventoryItems : MonoBehaviour
{
    Item item;
    public Image icon;

    /*
     * Add an item to the inventory
     * 
     * item - new item to be added
     */
    public void AddItem(Item itemToAdd)
    {
        item = itemToAdd;

        icon = GetComponent<Image>();
        icon.sprite = item.picture;
        icon.enabled = true;
    }
}
