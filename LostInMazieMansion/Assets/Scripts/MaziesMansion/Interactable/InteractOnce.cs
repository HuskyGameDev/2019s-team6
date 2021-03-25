using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractOnce : MonoBehaviour
{

    bool interacted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (interacted = false)
        {
            interacted = true;
        }
        else
        {
            gameObject.SetActive(false);
        }
        
    }
}
