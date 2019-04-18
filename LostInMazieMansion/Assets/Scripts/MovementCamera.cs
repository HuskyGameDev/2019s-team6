using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCamera : MonoBehaviour
{
    //declare local variables
    public float moveSpeed;
    private Animator anim;

    private bool cameraMoving;
    private Vector2 lastMove;

    public GameObject player;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //player is default still at start
        cameraMoving = false;

        /*
        //if horizontal movement is detected
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }
        */

        //if vertical movement is detected
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            cameraMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        /*
        if (!player.GetComponent<Movement>().playerMoving)
        {
            Debug.Log("Player Stopped Moving");
        }
        /*

        /*
        //set variables for movement
        anim.SetFloat("Move X", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("Move Y", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", cameraMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
        */

    }
}
