/*
 * Manages how the scenes change based on the door that
 * was walked through.
 * 
 * BE CAREFUL ABOUT NAMING THE DOORS
 * doorName AND the GameObject's name MUST MATCH!!!
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    // the door the player walks into - set using ScriptableObject in the Unity Editor
    public DoorManager doorIn;

    // the door the player walks out of - set in the Start() method
    private DoorManager doorOut;

    // the player to spawn
    private GameObject player;
    public GameObject playerPrefab;

    // the game manager to spawn
    private GameObject gameManager;
    public GameObject gameManagerPrefab;

    /*
    * Spawns the player into position if not present.
    * Called before Start().  Allows retrieving the gameManager
    * easier in the Start() method of Interactable
    */
    private void Awake()
    {
        // the player game object
        player = GameObject.FindGameObjectWithTag("Player");

        // the game manager game object
        gameManager = GameObject.FindGameObjectWithTag("GameManager");

        // spawn player in middle of the room if the player is not present
        if (player == null)
        {
            player = Instantiate(playerPrefab);
            player.transform.position = new Vector2(0.0f, 0.0f);
        }

        // spawn the game manager object if not present
        if (gameManager == null)
        {
            gameManager = Instantiate(gameManagerPrefab);
            gameManager.transform.position = new Vector2(0.0f, 0.0f);
        }
    }

    private void Start()
    {
        // put the player on the other side of the door in the room that was just loaded
        // ^^^ this is why this code is here and not in OnTriggerEnter2D
        // get the door we just walked through
        doorOut = gameManager.GetComponent<GameManager>().GetOutDoor();
        if (doorOut != null)
        {
            //Debug.Log(doorOut.doorName);
            // get the game object associated with this door
            // BE CAREFUL ABOUT NAMING
            GameObject outDoor = GameObject.Find(doorOut.doorName);

            // door faces right => put player to right of door
            if (doorOut.dir == DoorManager.Direction.RIGHT)
            {
                player.transform.position = new Vector2(outDoor.transform.position.x + 2, outDoor.transform.position.y);
            }
            // door faces left => put player to left of door
            else if (doorOut.dir == DoorManager.Direction.LEFT)
            {
                player.transform.position = new Vector2(outDoor.transform.position.x - 2, outDoor.transform.position.y);
            }
            // door faces up => put player above door
            else if (doorOut.dir == DoorManager.Direction.UP)
            {
                player.transform.position = new Vector2(outDoor.transform.position.x, outDoor.transform.position.y + 2);
            }
            // door faces down => put player below door
            else if (doorOut.dir == DoorManager.Direction.DOWN)
            {
                player.transform.position = new Vector2(outDoor.transform.position.x, outDoor.transform.position.y - 2);
            }
        }
    }

    /*
     * Load the next room
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            // don't destroy the player between scenes
            DontDestroyOnLoad(other.gameObject);

            // set the door we walk out of so we can grab it in the next scene
            // and don't destroy the game manager
            gameManager.GetComponent<GameManager>().SetDoor(doorIn.connectingDoor);
            DontDestroyOnLoad(gameManager);

            // load the next scene
            SceneManager.LoadScene(doorIn.roomName);
        }
    }
}
