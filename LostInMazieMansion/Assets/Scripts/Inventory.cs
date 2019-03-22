using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{

    public static bool IsInvOpen = false;
    public GameObject inventoryMenuUI;

    // Obtainable items -- FEARS -- See GDD -> Special Features for explaination
    public GameObject flashlight;
    public GameObject blinders;
    public GameObject cage;
    public GameObject videoCamera;
    public GameObject bagOfCorks;
    public GameObject Marker;

    // Whether the player has obtained the items -- INVENTORY
    public static bool hasFlashlight = false;
    public static bool hasBlinders = false;
    public static bool hasCage = false;
    public static bool hasVideoCamera = false;
    public static bool hasCorks = false;
    public static bool hasMarker = false;


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
    }

    /*
     * This method deactiveates the inventory menu, resumes the game, and returns the message 'Inventory Closed' to console.
     */
    public void CloseInventory()
    {
        inventoryMenuUI.SetActive(false); // deactivate gameObject Inventory
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f; // start game time
        }
        IsInvOpen = false; // change boolean to false
        Debug.Log("Inventory Closed"); // message console
    }

    /*
     * This method activates the inventory menu, resumes the game, and returns the message 'Inventory Open' to console.
     */
    void OpenInventory()
    {
        inventoryMenuUI.SetActive(true); // activate gameObject Inventory
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f; // stop game time
        }
        IsInvOpen = true; // change boolean to true
        Debug.Log("Inventory Opened"); // message console
    }

    /*
     * This methods activates the flashlight in the inventory menu, and retuns the message 'Flashlight Active' to console.
     */
    public void obtainedFlashlight()
    {
        if (hasFlashlight)
        {
            flashlight.SetActive(true); // activate gameObject Flashlight
            Debug.Log("Flashlight Active"); // message console
        }
        
    }

    /*
     * This methods activates the blinders in the inventory menu, and retuns the message 'Blinders Active' to console.
     */
    public void obtainedBlinders()
    {
        if (hasBlinders)
        {
            blinders.SetActive(true); // activate gameObject Blinders
            Debug.Log("Blinders Active"); // message console
        }

    }

    /*
     * This methods activates the cage in the inventory menu, and retuns the message 'Cage Active' to console.
     */
    public void obtainedCage()
    {
        if (hasCage)
        {
            cage.SetActive(true); // activate gameObject Cage
            Debug.Log("Cage Active"); // message console
        }

    }

    /*
     * This methods activates the video camera in the inventory menu, and retuns the message 'Video Camera Active' to console.
     */
    public void obtainedVideoCamera()
    {
        if (hasVideoCamera)
        {
            videoCamera.SetActive(true); // activate gameObject Video Camera
            Debug.Log("Video Camera Active"); // message console
        }

    }

    /*
     * This methods activates the bag of corks in the inventory menu, and retuns the message 'Corks Active' to console.
     */
    public void obtainedBagOfCorks()
    {
        if (hasCorks)
        {
            bagOfCorks.SetActive(true); // activate gameObject Bag of Corks
            Debug.Log("Corks Active"); // message console
        }

    }

    /*
     * This methods activates the marker in the inventory menu, and retuns the message 'Marker Active' to console.
     */
    public void obtainedMarker()
    {
        if (hasMarker)
        {
            flashlight.SetActive(true); // activate gameObject Marker
            Debug.Log("Marker Active"); // message console
        }

    }
}
