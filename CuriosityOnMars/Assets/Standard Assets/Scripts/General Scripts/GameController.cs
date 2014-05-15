using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public bool gameOver = false;
	public bool placeStage = false;
	public bool moveItems = false;
	public bool win = false;
	public bool lose = false;
	public GUIText endlevel;

	// Use this for initialization
	void Start ()
	{
		gameObject.tag = "GameController";
		placeStage = true;
		moveItems = true;
		endlevel.text = "";
	}
	
	// Update is called once per frame
	void Update ()
	{
		//if (Input.GetKey(KeyCode.Mouse0)) {
		//	print ("CLICK!");
		//}
		if (Input.GetKey (KeyCode.Return) && placeStage) {
			placeStage = false;
			moveItems = false;
			//print ("can't place objects");
			endlevel.text = "";
		}

		if (gameOver) {
			//Application.LoadLevel(Application.loadedLevel);
			if (win) {
				gameOverText("You win!! Press Enter for the next level.");
				if (Input.GetKey (KeyCode.Return)) {
					Application.LoadLevel(Application.loadedLevel + 1);
					endlevel.text = "";
				}
			}
			else if (lose) {
				gameOverText("You fell into a pit! Press Enter to try again.");
				if (Input.GetKey (KeyCode.Return)) {
					Application.LoadLevel(Application.loadedLevel);
					endlevel.text = "";
				}
			}
		}
	}

	void OnGUI () {
		//not sure why the numbers are doubled when the game runs though..
		if(GUI.Button(new Rect(0,0,50,30), "Reset")) {
			Application.LoadLevel(Application.loadedLevel);
			//print ("reset!!");
		}
	}

	public void gameOverText(string reason)
	{
		endlevel.text = reason;
	}

}

