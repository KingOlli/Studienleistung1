using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public bool isClosed = true;
	public float unlockDepth = 0.0f;
	public float closeDepth = 2.0f;
	public float closeSpeed = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		if (isClosed == true) {
				openDoor ();
			} else {
				closeDoor();
			}
	}

	void openDoor() {

	}


	void closeDoor() {

	}
	
	
}
