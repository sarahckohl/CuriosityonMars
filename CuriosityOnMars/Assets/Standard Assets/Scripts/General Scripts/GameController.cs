using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public bool gameOver = false;
	public bool placeStage = false;
	public bool moveItems = false;

	// Use this for initialization
	void Start ()
	{
		placeStage = true;
		moveItems = true;
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
		}
	}

	void OnGUI () {
		//not sure why the numbers are doubled when the game runs though..
		if(GUI.Button(new Rect(0,0,50,30), "Reset")) {
			Application.LoadLevel(Application.loadedLevel);
			//print ("reset!!");
		}
	}

}

