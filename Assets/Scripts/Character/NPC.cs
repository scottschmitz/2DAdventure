using UnityEngine;
using System.Collections;

public class NPC : Character {

	public void Awake() {
		isKillable = false;
	}

	public override void Die() {
		Debug.LogError ("Somehow the NPC is supposed to Die");
	}
}
