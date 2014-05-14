﻿using UnityEngine;
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
	public GameObject[] repellers;
	public GameObject[] attractors;
	public GameObject[] impasses;
	public bool impassable = false;
	private GameController gameController;
	
	
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		movementTimer = new System.Timers.Timer (1000);
		movementTimer.Elapsed += new ElapsedEventHandler (OnEverySecond);
		movementTimer.Enabled = true;
		shouldMove = false;
		impassable = false;
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Border" || col.tag == "Attract" || col.tag == "Repel" || col.tag == "Impass") {
			Debug.Log("collide");
			impassable = true;
			return;
		}
	} 
	
	// Update is called once per frame
	void Update () {
		// lower left coordinates: 1, 3
		// lower right: 8, 3
		// upper left: 1, 8
		// upper right: 8, 8
		
		// will move once a second in the given direction, unless it is outside of its boundary
		if (dir != Direction.Stop && shouldMove) 
		{
			if(this.dir == Direction.Right)
			{
				// make sure it does not go over 8
				if(this.transform.position.x < 10)
				{
					// make sure there is not an impasse to the right.
					gameObject.transform.eulerAngles = new Vector3(0,0,-90);
					
					if(!impassable){
						this.transform.position = new Vector2(this.transform.position.x + 1, this.transform.position.y);
					}
				}
			}else if(this.dir == Direction.Left)
			{
				// make sure this does not go less than 1
				if (this.transform.position.x > 1)
				{
					// make sure there is not an impasse to the left.
					gameObject.transform.eulerAngles = new Vector3(0,0,90);
					if(!impassable){
						this.transform.position = new Vector2(this.transform.position.x - 1, this.transform.position.y);
					}
				}
			}else if(this.dir == Direction.Up)
			{
				// keep its boundary
				if (this.transform.position.y < 9)
				{
					// make sure there is not an impasse upwards
					gameObject.transform.eulerAngles = new Vector3(0,0,0);
					if(!impassable){
						this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 1);
					}
				}
			}else if(this.dir == Direction.Down)
			{
				// make sure the rover does not go down off play area
				if (this.transform.position.y > 2)
				{
					// make sure there is not an impasse downwards
					gameObject.transform.eulerAngles = new Vector3(0,0,180);
					if(!impassable){
						this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 1);
					}
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
		if (!gameController.placeStage && !impassable) {
			shouldMove = true;
		}
		if (impassable) {
			shouldMove = false;
		}
	}
	
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
}
