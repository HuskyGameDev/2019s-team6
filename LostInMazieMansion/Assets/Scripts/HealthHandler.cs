using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthHandler : MonoBehaviour {

    [SerializeField] private HealthBar healthBar;
    private Transform target; // Player
    float maxHPSize = .08f;
    int maxHP = 80;
    int currentHP;
    int damage = 20;

    private void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        currentHP = maxHP;
	}

    void Update()
    {
        if (currentHP <= 0)
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
            currentHP -= damage;
            maxHPSize -= .02f;
            healthBar.SetSize(maxHPSize);
        }
    }
}
