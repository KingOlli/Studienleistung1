using UnityEngine;
using System.Collections;

public class TriggerFinal : MonoBehaviour {

	public delegate void TriggerEvent();
	public static event TriggerEvent onTargetReached;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.name == "Player") {
			onTargetReached ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
