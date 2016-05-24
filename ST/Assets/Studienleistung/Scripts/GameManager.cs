using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private string message = "#GameManager#: ";
	private BombTrigger[] bombs;
	private Door[] doors;
	private PlayerManager m_PlayerManager;
	public static int m_StartHealth = 100;
	private UI m_UI;

	// Use this for initialization
	void Start () {
		Init ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Init () {
		PlayerManager.onHealthChanged += playerHealthChanged;
		TriggerFinal.onTargetReached += gameFinished;
		m_PlayerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
		m_PlayerManager.setStartHealth();

		m_UI = GameObject.Find("Canvas").GetComponent<UI>();

		findGameObjects ();
		activateBombs ();

	}

	void closeDoors() {
		for ( int i=0; i< doors.Length; i ++) {
			doors[i].isOpen = false;
		}
	}

	void activateBombs() {
		for ( int i=0; i< bombs.Length; i ++) {
			 bombs[i].EnableBomb (true);
		}
	}

	void gameFinished() {
		activateBombs();
		closeDoors ();
		m_PlayerManager.respawnPlayer();
		m_PlayerManager.setStartHealth ();
	}


	void findGameObjects() {
		GameObject[] objs = GameObject.FindGameObjectsWithTag("Bombe");
		bombs = new BombTrigger [objs.Length];
		for (int i = 0; i < objs.Length; i++) {
			bombs [i] = objs [i].GetComponent<BombTrigger> ();
		}
		objs = GameObject.FindGameObjectsWithTag ("Door");
		doors = new Door [objs.Length];
		for (int i = 0; i < objs.Length; i++) {
			doors [i] = objs [i].GetComponent<Door> ();
		}

		Debug.Log (message + "Found " + doors.Length + " doors!");
	}

	void playerHealthChanged (int health) {
		if (m_PlayerManager.healthPoint <= 0) {
			gameLost ();
		}

	}

	void gameLost() {
		gameFinished ();

	}
}
