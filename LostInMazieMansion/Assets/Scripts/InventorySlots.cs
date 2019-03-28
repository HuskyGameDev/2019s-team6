using UnityEngine;
using UnityEngine.UI;

public class InventorySlots : MonoBehaviour
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
        
            icon.sprite = item.picture;
            icon.enabled = true;
    }


        //    bool full = false;

        //    // find an open slot in inventory
        //    for (int i = 0; i < inventory.Length; i++)
        //    {
        //        if (inventory[i] == null)
        //        {
        //            // add the item
        //            inventory[i] = item;
        //            Debug.Log("slot " + i + " = " + item.name);

        //            // add the items sprite to the inventory
        //            inventory[i].GetComponentInChildren<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
        //            inventory[i].GetComponentInChildren<Image>().enabled = true;

        //            //// if it's any of the FEAR items, then we have it
        //            //if (item == flashlight)
        //            //{
        //            //    hasFlashlight = true;
        //            //}
        //            //else if (item == blinders)
        //            //{
        //            //    hasBlinders = true;
        //            //}
        //            //else if (item == cage)
        //            //{
        //            //    hasCage = true;
        //            //}
        //            //else if (item == videoCamera)
        //            //{
        //            //    hasVideoCamera = true;
        //            //}
        //            //else if (item == bagOfCorks)
        //            //{
        //            //    hasCorks = true;
        //            //}
        //            //else if (item == Marker)
        //            //{
        //            //    hasMarker = true;
        //            //}
        //            break;
        //        }

        //        // if we get here, then the inventory is full
        //        full = true;
        //    }

        //    return full;
    //}
}
