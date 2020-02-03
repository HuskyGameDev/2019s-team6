﻿using MaziesMansion;
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
    private GameObject TheLight;
    private InventoryObject itemToUse;

    private void Start()
    {
        TheLight = GameObject.Find("Flashlight");
    }

    public void OnUseClick()
    {
        // Get Flashlight lighting component
        UnityEngine.Experimental.Rendering.LWRP.Light2D The2DLight = TheLight.GetComponent<UnityEngine.Experimental.Rendering.LWRP.Light2D>();

        // If the inventory item clicked was the flashlight
        if (The2DLight != null && itemToUse.name == "Flashlight")
        {
            // then increase the intensity (turn on the flashlight)
            The2DLight.intensity = (The2DLight.intensity == 0) ? 0.6f : 0.0f;
            PersistentData.Instance.flashlightActive = (The2DLight.intensity == 0)? false: true;

        } else
        {
            PersistentData.Instance.flashlightActive = (The2DLight.intensity == 0) ? false : true;
        }

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
