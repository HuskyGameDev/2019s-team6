using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    private Transform bar;

    // Find Health Bar Object
	private void Awake () {
        bar = transform.Find("Bar");
	}

    // Set Healht to the Argument
    public void SetSize(float sizeNormalized) {
        bar.localScale = new Vector2(sizeNormalized, 0.0925f);
    }

    // Sets the color of the health bar
    public void SetColor(Color color) {
        bar.Find("BarSprite").GetComponent<SpriteRenderer>().color = color; // Automatically sets sprite color
    }
}
