using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour {

	protected static CharacterManager _instance;

	[SerializeField]
	protected float speed = 7.0f;

	/*
	* Find/Create/Return our one and only Game Manager object
	* for the game
	**/
	public static CharacterManager Instance {
		get {
			// if we do not have an instance already, lets look to see
			// if one has already been created for us
			if (_instance == null) {
				_instance = Object.FindObjectOfType<CharacterManager>();
			}

			// If we still dont have an instance, one must not be created
			// so lets create our own and prevent it from being deleted
			// when the level changes
			if (_instance == null)
			{
				GameObject go = new GameObject("_CharacterManager");
				_instance = go.AddComponent<CharacterManager>();
				DontDestroyOnLoad(go);
			}

			return _instance;
		}
	}

	public float Speed {
		get {
			return speed;
		}
	}
}
