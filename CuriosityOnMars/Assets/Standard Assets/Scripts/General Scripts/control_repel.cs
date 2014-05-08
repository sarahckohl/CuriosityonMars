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
		if (rover.transform.position.y.Equals (this.transform.position.y)) {
			//checks if the rover is in range of the attractor
			if (Mathf.Abs(Mathf.Abs (rover.transform.position.x) - Mathf.Abs (this.transform.position.x)) <= attractRange) {
				print ("mathx: " + Mathf.Abs(Mathf.Abs (rover.transform.position.x) - Mathf.Abs (this.transform.position.x)));
				if (rover.transform.position.x > this.transform.position.x) {
					//checks if rover.x is greater than this.x for left or right
					rover.dir = control_rover.Direction.Right;
					//moveRoverNumSpaces ((Mathf.Abs ((int)rover.transform.position.x) - Mathf.Abs ((int)this.transform.position.x)), "Left");
				} else {
					rover.dir = control_rover.Direction.Left;
					//moveRoverNumSpaces ((Mathf.Abs ((int)rover.transform.position.x) - Mathf.Abs ((int)this.transform.position.x)), "Right");
				}
			}
		} 
		else if (rover.transform.position.x.Equals (this.transform.position.x)) {
			//checks if the rover is in range of the attractor
			if (Mathf.Abs(Mathf.Abs (rover.transform.position.y) - Mathf.Abs (this.transform.position.y)) <= attractRange) {
				print ("mathy: " + Mathf.Abs(Mathf.Abs (rover.transform.position.y) - Mathf.Abs (this.transform.position.y)));
				if (rover.transform.position.y > this.transform.position.y) {
					//checks if rover.y is greater than this.y for up or down
					rover.dir = control_rover.Direction.Up;
					//moveRoverNumSpaces ((Mathf.Abs ((int)rover.transform.position.y) - Mathf.Abs ((int)this.transform.position.y)), "Down");
				} else {
					rover.dir = control_rover.Direction.Down;
					//moveRoverNumSpaces ((Mathf.Abs ((int)rover.transform.position.y) - Mathf.Abs ((int)this.transform.position.y)), "Up");
				}
			}
		} 
	}

	// NOT SURE IF THIS IS NEEDED YET //
	void moveRoverNumSpaces(int range, string direction){
		//should only move the number of spaces and stop
		for (int i = 0; i < range; i++) {
			print ("moving");
			if (direction.Equals("Left")){
				print ("going left");
				Vector3 locationLeft = new Vector3(this.transform.position.x - 1, this.transform.position.y,rover.transform.position.z);
				//if (rover.transform.position != locationLeft) {
				//	rover.transform.position = new Vector3(rover.transform.position.x - 1,
				//	                                       rover.transform.position.y,
				//	                                       rover.transform.position.z);
				//}
			}
			else if (direction.Equals("Right")){
				print ("going right");
				Vector3 locationRight = new Vector3(this.transform.position.x + 1, this.transform.position.y,rover.transform.position.z);
				//if (rover.transform.position != locationRight) {
				//	rover.transform.position = new Vector3(rover.transform.position.x + 1,
				//	                                       rover.transform.position.y,
				//	                                       rover.transform.position.z);
				//}
			}
			else if (direction.Equals("Up")){
				print ("going up");
				Vector3 locationUp = new Vector3(this.transform.position.x, this.transform.position.y - 1,rover.transform.position.z);
				//if (rover.transform.position != locationUp) {
				//	rover.transform.position = new Vector3(rover.transform.position.x,
				//	                                       rover.transform.position.y - 1,
				//	                                       rover.transform.position.z);
				//}
			}
			else if (direction.Equals("Down")){
				print ("going down");
				Vector3 locationDown = new Vector3(this.transform.position.x, this.transform.position.y + 1,rover.transform.position.z);
				//if (rover.transform.position != locationDown) {
				//	rover.transform.position = new Vector3(rover.transform.position.x,
				//	                                       rover.transform.position.y + 1,
				//	                                       rover.transform.position.z);
				//}
			}
		}
	}
}
