using UnityEngine;
using System.Collections;

public class TriggerConsole : MonoBehaviour {

	public AudioSource sound;
	public GameObject d_trigger;
	public Door door;

	// Use this for initialization
	void Start () {
		Init ();
	}

	void Init() {
		sound = gameObject.GetComponent<AudioSource> ();
		door = d_trigger.GetComponent<Door> ();
	}

	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject.name == "Player") {
			sound.Play ();
		}
	}
		
	void OnTriggerStay (Collider collider) {
		if (collider.gameObject.name == "Player") {
			if (Input.GetKey(KeyCode.Space)) {
				Debug.Log ("OPEN");
				door.isOpen = true;
		}
	}
}
}
