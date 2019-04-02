/*
 * Attached to objects that the player can interact with 
 * (interactable objects).
 * The methods define if an object is collectable, what
 * messages print to the screen when the player interacts
 * with the object in some way, and what sounds play when
 * the player interacts with the object in some way.
 */

using UnityEngine;

public class Interactable : MonoBehaviour
{
    // a scriptable item
    public Item item;

    // the sprite renderer for the object
    private SpriteRenderer sp;

    // the audio sources for the object
    private AudioSource source;

    private GameManager gameManager;

    // the dialog stuff - file is called "benevolentDialog"
    // interactionMessage - dialog on player interacting with object
    //private benevolentDialog interactionMessage;

    // Start is called before the first frame update
    void Start()
    {
        // get the game manager
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        // if the list of collected items exists and the item is contained in the list, then destroy it
        if (gameManager != null && gameManager.GetDestroyedItems() != null && gameManager.GetDestroyedItems().Contains(gameObject.name))
        {
            Destroy(gameObject);
        }

        // otherwise, show the item on screen
        else
        {
            item.wasCollected = false;

            // get the sprite renderer for the object and set
            // it to the image's picture
            sp = gameObject.GetComponent<SpriteRenderer>();
            sp.sprite = item.picture;

            // get the item's audio
            source = gameObject.GetComponent<AudioSource>();

            // the message on interaction with the item
            //interactionMessage = gameObject.GetComponent<benevolentDialog>();
            //interactionMessage.dialog = item.messageOnInteract;
        }
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
        // add the item to the list of collected items
        gameManager.DestroyItem(gameObject.name);

        // no artwork on screen
        sp.sprite = null;

        // hide the box collider
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        // destroys the item after 3 counts - THIS MAY NEED TO BE TINKERED WITH...
        Destroy(gameObject, 3.0f);
    }

    /*
     * Displays the message upon interaction with the item
     */
    public void InteractMessageDisplay()
    {
        // display item.messageOnInteract
        //interactionMessage.DialogDisplay();
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
     * sound effects and scripts on unity3d.com)
     */
    public void CollectedItemSound()
    {
        // sound item.pickUpSound
        source.PlayOneShot(item.pickUpSound);
    }

    /*
     * Sounds the use item sound
     */
    public void ItemUseSound()
    {
        // sound item.useSound
        source.PlayOneShot(item.useSound);
    }

}
