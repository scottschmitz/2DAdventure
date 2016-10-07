using UnityEngine;
using System.Collections;

public enum WeaponType { Melee, Range }

public class Weapon : MonoBehaviour {

	[SerializeField]
	protected float range;

	[SerializeField]
	[Range(0,180)]
	protected float rangeofMotion;

	[SerializeField]
	protected WeaponType weaponType;

	[SerializeField]
	protected float baseDamage;

	public void Attack(Character character) {
		switch (weaponType) {
		case WeaponType.Melee:
			AttackMelee (character);
			break;
		case WeaponType.Range:
			Debug.LogError ("Ranged weapon Attack not yet implemented.");
			break;
		default:
			Debug.LogError ("Attempting to Attack with an unhandled WeaponType");
			break;
		}
		if (Vector2.Angle (character.transform.position, character.transform.forward) <= rangeofMotion / 2f) {
		}
	}

	protected void AttackMelee(Character character) {
		Collider2D[] collidersInRange = Physics2D.OverlapCircleAll (character.transform.position, range);

		foreach (Collider2D collider in collidersInRange) {
			if (collider == character.GetComponent<Collider2D>()) {
				continue;
			}

			float angle = Vector2.Angle (character.transform.position, collider.transform.position);
			Vector3 cross = Vector3.Cross (character.transform.position, collider.transform.position);

			if (cross.z > 0) {
				angle = 360f - angle;
			}

			Debug.Log (angle);

			if (angle <= rangeofMotion / 2f) {
				Debug.Log("Hit the character");
			}
		}
	}
}
