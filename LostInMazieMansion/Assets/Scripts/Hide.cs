using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    class EnemyMovement = new EnemyMovement();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks if the event trigger has already been activated
        if (EnemyMovement.hidden == false)
        {
            //Prints out a message to the debug log by default. This is where other
            //custom events would be triggered
            Debug.Log("Hidden");
            //Sets the trigger to true, ensuring it won't activate again
            EnemyMovement.hidden = true;
        }
    }
}
