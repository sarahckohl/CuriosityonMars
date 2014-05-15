using UnityEngine;
using System.Collections;

public class control_impeller : MonoBehaviour
{

	public enum Direction
	{
		Left, Right, Up, Down
	}
	public Direction dir;
	
	public control_rover rover;
	// Use this for initialization
	void Start () {
		//on the assigned direction, it'll rotate the arrow when the scene starts
		if (dir == Direction.Up) {
			gameObject.transform.eulerAngles = new Vector3(0,0,0);
		}
		else if (dir == Direction.Down){
			gameObject.transform.eulerAngles = new Vector3(0,0,180);
		}
		else if (dir == Direction.Right){
			gameObject.transform.eulerAngles = new Vector3(0,0,-90);
		}
		else if (dir == Direction.Left){
			gameObject.transform.eulerAngles = new Vector3(0,0,90);
		}
		gameObject.tag = "passable";
	}
	
	// Update is called once per frame
	void Update () {
		// see if the rover is at the same coordinates as this
		// if it is, set its direction
		if (rover.transform.position.x == this.transform.position.x &&
			rover.transform.position.y == this.transform.position.y) {
			if (dir == Direction.Up) {
				rover.dir = control_rover.Direction.Up;
			}
			else if (dir == Direction.Down){
				rover.dir = control_rover.Direction.Down;
			}
			else if (dir == Direction.Right){
				rover.dir = control_rover.Direction.Right;
			}
			else if (dir == Direction.Left){
				rover.dir = control_rover.Direction.Left;
			}
				//rover.dir = control_rover.Direction.Left;
		}
	}
}
