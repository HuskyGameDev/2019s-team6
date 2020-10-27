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
            // Get Floor 1 and Floor 2 grids
            Floor1 = GameObject.Find("F1").transform.Find("Grid").gameObject;
            Floor2 = GameObject.Find("F2").transform.Find("Grid").gameObject;

            // Check what floor the player is on and set correct floor grid active
            Floor1.SetActive((Player.PlayerFloor == Player.Location.F1) ? true : false);
            Floor2.SetActive((Player.PlayerFloor == Player.Location.F2) ? true : false);
        }
    }
}
