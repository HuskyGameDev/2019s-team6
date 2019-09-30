/*
 * Holds information about the game.  Alway present.
 * 
 * Doors:
 * remembers the door that was just walked out of
 * used in RoomManager
 * 
 * Items:
 * remembers which items were picked up and which weren't
 * allows destruction of items that were picked up
 * 
 * Dialog:
 * allows for any message to be displayed
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // the background music track
    private AudioSource backgroundMusic;

    // the dialog system and whether or not the message is being displayed
    private dialogSystem dialogSystem;
    private bool displayingMessage;

    // collected items must be destroyed
    // the list is a string b/c it's the name of the gameObject
    // which the item belongs
    private List<string> destroyedItems;

    /*
     * Add an item to the list of collected items.
     * Is the name of the gameObject since even copies of objects
     * will have unique names.
     * 
     * itemName - the name of the gameObject of the collected item
     */
    public void DestroyItem(string itemName)
    {
        destroyedItems.Add(itemName);
    }

    /*
     * Retrieve the list of collected items
     */
    public List<string> GetDestroyedItems()
    {
        return destroyedItems;
    }

    /*
     * Display a dialog message to the screen
     * 
     * text - the text to display on the screen
     */
    public void displayMessage(string text)
    {
        dialogSystem.dialog = text;
        dialogSystem.DisplayMessage();
        displayingMessage = true;
    }

    private void Start()
    {
        // get the background music component
        backgroundMusic = gameObject.GetComponent<AudioSource>();

        // the list of collected items
        destroyedItems = new List<string>();

        // get the dialog system and start with the box not visible on screen
        dialogSystem = GetComponent<dialogSystem>();
        dialogSystem.CloseMessage();
    }

    private void Update()
    {
        // if the music isn't playing, play the music
        if (!backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }

        // if the message is being displayed, stop gameplay
        if (displayingMessage == true)
        {
            Time.timeScale = 0.0f;
        }

        // if the message is being displayed and the player wishes to continue
        // start gameplay and close the message
        if (displayingMessage == true && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1.0f;
            dialogSystem.CloseMessage();
            displayingMessage = false;
        }
    }

}
