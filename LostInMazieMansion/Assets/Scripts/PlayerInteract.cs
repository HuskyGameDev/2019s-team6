/*
 * This class defines how the player can interact with
 * Interactable objects.  If the player is within the
 * Interactable object's collider region, the player can
 * interact with it.  Otherwise, the player cannot interact
 * with the object
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // object being interacted with
    public GameObject obj = null;


    
    //Will not load due to "Iventory not added to build settings or AssestBundle"
    //MUST HAVE "Inventory Menu UI" SLOT BE THE INVENTORY UI
    //OTHERWISE THE PLAYER WILL DISAPPER
    //BUT THE SCENE STILL CAN'T BE LOADED...
    //private void Update()
    //{
    //    if (Input.GetKey(KeyCode.Tab) && !PauseMenu.IsGamePaused)
    //    {
    //        Inventory.InventoryMenu();
    //    }
    //}
    


    /*
    * If the player enters an Interactable object's range,
    * then the player can interact with the object
    */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            obj = other.gameObject;
        }
    }

    /*
     * If the player exits an Interactable object's range,
     * then the player can not interact with the object
     */
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            if (other.gameObject == obj)
            {
                obj = null;
            }
        }
    }
}
