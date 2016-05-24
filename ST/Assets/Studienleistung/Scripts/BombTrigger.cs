using UnityEngine;
using System.Collections;

public class BombTrigger : MonoBehaviour {

	public int bombValue = 5;
	public delegate void TriggerEvent();
	public static event TriggerEvent onBombTrigger;

	private BoxCollider m_BoxCollider;
	private MeshRenderer m_MeshRenderer;
	private AudioSource m_Sound;
	// Use this for initialization
	void Start () {
		m_BoxCollider = gameObject.GetComponent<BoxCollider> ();
		m_MeshRenderer = gameObject.GetComponent<MeshRenderer> ();
		m_Sound = gameObject.GetComponent<AudioSource> ();
	
	}

	void OnTriggerEnter(Collider collider) {
		Debug.Log ("BOMBE");
		if (collider.gameObject.name == "Player") {

			EnableBomb (false);
			collider.gameObject.GetComponent<PlayerManager> ().reduceHealthPoints (10);
			m_Sound.Play ();
		}
	}

	public void EnableBomb (bool active) {
		m_BoxCollider.enabled = active;
		m_MeshRenderer.enabled = active;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
