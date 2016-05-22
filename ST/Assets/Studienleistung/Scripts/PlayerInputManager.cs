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

	private void Move() {

	}

	private void Rotate() {

	}

	// Update is called once per frame
	void FixedUpdate () {

	}
}
