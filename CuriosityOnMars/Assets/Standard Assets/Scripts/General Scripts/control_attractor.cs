using UnityEngine;
using System.Collections;

public class control_attractor : MonoBehaviour {
	public Sprite range3;
	public Sprite range4;
	public Sprite range5;
	public Sprite range6;
	private SpriteRenderer spriteRenderer; 
	public control_rover rover;
	public int attractRange = 3;
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
		if (spriteRenderer.sprite == null){ // if the sprite on spriteRenderer is null then
			spriteRenderer.sprite = range3; // set the sprite to sprite1
		}
		else if (attractRange == 4){
			spriteRenderer.sprite = range4;
		}
		else if (attractRange == 5){
			spriteRenderer.sprite = range5;
		}
		else if (attractRange == 6){
			spriteRenderer.sprite = range6;
		}
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
					rover.dir = control_rover.Direction.Left;
				} else {
					rover.dir = control_rover.Direction.Right;
				}
			}
			else if (Mathf.Abs (Mathf.Abs (rover.transform.position.x) - Mathf.Abs (this.transform.position.x)) >= attractRange) {
				//when the rover reaches the max range, it stops
				//disabling the timer was the only way I could get it to stop
				rover.movementTimer.Enabled = false;
			}
		} 
		else if (rover.transform.position.x == this.transform.position.x) {
			//checks if the rover is in range of the attractor
			if (Mathf.Abs(Mathf.Abs (rover.transform.position.y) - Mathf.Abs (this.transform.position.y)) <= attractRange) {
				print ("mathy: " + Mathf.Abs(Mathf.Abs (rover.transform.position.y) - Mathf.Abs (this.transform.position.y)));
				if (rover.transform.position.y > this.transform.position.y) {
					//checks if rover.y is greater than this.y for up or down
					rover.dir = control_rover.Direction.Down;
				} else {
					rover.dir = control_rover.Direction.Up;
				}
			}
			else if (Mathf.Abs (Mathf.Abs (rover.transform.position.y) - Mathf.Abs (this.transform.position.y)) >= attractRange) {;
				//when the rover reaches the max range, it stops
				//disabling the timer was the only way I could get it to stop
				rover.movementTimer.Enabled = false;
			}
		} 
	}


}
