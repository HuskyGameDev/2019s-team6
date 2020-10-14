using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaziesMansion
{
    public class EntrywayHandler : MonoBehaviour
    {
        GameObject Floor1;
        GameObject Floor2;

        // Start is called before the first frame update
        void Start()
        {

            // TO DO: Check what floor the player is on

            // Get Floor 1 and Floor 2 grids
            Floor1 = GameObject.Find("F1").transform.Find("Grid").gameObject;
            Floor2 = GameObject.Find("F2").transform.Find("Grid").gameObject;


            // TO DO: Set correct floor grid active


        }
    }
}
