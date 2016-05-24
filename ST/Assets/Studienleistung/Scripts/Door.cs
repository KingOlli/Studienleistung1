using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public bool isOpen = false;
	public float openDepth = 0.0f;
	public float closeDepth = 2.0f;
	public float closeSpeed = 3f;

	// Use this for initialization
	//void Start () {
	
	//}
	
	// Update is called once per frame
	//void Update () {

	//}

	void FixedUpdate() {
		if (isOpen == true) {
				openDoor ();
			} else {
				closeDoor();
			}
	}

	void openDoor() {
		if (transform.position.y >= openDepth) {
			transform.Translate (Vector3.down * closeSpeed * Time.deltaTime);
		}
	}


	void closeDoor() {
		if (transform.position.y <= openDepth) {
			transform.Translate (Vector3.up * closeSpeed * Time.deltaTime);
		}
	}
	
	
}
