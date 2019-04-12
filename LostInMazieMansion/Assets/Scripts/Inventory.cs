﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static bool IsInvOpen = false;
    public GameObject InventoryFullScreen;

    // the full size of the inventory
    public static int numberOfSlots;
    public InventoryItems[] slots;

    private void Start()
    {
        numberOfSlots = 12;
        slots = InventoryFullScreen.GetComponentsInChildren<InventoryItems>();
    }

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
        if (Input.GetKeyDown(KeyCode.Tab) && !PauseMenu.IsGamePaused)
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

        if(IsInvOpen)
        {

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
