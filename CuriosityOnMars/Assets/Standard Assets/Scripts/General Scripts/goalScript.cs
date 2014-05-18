using UnityEngine;
using System.Collections;

public class goalScript : MonoBehaviour {
	private control_rover rover;
	//private GameController gameController;
	// Use this for initialization
	void Start () {
		//rover = GameObject.FindGameObjectWithTag ("Player");
		GameObject roverObject = GameObject.FindWithTag ("Player");
		if (roverObject != null) {
			rover = roverObject.GetComponent <control_rover>();
		}
		//GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		//if (gameControllerObject != null) {
		//	gameController = gameControllerObject.GetComponent <GameController>();
		//}
		//gameObject.tag = "Goal";
	}
	
	// Update is called once per frame
	void Update () {
		if (rover.transform.position == this.transform.position) {
			// move to next scene
			//Application.LoadLevel(Application.loadedLevel + 1);
			rover.shouldMove = false;
			GameController.win = true;
			GameController.lose = false;
			GameController.gameOver = true;
				}
	}
}
