using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private string message = "#GameManager#: ";
	private BombTrigger[] bombs;
	private Door[] doors;
	private PlayerManager m_PlayerManager;
	public static int m_StartHealth = 100;

	// Use this for initialization
	void Start () {
		Init ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Init () {
		PlayerManager.onHealthChanged += playerHealthChanged;
		TriggerFinish.OnTargetReached += gameFinished;
		m_PlayerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
		m_PlayerManager.SetStarttHealth ();

		activateBombs ();
		findGameObjects ();
	}

	void closeDoors() {
		for ( int i=0; i< doors.Length; i ++) {
			doors[i].isOpen = false;
		}
	}

	void activateBombs() {
		for ( int i=0; i< bombs.Length; i ++) {
			 bombs[i].EnableBomb (false);
		}
	}

	void gameFinished() {
		activateBombs();
		closeDoors ();
		m_PlayerManager.respawnPlayer();
		m_PlayerManager.SetStarttHealth ();
	}


	void findGameObjects() {
		GameObject[] objs = GameObject.FindGameObjectsWithTag("Bomb");
		bombs = new BombTrigger [objs.Length];
		for (int i = 0; i < objs.Length; i++) {
			bombs [i] = objs [i].GetComponent<BombTrigger> ();
		}
		objs = GameObject.FindGameObjectsWithTag ("Door");
		doors = new Door [objs.Length];
		for (int i = 0; i < objs.Length; i++) {
			doors [i] = objs [i].GetComponent<Door> ();
		}
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
