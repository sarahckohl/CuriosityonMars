using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public static bool gameOver = false;
	public static bool placeStage = false;
	public static bool moveItems = false;
	public static bool win = false;
	public static bool lose = false;
	public GUIText endlevel;
	public int currentlength = 0;
	public GameObject[] Attracts;
	public GameObject[] passables;
	public GameObject[] Repels;
	public GameObject[] Players;
	public GameObject[] Impasses;
	public GameObject[] Destructs;
	public GameObject[] nooverlap;
	public GameObject[] Impassables;
	private Vector3 initialRoverPosition;
	public control_rover rover;
	public GameObject currentInfluencer;
	public Texture resetButton;
	
	
	void Awake() {
		initialRoverPosition = rover.transform.position;
		Attracts = GameObject.FindGameObjectsWithTag("Attract");
		passables = GameObject.FindGameObjectsWithTag("passable");
		Repels = GameObject.FindGameObjectsWithTag("Repel");
		Players = GameObject.FindGameObjectsWithTag("Player");
		Impasses = GameObject.FindGameObjectsWithTag("Impass");
		Destructs = GameObject.FindGameObjectsWithTag("Destruct");
		
		//GameObject[Attracts.Length+passables.Length+Repels.Length+Players.Length+Impasses.Length-5];
		Impassables = new GameObject[Attracts.Length + Repels.Length + Impasses.Length];
		Attracts.CopyTo (Impassables, 0);
		Repels.CopyTo (Impassables, Attracts.Length);
		Impasses.CopyTo (Impassables, (Attracts.Length + Repels.Length));
		
		nooverlap = new GameObject[100];
		Attracts.CopyTo (nooverlap,currentlength);
		currentlength += Attracts.Length;
		
		passables.CopyTo (nooverlap,currentlength);
		currentlength += passables.Length;
		
		Repels.CopyTo (nooverlap,currentlength);
		currentlength += Repels.Length;
		
		Players.CopyTo (nooverlap,currentlength);
		currentlength += Players.Length;
		
		Impasses.CopyTo (nooverlap,currentlength);
		currentlength += Impasses.Length;
		
		Destructs.CopyTo (nooverlap,currentlength);
		currentlength += Destructs.Length;
		/*
		for (int i = 0; i < currentlength; i++){
				//print (foo.transform.position.x+  ", " + foo.transform.position.y);
			print (nooverlap[i].transform.position.x+  ", " + nooverlap[i].transform.position.y);
		}
		*/
		gameOverText("");
		win = false;
		lose = false;
		gameOver = false;
	}
	
	// Use this for initialization
	void Start ()
	{
		gameObject.tag = "GameController";
		placeStage = true;
		moveItems = true;
		endlevel.text = "";
		/*
		Attracts = GameObject.FindGameObjectsWithTag("Attract");
		passables = GameObject.FindGameObjectsWithTag("passable");
		Repels = GameObject.FindGameObjectsWithTag("Repel");
		Players = GameObject.FindGameObjectsWithTag("Player");
		Impasses = GameObject.FindGameObjectsWithTag("Impass");

		//GameObject[Attracts.Length+passables.Length+Repels.Length+Players.Length+Impasses.Length-5];
		nooverlap = new GameObject[100];

		Attracts.CopyTo (nooverlap,currentlength);
		currentlength += Attracts.Length;
		
		passables.CopyTo (nooverlap,currentlength);
		currentlength += passables.Length;
		
		Repels.CopyTo (nooverlap,currentlength);
		currentlength += Repels.Length;
		
		Players.CopyTo (nooverlap,currentlength);
		currentlength += Players.Length;
		
		Impasses.CopyTo (nooverlap,currentlength);
		currentlength += Impasses.Length;
		*/
		
		
		//foreach (GameObject foo in nooverlap){
		//	print (foo.transform.position.x+  ", " + foo.transform.position.y);
		//}
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
					gameOverText("");
					gameOver = false;
					print ("print1");
					Application.LoadLevel(Application.loadedLevel + 1);
				}
			}
			else if (lose) {
				gameOverText("You fell into a pit! Press Enter to try again.");
				if (Input.GetKey (KeyCode.Return)) {
					gameOverText("");
					gameOver = false;
					print ("print2");
					Application.LoadLevel(Application.loadedLevel);
				}
			}
		}
	}
	
	void OnGUI () {

		GUI.backgroundColor = new Color(0,0,0,0);
		//not sure why the numbers are doubled when the game runs though..
		if(GUI.Button(new Rect(0,0,resetButton.width,resetButton.height), resetButton)) {
			gameOverText("");
			gameOver = false;
			rover.transform.position = initialRoverPosition;
			placeStage = true;
			moveItems = true;
			endlevel.text = "";
			win = false;
			lose = false;
			//Application.LoadLevel(Application.loadedLevel);
			//print ("reset!!");
		}
	}
	
	public void gameOverText(string reason)
	{
		endlevel.text = reason;
	}
	
}

