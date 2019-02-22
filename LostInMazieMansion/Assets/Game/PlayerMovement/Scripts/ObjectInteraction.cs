/*
 * This script defines an interactable object.  Interactable objects can be
 * interacted with by the player be pressing 'E'.  Some interactable objects
 * are collected when 'E' is pressed.
 * 
 * NOTE:
 * Most objects using this script will have isInteractable return true.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class Interactable
{
    /*
     * The player can interact with interactable objects
     */
    public abstract bool isInteractable();

    /*
     * The player can collect collectable interactable objects
     */
    public abstract bool isCollectable();

}

class Interaction : Interactable
{ 
    private bool canTouch;    // is the object an interactable
    private bool canCollect;  // is the object a collectable

    /*
     * Constructor for an Interactable object.
     * 
     * param touch   - true if player can interact by pressing 'E'
     *                 false otherwise
     * param collect - true if pressing 'E' adds object to inventory
     *                 false otherwise
    */
    public Interaction(bool touch, bool collect)
    {
        canTouch = touch;
        canCollect = collect;
    }

    /*
     * Checks to see if an object is interactable.
     * 
     * return - true if the player can press 'E' next to object
     *          false otherwise
    */
    public override bool isInteractable()
    {
        return canTouch;
    }

    /*
     * Checks to see if an object is collectable.
     * 
     * return - true if pressing 'E' adds object to inventory
     *          false otherwise
     */
    public override bool isCollectable()
    {
        return canCollect;
    }
}

public class ObjectInteraction : MonoBehaviour
{
    public bool touch;   // true if interactable, false otherwise
    public bool collect; // true if collectable, false otherwise
    Interaction obj;     // this is the object up for interactable debate

    // Use this for initialization
    void Start()
    {
        // make a new obj and define whether or not it's interactable
        obj = new Interaction(touch, collect);
    }

    // Update is called once per frame
    void Update()
    {
        // if the object is interactable and the player presses 'E'
        if(obj.isInteractable() && Input.GetKey(KeyCode.E))
        {
            // if the object is collectable
            if (obj.isCollectable())
            {
                // make item sprite disappear


                // add item to inventory 

                
                // make "collected item" sound
            }

           // a message will appear
               
        }
    }
}
