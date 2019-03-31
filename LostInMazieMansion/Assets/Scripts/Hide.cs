using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    private Transform floor;
    private Transform target; // Player

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        floor = GameObject.FindGameObjectWithTag("Waypoint").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    /*
   * Private method for checking if the player is on an object with the
   * EventTrigger script attached to it
   */
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks if the event trigger has already been activated
        if (EnemyMovement.Global.hidden == false && collision.tag == "Hide")
        {
            //Prints out a message to the debug log by default. This is where other
            //custom events would be triggered
            Debug.Log("Hidden");
            //Sets the trigger to true, ensuring it won't activate again
            EnemyMovement.Global.hidden = true;
        } else if (collision.tag == "Unhidden")
        {
            EnemyMovement.Global.hidden = false;
        }
    }

}
