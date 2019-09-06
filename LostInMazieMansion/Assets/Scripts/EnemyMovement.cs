using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float wait = 3f; // Wait Time
    public float speed; // Enemy Movement Speed
    private Transform target; // Player
    private Transform waypoint; // Current Waypoint

    /*
     * This is a Global variable class. It is used to tell the enemy object if the player is hiding or not.
     */
    public class Global
    {
        public static bool hidden; // Is the player hiding

    }

    // Array of waypoints to walk from one to the next
    [SerializeField]
    private Transform[] waypoints = new Transform[0];

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    // Index of current waypoint from which enemy walks to the next
    private int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // Get object with "Player" tag
        waypoint = GameObject.FindGameObjectWithTag("Waypoint").GetComponent<Transform>(); // Get object with "Waypoint" tag

        // Set position of Enemy as position of the first waypoint
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        // If the distance between the target(player) and the enemy is less than # and the player is not hidden,
        if (Vector2.Distance(transform.position, target.position) < 5 && Global.hidden == false)
        {
            // Then the enemy will follow the target(player) at the given speed
            follow();
        }
        else
        {
            // Otherwise the enemy should walk the set path
            walkPath();
        }

    }

    /*
     * Calls MoveEnemy method every frame to update
     * enemy position
     */
    private void walkPath()
    {
        MoveEnemy();
    }

    /*
     * Changes the enemy's position every frame so that the enemy follows the player
     */
    private void follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        // waypointIndex = 0; // Reset Index
    }

    /*
     * Changes the enemys path based on the places waypoint markers
     */
    private void MoveEnemy()
    {
        // If Enemy didn't reach last waypoint
        if (waypointIndex <= waypoints.Length - 1)
        {

            // Move Enemy from current waypoint to the next one
            transform.position = Vector2.MoveTowards(transform.position,
               waypoints[waypointIndex].transform.position,
               moveSpeed * Time.deltaTime);

            // If Enemy reaches position of waypoint he walked towards then waypointIndex is increased by 1 and Enemy starts to walk to the next waypoint
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1; // Increasing index
            }
        }
        else
        {
            // Once the enemy has completed his path, reset the index
            waypointIndex = 0;
        }
    }

    /*
    * Wait Timer
    */
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
    }
}
