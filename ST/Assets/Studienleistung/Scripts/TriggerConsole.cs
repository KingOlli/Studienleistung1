using UnityEngine;
using System.Collections;

public class TriggerConsole : MonoBehaviour {

	public AudioSource sound;
	public GameObject tDoor;
	public Door door;

	public delegate void ConsoleEvent(GameObject console);
	public static event ConsoleEvent OnTriggerEntered;
	public static event ConsoleEvent OnTriggerLeft;

	// Use this for initialization
	void Start () {
		Init ();
	}

	void Init() {
		sound = gameObject.GetComponent<AudioSource> ();
		door = tDoor.GetComponent<Door> ();
	}

	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject.name == "Player") {
			sound.Play ();
			Debug.Log (tDoor + "zgzgz");
			OnTriggerEntered (tDoor);
		}
	}

	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.name == "Player") {
			OnTriggerLeft (tDoor);
		}
	}
		
	void OnTriggerStay (Collider collider) {
		if (collider.gameObject.name == "Player") {
			if (Input.GetKey(KeyCode.Space)) {
				door.isOpen = true;
		}
	}
}
}
