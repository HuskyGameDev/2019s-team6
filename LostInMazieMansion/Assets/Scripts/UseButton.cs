using MaziesMansion;
using UnityEngine;

public class UseButton : MonoBehaviour
{
    /*
     * When the "use" button is clicked, *do something*
     * according to what object is used.
     *
     * This means that a reference to the player is needed
     * for when a Fear Conquering item is used.  Example: when
     * the flashlight is used, change the player's artwork to that
     * of him holding the flashlight
     *
     * If the item is not a Fear Conquering item, then get a reference
     * to the item so that the appropriate sound or animation or message plays
     */
    private InventoryObject itemToUse;

    private void Start()
    {
    }

    public void OnUseClick()
    {
        // if itemInSlot is a fear conquering item then:
        // in the case of fear conquering items, get a reference to the player
        // THIS WORKS :)
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //Debug.Log(player.name);

        // if the item is the flashlight/cage/video camera/blinders/corks
        // change the player's animaton to match
        // => change to flashlight version
        // => put cage on the ground and go back to normal
        // => pull out video camera, hold it and look at it -OR- change to a "video camera" type scene
        // => put on blinders
        // => move player around wall and show wall slowly filling with corks
        // the marker may not need a separate animation, unless we want to

        // no matter what the item is, play the correct sound and display the message if any

        // in the case of unlocking, send info to GameManager so that unlocking can be completed
    }

    public void SetItemToUse(InventoryObject o)
    {
        this.itemToUse = o;
    }
}
