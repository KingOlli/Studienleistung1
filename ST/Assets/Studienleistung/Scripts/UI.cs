using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	private float time;
	private float startTime;
	private string healthPoints = "Healthpoints: ";
	private GameObject mainScreen;
	private Text pointsV;
	private Text timeV;
	private Text messageTimeView;
	private GameObject button;
	bool won = false;
	private GameObject activeDoor;

	// Use this for initialization
	void Start () {
		Init ();
	}

	public void Init () {
		mainScreen = GameObject.Find ("Canvas/MainScreen");
		pointsV = GameObject.Find ("Canvas/Points").GetComponent<Text> ();
		timeV = GameObject.Find ("Canvas/Time").GetComponent<Text> ();
		messageTimeView = GameObject.Find ("Canvas/MainScreen/NeededTime").GetComponent<Text> ();
		button = GameObject.Find ("Canvas/Button");
		button.SetActive (false);
		mainScreen.SetActive (false);

		PlayerManager.onHealthChanged += updatePoints;
		TriggerConsole.onTriggerEntered += showButton;
		TriggerConsole.onTriggerLeft += hideButton;
		TriggerFinal.onTargetReached += gameFinished;

		startTime = Time.time;
	}

	void showButton (GameObject door) {
		button.SetActive (true);
		activeDoor = door;
	
	}

	void hideButton (GameObject door) {
		button.SetActive (false);
		activeDoor = null;
	}

	void updatePoints (int points) {
		pointsV.text = healthPoints + points;
	}

	void gameFinished () {
		mainScreen.SetActive (true);
		time = Time.time - startTime;
		messageTimeView.text = "Only " + (int)time + "seconds to win!";

		won = true;
	}

	void resetMessageScreen() {
		mainScreen.SetActive (false);
		startTime = Time.time;
	}

	public void onDoorButtonClicked() {
		if (activeDoor != null) {
			activeDoor.GetComponent<Door> ().isOpen = true;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timeV.text = (int)(Time.time - startTime) + " seconds";

		if (won && (time + 5) < Time.time) {
			won = false;
			resetMessageScreen ();
		}
	}
		
}
