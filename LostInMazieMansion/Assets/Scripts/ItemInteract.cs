/*
 * Defines how items can be interacted with.
 * Collectable items can be collected if the inventory is not full.
 * Non-collectable items can only be interacted with.
 */

using UnityEngine;

public class ItemInteract : MonoBehaviour
{
    // the item being interacted with
    private Interactable interactable;
    private Item item;

    // the player
    public GameObject player = null;

    // the inventory
    public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        item = interactable.item;
    }

    // Update is called once per frame
    void Update()
    {
        // if the item can see the player and the player wants to
        // interact with the item
        if(player != null && Input.GetKeyDown(KeyCode.E))
        {
            // access the player's inventory
            inventory = player.GetComponentInChildren<Inventory>();

            //check if the inventory is full
            bool full = false;

            // if the itme is collectable, try to collect the item
            if(interactable.IsCollectable())
            {
                // put the item into the inventory only if the inventory is not full
                full = inventory.PutIntoInventory(item);

                // if the inventory is not full, collect the item
                if (!full)
                {
                    // print the interaction message to the screen
                    interactable.InteractMessageDisplay();

                    // sound the collected item sound
                    interactable.CollectedItemSound();

                    // hide the item from the screen
                    interactable.IsCollected();
                }

                // otherwise, the inventory is full
                else
                {
                    // the inventory is full
                    // NEED TO IMPLEMENT THIS STILL
                    // inventory.DisplayInventoryFullMessage();
                }
            }

            // otherwise, the item is only interactable, so just display the message
            else
            {
                interactable.InteractMessageDisplay();
            }
        }
    }

    /*
     * When the player enters this item's box collider,
     * the item can see the player
     */
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            player = other.gameObject;
        }
    }

    /*
     * When the player exits this item's box collider,
     * the item can no longer see the player
     */
    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            player = null;
        }
    }
}
