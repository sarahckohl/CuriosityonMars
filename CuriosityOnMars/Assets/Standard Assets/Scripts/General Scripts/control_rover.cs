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
	private System.Timers.Timer movementTimer;
	private bool shouldMove;

	// Use this for initialization
	void Start () {
		movementTimer = new System.Timers.Timer (1000);
		movementTimer.Elapsed += new ElapsedEventHandler (OnEverySecond);
		movementTimer.Enabled = true;
		shouldMove = false;
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
				if(this.transform.position.x < 8)
					this.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z);
			}else if(this.dir == Direction.Left)
			{
				// make sure this does not go less than 1
				if (this.transform.position.x > 1)
					this.transform.position = new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z);
			}else if(this.dir == Direction.Up)
			{
				// keep its boundary
				if (this.transform.position.y < 8)
					this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
			}else if(this.dir == Direction.Down)
			{
				if (this.transform.position.y > 1)
					this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1, this.transform.position.z);
			}
			shouldMove = false;
		}
	}
	private void OnEverySecond(object source, ElapsedEventArgs e)
	{
		// move the rover in the given direction
		shouldMove = true;
	}
}
