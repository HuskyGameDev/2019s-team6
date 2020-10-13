using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairway : MonoBehaviour
{
    bool toggle;
    GameObject Floor1;
    GameObject Floor2;

    // Start is called before the first frame update
    void Start()
    {
        // Get Floor 1 and Floor 2 grids
        Floor1 = GameObject.Find("F1").transform.Find("Grid").gameObject;
        Floor2 = GameObject.Find("F2").transform.Find("Grid").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Floor1.SetActive(false);
        Floor2.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
