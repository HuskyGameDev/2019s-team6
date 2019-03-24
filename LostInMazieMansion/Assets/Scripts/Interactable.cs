/*
 * Attached to objects that the player can interact with 
 * (interactable objects).
 * The methods define if an object is collectable, what
 * messages print to the screen when the player interacts
 * with the object in some way, and what sounds play when
 * the player interacts with the object in some way.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // a scriptable item
    public Item item;

    // the sprite renderer for the object
    private SpriteRenderer sp;

    // the audio clips and sources for the object
    //private AudioClip pickUp;
    //private AudioSource pickUpSource;
    //private AudioClip use;
    //private AudioSource useSource;

    // Start is called before the first frame update
    void Start()
    {
        // get the sprite renderer for the object and set
        // it to the image's picture
        sp = GetComponent<SpriteRenderer>();
        sp.sprite = item.picture;

        // set the sounds
        //pickUp = item.pickUpSound;
        // use = item.useSound;
    }

    void Awake()
    {
        // get the audio source for the sounds
        //pickUpSource = GetComponent<AudioSource>();
        //useSource = GetComponent<AudioSource>();
    }

    /*
     * Defines if the item is collectable.
     * 
     * return true if the item is collectable, false otherwise
     */
    public bool IsCollectable()
    {
        return item.collect;
    }

    /*
     * When a collectable item is collected, hide the image from the
     * screen by setting the artwork to null, disabling the object's
     * box collider, and hiding the empty game object
     */
    public void IsCollected()
    {
        // no artwork on screen
        sp.sprite = null;

        // hide the box collider
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        // hide the game object
        gameObject.SetActive(false);
    }

    /*
     * Displays the message upon interaction with the item
     */
    public void InteractMessageDisplay()
    {
        // display item.messageOnInteract
    }

    /*
     * Displays the message upon use of the item
     */
    public void UseMessageDisplay()
    {
        // display item.messageOnUse
    }

    /*
     * Displays the message upon discarding an item
     */
    public void DiscardMessageDisplay()
    {
        // display item.messageOnDiscard
    }

    /*
     * Sounds the collected item sound
     * 
     * RANDOMIZE VOLUME??? (SEE WITHOUT, THEN DECIDE;
     * sound effects and scripts on unity3d.comS)
     */
    public void CollectedItemSound()
    {
        // sound item.pickUpSound
        //pickUpSource.PlayOneShot(pickUp);
    }

    /*
     * Sounds the use item sound
     */
    public void ItemUseSound()
    {
        // sound item.useSound
        // useSource.PlayOneShot(use);
    }

}
