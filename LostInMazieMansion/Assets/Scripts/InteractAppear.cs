﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractAppear : MonoBehaviour
{
    [SerializeField] private Image EtoInteractImage;
    private bool stillTouchingTrigger = false;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
      
            if (otherCollider.CompareTag("Player"))
            {
                Debug.Log("E to Interact");
                stillTouchingTrigger = true;
                
            }
        
       
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            Debug.Log("Disappear");
            stillTouchingTrigger = false;
            EtoInteractImage.enabled = false;
        }
    }

    void FixedUpdate()
    {
        if (stillTouchingTrigger)
        { 
            EtoInteractImage.transform.position = this.gameObject.transform.position;
            EtoInteractImage.enabled = true;
        }
    }
}
