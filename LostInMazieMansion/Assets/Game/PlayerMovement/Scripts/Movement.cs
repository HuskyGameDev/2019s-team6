/*
 * This script defines player movement.  Using the 'WASD' keys, which are for the movement of 'up', 'down',
 * 'left', and 'right', respectively, the player can move around the play area.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;    // speed player moves at
	
	// Update is called once per frame
	void Update ()
    {
        // if 'W' is pressed, move up at speed 'speed'
		if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.TransformDirection(Vector2.up) * Time.deltaTime * speed;
        }

        // if 'A' is pressed, move left at speed 'speed'
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.TransformDirection(Vector2.left) * Time.deltaTime * speed;
        }

        // if 'S' is pressed, move down at speed 'speed'
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.TransformDirection(Vector2.down) * Time.deltaTime * speed;
        }

        // if 'D' is pressed, move right at speed 'speed'
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.TransformDirection(Vector2.right) * Time.deltaTime * speed;
        }
    }
}
