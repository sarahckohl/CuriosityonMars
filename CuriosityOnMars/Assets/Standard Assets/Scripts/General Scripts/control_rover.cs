using UnityEngine;
using System.Collections;
using System;
using System.Timers;

public class control_rover : MonoBehaviour {
	
	public enum Direction
	{
		Left, Right, Up, Down, Stop
	}
	public Direction dir = Direction.Stop;
	public System.Timers.Timer movementTimer;
	public bool shouldMove;
	//public GameObject[] repellers;
	//public GameObject[] attractors;
	//public GameObject[] impasses;
	public bool impassable = false;
	private GameController GameController;
	public GameObject currentInfluencer;
	public Sprite leftImage, rightImage, upImage, downImage;
	
	
	// Use this for initialization
	void Start () {
		GameObject GameControllerObject = GameObject.FindWithTag ("GameController");
		if (GameControllerObject != null) {
			GameController = GameControllerObject.GetComponent <GameController>();
		}


		movementTimer = new System.Timers.Timer (1000);
		movementTimer.Elapsed += new ElapsedEventHandler (OnEverySecond);
		movementTimer.Enabled = true;
		shouldMove = false;
		impassable = false;
		gameObject.tag = "Player";
		print (GameController.Impassables.Length);
		foreach (GameObject foo in GameController.Impassables) {
			print (foo);
		}
	}

	void OnTriggerEnter(Collider col) {
		/*
		if ( col.tag == "Impass" || col.tag == "Attract") {
			Debug.Log("collide");
			impassable = true;
			return;
		}
		*/
		if (col.tag == "Destruct") {
			if (col.transform.position == gameObject.transform.position){
				print ("destruct");
				shouldMove = false;
				GameController.lose = true;
				GameController.win = false;
				GameController.gameOver = true;
				//Application.LoadLevel(Application.loadedLevel);
				//rover_gameover.SetBool("collide_destruct", true);
			}
		}
	} 

	
	// Update is called once per frame
	void Update () {
		// lower left coordinates: 1, 3
		// lower right: 8, 3
		// upper left: 1, 8
		// upper right: 8, 8


		//print (this == GameController.Players [0]);


		// will move once a second in the given direction, unless it is outside of its boundary
		if (dir != Direction.Stop && shouldMove ) 
		{
			if(this.dir == Direction.Right)
			{
				GetComponent<SpriteRenderer>().sprite = rightImage;
				// make sure it does not go over 8
				if(this.transform.position.x < 10)
				{
					// make sure there is not an impasse to the right.

					
					//if(!impassable){
						//print (this.transform.position.x + ", " + GameController.Impasses[1].transform.position.x);
						for (int i = 0; i < GameController.Impassables.Length; i++){
							if(this.transform.position.x+1 == (int)GameController.Impassables[i].transform.position.x
						   && this.transform.position.y == (int)GameController.Impassables[i].transform.position.y) { 
								//if (this.transform.position.x+1){
								impassable = true;
								break;
							}else{
								impassable = false;
							}
						}
					if (!impassable)
						this.transform.position = new Vector2(this.transform.position.x + 1, this.transform.position.y);
					//}
				}
			}else if(this.dir == Direction.Left)
			{
				// make sure this does not go less than 1
				if (this.transform.position.x > 1)
				{
					GetComponent<SpriteRenderer>().sprite = leftImage;
					// make sure there is not an impasse to the left.
					//if(!impassable){
					//print(this.transform.position.x + ", " + this.transform.position.y + "  " + (int)GameController.Impasses[0].transform.position.x + ", " + (int)GameController.Impasses[0].transform.position.y);
					//print (impassable);
					//print (this.transform.position.x-1 + ", " + GameController.Attracts[0].transform.position.x);
					for (int i = 0; i < GameController.Impassables.Length; i++){
						if(this.transform.position.x-1 == (int)GameController.Impassables[i].transform.position.x
						   && this.transform.position.y == (int)GameController.Impassables[i].transform.position.y) { 
							//if (this.transform.position.x+1){
							impassable = true;
							break;
						}else{
							impassable = false;
						}
					}
					if (!impassable)
						this.transform.position = new Vector2(this.transform.position.x - 1, this.transform.position.y);
					//}
				}
			}else if(this.dir == Direction.Up)
			{
				// keep its boundary
				if (this.transform.position.y < 9)
				{
					// make sure there is not an impasse upwards
					GetComponent<SpriteRenderer>().sprite = upImage;
					//if(!impassable){
					print (this.transform.position.x + ", " + (int)GameController.Impasses[0].transform.position.x);
					for (int i = 0; i < GameController.Impassables.Length; i++){
						if(this.transform.position.y+1 == (int)GameController.Impassables[i].transform.position.y 
						   && this.transform.position.x == (int)GameController.Impassables[i].transform.position.x) { 
							//if (this.transform.position.x+1){
							impassable = true;
							break;
						}else{
							impassable = false;
						}
					}
					if (!impassable)
						this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 1);
					//}
				}
			}else if(this.dir == Direction.Down)
			{
				// make sure the rover does not go down off play area
				if (this.transform.position.y > 1)
				{
					// make sure there is not an impasse downwards
					GetComponent<SpriteRenderer>().sprite = downImage;
					//if(!impassable){
					for (int i = 0; i < GameController.Impassables.Length; i++){
						print (this.transform.position.y + ", " + GameController.Impasses[0].transform.position.y);
						if(this.transform.position.y-1 == (int)GameController.Impassables[i].transform.position.y
						   && this.transform.position.x == (int)GameController.Impassables[i].transform.position.x) { 
							//if (this.transform.position.x+1){
							impassable = true;
							break;
						}else{
							impassable = false;
						}
					}
					if (!impassable)
						this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 1);
					//}
				}
			}
			
			
			// since we have moved, we should not move again for another second.
			shouldMove = false;
		}
		else if(this.dir == Direction.Stop){
			shouldMove = false;
		}
	}


	private void OnEverySecond(object source, ElapsedEventArgs e)
	{
		//when placeStage is false, the rover can now move when it's on an impeller
		//else if placeStage is true, it will not move
		
		// move the rover in the given direction
		if (!GameController.placeStage && !impassable && !GameController.gameOver) {
			shouldMove = true;
		}
		if (impassable) {
			shouldMove = false;
		}
	}

	/*
	// Returns true if there is an impass at Vector3 location
	private Boolean impassAt(Vector3 location)
	{
		// loop through each impass
		for (int i = 0; i < impasses.Length; i++) 
		{
			// see if there is an impasse at location
			if(impasses[i].transform.position == location)
				return true;
		}
		// if there is none, return false
		return false;
	}
	
	// returns true if there is an attractor at Vector3 location
	private Boolean attractorAt(Vector3 location)
	{
		// loop through each attractor
		for(int i = 0; i < attractors.Length; i++)
		{
			// if there is an attractor at location
			if(attractors[i].transform.position == location)
				return true;
		}
		return false;
	}
	
	// returns true if there is a repeller at Vector3 location
	private Boolean repellerAt(Vector3 location)
	{
		for (int i = 0; i < repellers.Length; i++) 
		{
			// if there is a repeller at location
			if(repellers[i].transform.position == location)
				return true;
		}
		return false;
	}
	
	// returns true if there is a repeller, attractor, or impass at that location
	private Boolean obstaclesAt(Vector3 location)
	{
		return impassAt (location) || attractorAt (location) || repellerAt (location);
	}
	*/
}
