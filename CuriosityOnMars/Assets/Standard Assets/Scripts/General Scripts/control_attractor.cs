﻿using UnityEngine;
using System.Collections;

public class control_attractor : MonoBehaviour {
	public Sprite range3;
	public Sprite range4;
	public Sprite range5;
	public Sprite range6;
	private Color mouseOverColor = Color.cyan;
	private Color originalColor;
	private Color rangeColor;
	private SpriteRenderer spriteRenderer; 
	public control_rover rover;
	public bool collideAttract = false;
	public bool activateAttract = false;
	public int attractRange = 3;
	Vector3 originalPosition;
	bool hover;
	float roverDistancex;
	float roverDistancey;
	GameObject[] tiles;
	GameObject[] nooverlap;
	private GameController GameController;
	GameObject GameControllerObject;
	// Use this for initialization

	void Awake () {

		originalPosition = this.transform.position;

		spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
		if (spriteRenderer.sprite == null){ // if the sprite on spriteRenderer is null then
			spriteRenderer.sprite = range3; // set the sprite to sprite1

			rangeColor = gameObject.renderer.material.color;
		}
		else if (attractRange == 4){
			//spriteRenderer.sprite = range4;
			gameObject.renderer.material.color = rangeColor = new Color(1, .1f, .1f);
		}
		else if (attractRange == 5){
			//spriteRenderer.sprite = range5;
			gameObject.renderer.material.color = rangeColor = new Color(.973f, .153f, .984f);
		}
		else if (attractRange >= 6){
			//spriteRenderer.sprite = range6;
			gameObject.renderer.material.color = rangeColor = new Color(0,.851f, .965f);
		}
	}

	void Start () {


		hover = false;
		tiles = GameObject.FindGameObjectsWithTag("map");

		if (GameControllerObject == null) {
			GameControllerObject = GameObject.FindWithTag ("GameController");
		}
		if (GameControllerObject != null) {
			GameController = GameControllerObject.GetComponent <GameController>();
		}

		//print (GameController.currentlength);
		//for (int i = 0; i < GameController.currentlength; i++){
			//print (foo.transform.position.x+  ", " + foo.transform.position.y);
		//	print (GameController.nooverlap[i].transform.position.x+  ", " + GameController.nooverlap[i].transform.position.y);
		//}

		//originalColor = tiles [1].renderer.material.color;
		originalColor = Color.clear;
		/*
		spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
		if (spriteRenderer.sprite == null){ // if the sprite on spriteRenderer is null then
			spriteRenderer.sprite = range3; // set the sprite to sprite1
		}
		else if (attractRange == 4){
			//spriteRenderer.sprite = range4;
			gameObject.renderer.material.color = new Color(1, .1f, .1f);
		}
		else if (attractRange == 5){
			//spriteRenderer.sprite = range5;
			gameObject.renderer.material.color = new Color(.973f, .153f, .984f);
		}
		else if (attractRange >= 6){
			//spriteRenderer.sprite = range6;
			gameObject.renderer.material.color = new Color(0,.851f, .965f);
		}
		*/
		collideAttract = false;
		gameObject.tag = "Attract";
	}



	void OnMouseUp(){

		for (int i=0; i<GameController.currentlength; i++) {
			if((GameController.nooverlap[i].transform.position==gameObject.transform.position)&&(GameController.nooverlap[i]!=gameObject))		
			   {
				gameObject.transform.position = originalPosition;
			   	break;
			}
		}


	}


	void OnMouseEnter(){
		hover = true;

		/*foreach (GameObject tile in tiles) {
		if(tile.renderer.material.color!=Color.clear)		
				return;
		}*/

		foreach (GameObject tile in tiles) {


			float tileDistancex = Mathf.Abs (Mathf.Abs (tile.transform.position.x) - Mathf.Abs (this.transform.position.x));
			float tileDistancey = Mathf.Abs (Mathf.Abs (tile.transform.position.y) - Mathf.Abs (this.transform.position.y));


			if( (tile.transform.position.x==this.transform.position.x && tileDistancey <= attractRange) || (tile.transform.position.y==this.transform.position.y && tileDistancex <= attractRange) )
			tile.renderer.material.color = mouseOverColor;	
		}


	}



	void OnMouseDown()	
	{	
		foreach (GameObject tile in tiles) {
			//float tileDistancex = Mathf.Abs (Mathf.Abs (tile.transform.position.x) - Mathf.Abs (this.transform.position.x));
			//float tileDistancey = Mathf.Abs (Mathf.Abs (tile.transform.position.y) - Mathf.Abs (this.transform.position.y));
			
			//if( (tile.transform.position.x==this.transform.position.x && tileDistancex <= attractRange) || (tile.transform.position.y==this.transform.position.y && tileDistancey <= attractRange) )
				tile.renderer.material.color = originalColor;
		}
	}


	void OnMouseExit(){
		hover = false;
		
		foreach (GameObject tile in tiles) {
			//float tileDistancex = Mathf.Abs (Mathf.Abs (tile.transform.position.x) - Mathf.Abs (this.transform.position.x));
			//float tileDistancey = Mathf.Abs (Mathf.Abs (tile.transform.position.y) - Mathf.Abs (this.transform.position.y));
			
			//if( (tile.transform.position.x==this.transform.position.x && tileDistancex <= attractRange) || (tile.transform.position.y==this.transform.position.y && tileDistancey <= attractRange) )
				tile.renderer.material.color = originalColor;
		}
	}

	// Update is called once per frame
	void Update () {
		if (this.transform.position.y < 1)
						return;

		roverDistancex = Mathf.Abs (Mathf.Abs (rover.transform.position.x) - Mathf.Abs (this.transform.position.x));
		roverDistancey = Mathf.Abs (Mathf.Abs (rover.transform.position.y) - Mathf.Abs (this.transform.position.y));


		//check if the rover needs to go up or down
		if (rover.transform.position.y == this.transform.position.y) {
			if (rover.impassable && !collideAttract) {
				rover.impassable = false;

			}

			//checks if the rover is in range of the attractor
			if (roverDistancex <= attractRange) {
				//print ("mathx: " + roverDistancex));
				if (rover.transform.position.x > this.transform.position.x) {
					//checks if rover.x is greater than this.x for left or right
					if (LineofSight("right")) {
						rover.dir = control_rover.Direction.Left;
					}
				} 
				else {
					if (LineofSight("left")) {
						rover.dir = control_rover.Direction.Right;
					}
	
				}

			}
			//else if (Mathf.Abs (Mathf.Abs (rover.transform.position.x) - Mathf.Abs (this.transform.position.x)) >= attractRange) {
				//when the rover reaches the max range, it stops
				//disabling the timer was the only way I could get it to stop
			//	rover.movementTimer.Enabled = false;
			//}
		} 
		else if (rover.transform.position.x == this.transform.position.x) {
			if (rover.impassable && !collideAttract) {
				rover.impassable = false;
			}

			//checks if the rover is in range of the attractor
			if (roverDistancey <= attractRange) {
				//print ("mathy: " + Mathf.Abs(Mathf.Abs (rover.transform.position.y) - Mathf.Abs (this.transform.position.y)));
				if (rover.transform.position.y > this.transform.position.y) {
					//checks if rover.y is greater than this.y for up or down
					if (LineofSight("up")) {
						rover.dir = control_rover.Direction.Down;
					}
				} else {
					if (LineofSight("down")) {
						rover.dir = control_rover.Direction.Up;
					}
				}
			}
			//else if (Mathf.Abs (Mathf.Abs (rover.transform.position.y) - Mathf.Abs (this.transform.position.y)) >= attractRange) {;
				//when the rover reaches the max range, it stops
				//disabling the timer was the only way I could get it to stop
			//	rover.movementTimer.Enabled = false;
			//}
		} 
	}


	bool LineofSight(string roverDirection){
		if (roverDirection.Equals("left")) {
			int currentX = (int)this.transform.position.x-1;
			//print ("currentX: " + currentX);
			//print ("rover: " + rover.transform.position.x);

			while (currentX > rover.transform.position.x) {
				for (int i = 0; i < GameController.Impasses.Length; i++){
					if(currentX == (int)GameController.Impasses[i].transform.position.x  && this.transform.position.y == (int)GameController.Impasses[i].transform.position.y) { 
						//print ("impasses");
						return false;
					}
				}
				for (int i = 0; i < GameController.Repels.Length; i++){
					if(currentX == (int)GameController.Repels[i].transform.position.x  && this.transform.position.y == (int)GameController.Repels[i].transform.position.y) {
						//print ("repels");
						return false;
					}
				}
				for (int i = 0; i < GameController.Attracts.Length; i++){
					if(currentX == (int)GameController.Attracts[i].transform.position.x  && this.transform.position.y == (int)GameController.Attracts[i].transform.position.y && GameController.Attracts[i] != this) {
						//print ("attracts");
						return false;
					}
				}
				//print (currentX);
				currentX-=1;
			}
		}

		if (roverDirection.Equals("right")) {
			int currentX = (int)this.transform.position.x+1;
			//print ("currentX: " + currentX);
			//print ("rover: " + rover.transform.position.x);
			
			while (currentX < rover.transform.position.x) {
				for (int i = 0; i < GameController.Impasses.Length; i++){
					if(currentX == (int)GameController.Impasses[i].transform.position.x && this.transform.position.y == (int)GameController.Impasses[i].transform.position.y) { 
						//print ("impasses");
						return false;
					}
				}
				for (int i = 0; i < GameController.Repels.Length; i++){
					if(currentX == (int)GameController.Repels[i].transform.position.x && this.transform.position.y == (int)GameController.Repels[i].transform.position.y) {
						//print ("repels");
						return false;
					}
				}
				for (int i = 0; i < GameController.Attracts.Length; i++){
					if(currentX == (int)GameController.Attracts[i].transform.position.x  && this.transform.position.y == (int)GameController.Attracts[i].transform.position.y && GameController.Attracts[i] != this) {
						//print ("attracts");
						return false;
					}
				}
				//print (currentX);
				currentX+=1;
			}
		}

		if (roverDirection.Equals("up")) {
			int currentY = (int)this.transform.position.y+1;
			//print ("currentY: " + currentY);
			//print ("rover: " + rover.transform.position.x);
			
			while (currentY < rover.transform.position.y) {
				for (int i = 0; i < GameController.Impasses.Length; i++){
					if(currentY == (int)GameController.Impasses[i].transform.position.y  && this.transform.position.x == (int)GameController.Impasses[i].transform.position.x) { 
						//print ("impasses");
						return false;
					}
				}
				for (int i = 0; i < GameController.Repels.Length; i++){
					if(currentY == (int)GameController.Repels[i].transform.position.y  && this.transform.position.x == (int)GameController.Repels[i].transform.position.x) {
						//print ("repels");
						return false;
					}
				}
				for (int i = 0; i < GameController.Attracts.Length; i++){
					if(currentY == (int)GameController.Attracts[i].transform.position.y  && this.transform.position.x == (int)GameController.Attracts[i].transform.position.x && GameController.Attracts[i] != this) {
						//print ("attracts");
						return false;
					}
				}
				//print (currentY);
				currentY+=1;
			}
		}

		if (roverDirection.Equals("down")) {
			int currentY = (int)this.transform.position.y-1;
			//print ("currentY: " + currentY);
			//print ("rover: " + rover.transform.position.x);
			
			while (currentY > rover.transform.position.y) {
				for (int i = 0; i < GameController.Impasses.Length; i++){
					if(currentY == (int)GameController.Impasses[i].transform.position.y  && this.transform.position.x == (int)GameController.Impasses[i].transform.position.x) { 
						//print ("impasses");
						return false;
					}
				}
				for (int i = 0; i < GameController.Repels.Length; i++){
					if(currentY == (int)GameController.Repels[i].transform.position.y  && this.transform.position.x == (int)GameController.Repels[i].transform.position.x) {
						//print ("repels");
						return false;
					}
				}
				for (int i = 0; i < GameController.Attracts.Length; i++){
					if(currentY == (int)GameController.Attracts[i].transform.position.y  && this.transform.position.x == (int)GameController.Attracts[i].transform.position.x && GameController.Attracts[i] != this) {
						//print ("attracts");
						return false;
					}
				}
				//print (currentY);
				currentY-=1;
			}
		}

		/*
		for (int i = 0; i <= GameController.Impasses.Length; i++){
			if(currentX == (int)GameController.Impasses[i].transform.position.x) { 
				return false;
			}
		}
		for (int i = 0; i <= GameController.Repels.Length; i++){
			if(currentX == (int)GameController.Repels[i].transform.position.x) {
				return false;
			}
		}
		for (int i = 0; i <= GameController.Attracts.Length; i++){
			if(currentX == GameController.Attracts[i].transform.position.x && GameController.Attracts[i] != this) {
				return false;
			}
		}
		*/
		return true;
	}



	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			Debug.Log("attract collide");
			collideAttract = true;
			//Destroy(this);
			return;
		}
	} 


}
