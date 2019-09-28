using MaziesMansion;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // STILL NEEDED:
    // inventory DisplayInventoryFullMessage() - see ItemInteract

    public static bool IsInvOpen = false;
    public GameObject InventoryFullScreen;

    // the full size of the inventory
    public static int numberOfSlots;
    public InventoryItems[] slots;

    private LevelState LevelState;

    private void Start()
    {
        // initialize the number of slots and the slots themselves
        numberOfSlots = 12;
        slots = InventoryFullScreen.GetComponentsInChildren<InventoryItems>();
        LevelState = GameObject.FindObjectOfType<LevelState>();
    }

    /*
     * Put and item into the inventory if it isn't full.  Otherwise, do nothing.
     *
     * item - the item to be put into the inventory
     * return false if the inventory is not full, true otherwise
     */
    public bool PutIntoInventory(Item item)
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            // if we find an empty slot
            if (slots[i].GetComponent<Image>().sprite == null)
            {
                // put the item into this slot and say the inventory is not full
                slots[i].AddItem(item);
                return false;
            }
        }
        // if we get here, the inventory is full
        return true;
    }


    // Update is called once per frame
    void Update()
    {
        // if 'TAB' key is pressed while running
        if (Input.GetKeyDown(KeyCode.Tab) && !LevelState.IsGamePaused)
        {
            // if the players inventory is open and the game is paused
            if (IsInvOpen)
            {
                CloseInventory(); // close the inventory
            }
            // otherwise
            else
            {
                OpenInventory(); // open the inventory
            }
        }
    }

    /*
     * This method deactiveates the inventory menu, resumes the game, and returns the message 'Inventory Closed' to console.
     */
    public void CloseInventory()
    {
        InventoryFullScreen.SetActive(false); // deactivate gameObject Inventory
        Time.timeScale = 1f; // start game time
        IsInvOpen = false; // change boolean to false
        Debug.Log("Inventory Closed"); // message console
    }

    /*
     * This method activates the inventory menu, resumes the game, and returns the message 'Inventory Open' to console.
     */
    void OpenInventory()
    {
        InventoryFullScreen.SetActive(true); // activate gameObject Inventory
        Time.timeScale = 0f; // stop game time
        IsInvOpen = true; // change boolean to true
        Debug.Log("Inventory Opened"); // message console
    }
}
