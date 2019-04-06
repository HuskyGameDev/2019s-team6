using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Stats
    public int currentHP;
    public int maxHP = 90;
    int damage = 30;

    private Transform target; // Player

    // Start is called before the first frame update
    void Start()
    {
        // Set current to max when start
        currentHP = maxHP;

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHP <= 0)
        {
            Die(); // If the player no longer has health left, die
        }
    }

    void Die()
    {
        // Reload Level
        Application.LoadLevel(Application.loadedLevel);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks if the collision was with an enemy
        if (collision.tag == "Enemy")
        {
            currentHP -= damage; // Reduces health by 1/3 if enemy hits player
        }
    }
}
