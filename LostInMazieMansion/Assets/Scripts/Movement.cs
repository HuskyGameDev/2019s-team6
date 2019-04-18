/*
 * This script defines player movement.  Using the 'WASD' keys, which are for the movement of 'up', 'down',
 * 'left', and 'right', respectively, the player can move around the play area.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    //declare local variables
    public float moveSpeed;
    private Animator anim;

    public bool playerMoving;
    private Vector2 lastMove;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //player is default still at start
        playerMoving = false;

        //if horizontal movement is detected
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        //if vertical movement is detected
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        //set variables for movement
        anim.SetFloat("Move X", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("Move Y", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);

    }
}
