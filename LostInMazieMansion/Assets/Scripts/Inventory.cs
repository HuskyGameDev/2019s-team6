using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{

    public static bool IsInvOpen = false;
    public GameObject inventoryMenuUI;

    // Update is called once per frame
    void Update()
    {

        // if 'TAB' key is pressed while running
        if (Input.GetKeyDown(KeyCode.Tab))
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
        inventoryMenuUI.SetActive(false); // deactivate gameObject Inventory
        Time.timeScale = 1f; // start game time
        IsInvOpen = false; // change boolean to false
        Debug.Log("Inventory Closed"); // message console
    }

    /*
     * This method activates the inventory menu, resumes the game, and returns the message 'Inventory Open' to console.
     */
    void OpenInventory()
    {
        inventoryMenuUI.SetActive(true); // activate gameObject Inventory
        Time.timeScale = 0f; // stop game time
        IsInvOpen = true; // change boolean to true
        Debug.Log("Inventory Opened"); // message console
    }
}
