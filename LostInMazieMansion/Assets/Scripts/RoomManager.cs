using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    // the door that goes to the next level
    public DoorManager door1;

    // the door that door1 goes to
    public DoorManager door2;

    private GameObject player;
    public GameObject playerPrefab;

    /*
     * Spawns the player into position
     */
    private void Start()
    {
        //https://forum.unity.com/threads/player-duplicating-on-scene-load.494863/
        if(GameObject.FindGameObjectWithTag("Player") == null)
        {
            player = Instantiate(playerPrefab);
            player.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }

    /*
     * Load the next room
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            float roomX = 5.33f;
            float roomY = 5.0f;

            // don't destroy the player between scenes
            DontDestroyOnLoad(other.gameObject);

            // load the next scene
            SceneManager.LoadScene(door1.roomName);

            // put the player just on the other side of door2
            // TINKER WITH THE AMOUNTS LATER
            // MAYBE ALL FOR door2.pos TO BE WIHIN SOME RANGE:  roomX - 1 < abs(door.pos) < roomX + 1, or something
            // just so we don't have to be super precise
            if(door2.x == roomX && Mathf.Abs(door2.y) != roomY)
            {
                other.gameObject.transform.position = new Vector3(door2.x - 3, door2.y, door2.z);
            }
            else if (door2.x == -roomX && Mathf.Abs(door2.y) != roomY)
            {
                other.gameObject.transform.position = new Vector3(door2.x + 3, door2.y, door2.z);
            }
            else if (Mathf.Abs(door2.x) != roomX && door2.y == roomY)
            {
                other.gameObject.transform.position = new Vector3(door2.x, door2.y - 3, door2.z);
            }
            else if (Mathf.Abs(door2.x) != roomX && door2.y == -roomY)
            {
                other.gameObject.transform.position = new Vector3(door2.x, door2.y + 3, door2.z);
            }

        }
    }
}
