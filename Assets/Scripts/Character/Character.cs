using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {

	protected static string WALK_UP = "Walk_Up";
	protected static string WALK_RIGHT = "Walk_Right";
	protected static string WALK_DOWN = "Walk_Down";
	protected static string WALK_LEFT = "Walk_Left";

	[SerializeField]
	protected bool isKillable = true;

	[SerializeField]
	protected int maxHealth;

	[SerializeField]
	protected int currentHealth;

	protected Vector2 velocity = new Vector2(0.0f, 0.0f);
	new protected Rigidbody2D rigidbody;

	protected CharacterAnimator characterAnimator;
	protected Animator animator;

	public abstract void Die ();

	public void Start() {
		rigidbody = this.GetComponent<Rigidbody2D> ();
		if (rigidbody == null) {
			Debug.LogError ("Character does not have a Rigidbody2D");
		}

		characterAnimator = this.GetComponent<CharacterAnimator> ();
		if (characterAnimator == null) {
			Debug.LogError ("Character does not have a CharacterAnimator");
		}

		animator = this.GetComponent<Animator> ();
		if (animator == null) {
			Debug.LogError ("Character does not have an Animator");
		} 
	}

	public void FixedUpdate() {
		rigidbody.velocity = Vector2.ClampMagnitude(velocity * CharacterManager.Instance.Speed, CharacterManager.Instance.Speed);

		if (rigidbody.velocity.x > 0) {
			animator.SetInteger ("VelocityX", 1);
			animator.SetInteger ("VelocityY", 0);
		} else if (rigidbody.velocity.x < 0) {
			animator.SetInteger ("VelocityX", -1);
			animator.SetInteger ("VelocityY", 0);
		} else if (rigidbody.velocity.y > 0) {
			animator.SetInteger ("VelocityX", 0);
			animator.SetInteger ("VelocityY", 1);
		} else if (rigidbody.velocity.y < 0) {
			animator.SetInteger ("VelocityX", 0);
			animator.SetInteger ("VelocityY", -1);
		} else {
			animator.SetInteger ("VelocityX", 0);
			animator.SetInteger ("VelocityY", 0);
		}
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
