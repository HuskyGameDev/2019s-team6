using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggered == false)
        {
            Debug.Log("Event Triggered");
            triggered = true;
        }

    }
}