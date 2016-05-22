using UnityEngine;
using System.Collections;

public class PlayerInputManager : MonoBehaviour {

	private Rigidbody m_rigidbody;

	public float speedBoost = 5.0f;
	public float rotationBoost = 50.0f;
	private string m_MovementAxis = "Move";
	private string m_RotationAxis = "Rotate";
	private float m_MovementInput;
	private float m_RoationInput;



	//Tank-Tutorial

	// Use this for initialization
	void Start () {
		Init ();
	}

	void Init() {
		m_rigidbody = gameObject.GetComponent<Rigidbody> ();
	}

	private void Move() {
		m_MovementInput = Input.GetAxis (m_MovementAxis);

		Vector3 movement = transform.forward * speedBoost * Time.deltaTime;
		m_rigidbody.MovePosition (m_rigidbody.position + movement);

	}

	private void Rotate() {
		m_RoationInput = Input.GetAxis (m_RotationAxis);

		float turn = m_RoationInput * rotationBoost * Time.deltaTime;
		Quaternion rotation = Quaternion.Euler (0f, turn, 0f);
		m_rigidbody.MoveRotation (m_rigidbody.rotation * rotation);
	
	}

	// Update is called once per frame
	void FixedUpdate () {
		Move ();
		Rotate ();
	}
}
