using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractAppear : MonoBehaviour
{
    [SerializeField] private Image EtoInteractImage;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            Debug.Log("E to Interact");

            EtoInteractImage.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            Debug.Log("Disappear");

            EtoInteractImage.enabled = false;
        }
    }
}
