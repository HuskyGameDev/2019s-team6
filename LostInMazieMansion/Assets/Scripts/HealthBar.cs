using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    private Transform bar;

	private void Awake () {
        bar = transform.Find("Bar");
	}

    public void SetSize(float sizeNormalized) {
        bar.localScale = new Vector2(sizeNormalized, 0.0925f);
    }

    public void SetColor(Color color) {
        bar.Find("BarSprite").GetComponent<SpriteRenderer>().color = color;
    }
}
