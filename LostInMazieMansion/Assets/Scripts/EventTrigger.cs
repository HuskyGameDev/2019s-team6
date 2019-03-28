using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    //Boolean for determining if the event has already been triggered
    bool triggered = false;

    /*
    * Private method for checking if the player is on an object with the
    * EventTrigger script attached to it
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks if the event trigger has already been activated
        if (triggered == false)
        {
            //Prints out a message to the debug log by default. This is where other
            //custom events would be triggered
            Debug.Log("Event Triggered");
            //Sets the trigger to true, ensuring it won't activate again
            triggered = true;
        }
    }
}
