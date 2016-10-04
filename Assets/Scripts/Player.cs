using UnityEngine;
using System.Collections;

public class Player : Character {

	public void Update() {

		float x = 0.0f;
		float y = 0.0f;

		if (Input.GetKey (KeyCode.A)) {
			x = -1.0f;
		} else if (Input.GetKey (KeyCode.D)) {
			x = 1.0f;
		}

		if (Input.GetKey (KeyCode.S)) {
			y = -1.0f;
		} else if (Input.GetKey (KeyCode.W)) {
			y = 1.0f;
		}

		velocity = new Vector2(x, y);
	}

	public override void Die() {
		Debug.Log ("Oh dear, the Player has died");
	}
}
