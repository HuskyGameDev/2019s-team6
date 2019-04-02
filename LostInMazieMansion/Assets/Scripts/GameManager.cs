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
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // the most recent door entered through
    private DoorManager door;

    // the background music track
    private AudioSource backgroundMusic;

    // collected items must be destroyed
    // the list is a string b/c it's the name of the gameObject
    // which the item belongs
    private List<string> destroyedItems;

    /*
     * Remembers the door that was entered through.
     * For positioning the player on the other side
     * of the correct door in a room.
     * 
     * outDoor - the door entered through
     */ 
    public void SetDoor(DoorManager outDoor)
    {
        door = outDoor;
    }

    /*
     * Gets the door entered through in a room.
     * For positioning the player on the other side
     * of the correct door in a room.
     */
    public DoorManager GetOutDoor()
    {
        return door;
    }

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

    private void Start()
    {
        // get the background music component
        backgroundMusic = gameObject.GetComponent<AudioSource>();

        // the list of collected items
        destroyedItems = new List<string>();
    }

    private void Update()
    {
        // if the music isn't playing, play the music
        if(!backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }
    }
}
