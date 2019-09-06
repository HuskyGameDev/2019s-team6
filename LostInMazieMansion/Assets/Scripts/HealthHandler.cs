using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthHandler : MonoBehaviour {

    [SerializeField] private HealthBar healthBar = null;
    private Transform target = null; // Player
    float maxHPSize = .08f; // Max HP Bar Size
    int maxHP = 80; // Total HP
    int currentHP; // Current HP out of Max
    int damage = 20; // Damage Modifier

    private void Start () {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // Get Player
        currentHP = maxHP; // Set current HP to Max
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks if the collision was with an enemy
        if (collision.tag == "Enemy")
        {
            currentHP -= damage; // Take Damage off of Health
            maxHPSize -= .02f; // Reduce bar size
            healthBar.SetSize(maxHPSize);
        }
    }
}
