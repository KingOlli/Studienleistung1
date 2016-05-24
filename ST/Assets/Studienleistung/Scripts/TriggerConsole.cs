using UnityEngine;
using System.Collections;

public class TriggerConsole : MonoBehaviour {

	public AudioSource sound;
	public Door door;

	public delegate void ConsoleEvent(GameObject console);
	public static event ConsoleEvent onTriggerEntered;
	public static event ConsoleEvent onTriggerLeft;

	// Use this for initialization
	void Start () {
		Init ();
	}

	void Init() {
		sound = gameObject.GetComponent<AudioSource> ();
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
