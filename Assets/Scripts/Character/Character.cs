using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {

	[SerializeField]
	new protected Rigidbody2D rigidbody;

	[SerializeField]
	protected bool isKillable = true;

	[SerializeField]
	protected int maxHealth;

	[SerializeField]
	protected int currentHealth;

	protected Vector2 velocity = new Vector2(0.0f, 0.0f);

	public abstract void Die ();

	public void FixedUpdate() {
		rigidbody.velocity = Vector2.ClampMagnitude(velocity * CharacterManager.Instance.Speed, CharacterManager.Instance.Speed);
	}

	public void takeDamage(int damage) {
		if (isKillable) {
			currentHealth -= damage;

			if (currentHealth <= 0) {
				Die ();
			}
		}
	}
}
