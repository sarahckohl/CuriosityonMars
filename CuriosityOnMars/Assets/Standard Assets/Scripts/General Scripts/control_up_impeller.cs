using UnityEngine;
using System.Collections;

public class control_up_impeller : MonoBehaviour {

	public control_rover rover;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// see if the rover is at the same coordinates as this
		// if it is, set its direction to up
		if(rover.transform.position.x.Equals(this.transform.position.x) &&
		   rover.transform.position.y.Equals(this.transform.position.y))
			rover.dir = control_rover.Direction.Up;
	}
}
