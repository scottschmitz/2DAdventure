using UnityEngine;
using System.Collections;

public class Player : Character {

	protected bool pressedSpace = false;

	public Weapon weapon;

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

		if (Input.GetKeyDown(KeyCode.Space)) {
			pressedSpace = true;
		}

		velocity = new Vector2(x, y);
	}

	public void FixedUpdate() {
		base.FixedUpdate ();

		if (pressedSpace) {
			Debug.Log ("pressed space");
			pressedSpace = false;
			weapon.Attack (this);
		}
	}

	public override void Die() {
		Debug.Log ("Oh dear, the Player has died");
	}
}
