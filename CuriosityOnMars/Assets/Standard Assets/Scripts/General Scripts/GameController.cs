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
			print ("can't place objects");
		}
	}

	void OnGUI () {
		if(GUI.Button(new Rect(600,640,50,30), "Reset")) {
			Application.LoadLevel("InGame");
			print ("reset!!");
		}
	}

}

