using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairway : MonoBehaviour
{
    enum EntrywayLocation
    {
        F1,
        F2
    }

    EntrywayLocation activeFloor;
    GameObject Floor1;
    GameObject Floor2;

    // Start is called before the first frame update
    void Start()
    {
        // Get Floor 1 and Floor 2 grids
        Floor1 = GameObject.Find("F1").transform.Find("Grid").gameObject;
        Floor2 = GameObject.Find("F2").transform.Find("Grid").gameObject;

        activeFloor = EntrywayLocation.F1; // TO DO: UPDATE TO CHECK ON ENTRY

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Find exit direction
        Vector3 direction = other.transform.position - transform.position;

        // Set corresponding active grids
        Floor1.SetActive((direction.y > 0) ? false : true);
        Floor2.SetActive((direction.y < 0) ? false : true);
        activeFloor = (direction.y > 0) ? EntrywayLocation.F2 : EntrywayLocation.F1;
    }
}


