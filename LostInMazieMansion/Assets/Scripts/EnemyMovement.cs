using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed; // Enemy Movement Speed
    private Transform target; // Player

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the distance between the target(player) and the enemy is less than 3,
        if(Vector2.Distance(transform.position, target.position) < 3)
        {
            // Then the enemy will follow the target(player) at the given speed
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        
    }
}
