using UnityEngine;
using System.Collections;

public class control_repel : MonoBehaviour {
	public control_rover rover;
	public int attractRange = 3;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//check if the rover needs to go up or down
		if (rover.transform.position.y == this.transform.position.y) {
			//checks if the rover is in range of the attractor
			if (Mathf.Abs(Mathf.Abs (rover.transform.position.x) - Mathf.Abs (this.transform.position.x)) <= attractRange) {
				print ("mathx: " + Mathf.Abs(Mathf.Abs (rover.transform.position.x) - Mathf.Abs (this.transform.position.x)));
				if (rover.transform.position.x > this.transform.position.x) {
					//checks if rover.x is greater than this.x for left or right
					rover.dir = control_rover.Direction.Right;
					//moveRoverNumSpaces ((Mathf.Abs ((int)rover.transform.position.x) - Mathf.Abs ((int)this.transform.position.x)), "Left");
				} else if (rover.transform.position.x < this.transform.position.x){
					rover.dir = control_rover.Direction.Left;
					//moveRoverNumSpaces ((Mathf.Abs ((int)rover.transform.position.x) - Mathf.Abs ((int)this.transform.position.x)), "Right");
				}
			}
			//else if (Mathf.Abs (Mathf.Abs (rover.transform.position.x) - Mathf.Abs (this.transform.position.x)) >= attractRange) {
				//when the rover reaches the max range, it stops
				//disabling the timer was the only way I could get it to stop
			//	rover.movementTimer.Enabled = false;
			//}
		} 
		else if (rover.transform.position.x == this.transform.position.x) {
			//checks if the rover is in range of the attractor
			if (Mathf.Abs(Mathf.Abs (rover.transform.position.y) - Mathf.Abs (this.transform.position.y)) <= attractRange) {
				print ("mathy: " + Mathf.Abs(Mathf.Abs (rover.transform.position.y) - Mathf.Abs (this.transform.position.y)));
				if (rover.transform.position.y > this.transform.position.y) {
					//checks if rover.y is greater than this.y for up or down
					rover.dir = control_rover.Direction.Up;
					//moveRoverNumSpaces ((Mathf.Abs ((int)rover.transform.position.y) - Mathf.Abs ((int)this.transform.position.y)), "Down");
				} else if (rover.transform.position.y < this.transform.position.y) {
					rover.dir = control_rover.Direction.Down;
					//moveRoverNumSpaces ((Mathf.Abs ((int)rover.transform.position.y) - Mathf.Abs ((int)this.transform.position.y)), "Up");
				}
			}
			//else if (Mathf.Abs (Mathf.Abs (rover.transform.position.y) - Mathf.Abs (this.transform.position.y)) >= attractRange) {;
				//when the rover reaches the max range, it stops
				//disabling the timer was the only way I could get it to stop
			//	rover.movementTimer.Enabled = false;
			//}
		}
	}

}
