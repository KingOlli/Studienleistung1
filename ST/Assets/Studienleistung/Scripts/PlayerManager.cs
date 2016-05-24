using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	PlayerInputManager m_PlayerInputManager;

	public Transform spawnPosition;
	public delegate void PlayerEvent ( int m_currentPoints);
	public static event PlayerEvent onHealthChanged;
	private int m_StartHealth = 100;
	public int m_healthPoint;

	public int healthPoint {
		get{
			return m_healthPoint;
		}

		set {
			m_healthPoint = value;
		}
	}

	// Use this for initialization
	void Start () {
		Init ();
	}

	void Init() {
		m_PlayerInputManager = gameObject.GetComponent<PlayerInputManager> ();
		m_PlayerInputManager.Init ();
		m_PlayerInputManager.setPosition (spawnPosition);
		onHealthChanged(m_healthPoint);
	}

	public void setStartHealth() {
		m_healthPoint = m_StartHealth;
		onHealthChanged (m_healthPoint);
	}

	public void reduceHealthPoints(int value) {
		m_healthPoint -= value;
		onHealthChanged (m_healthPoint);
	}

	public void respawnPlayer() {
		m_PlayerInputManager.setPosition (spawnPosition);
	}
}
