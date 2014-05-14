using UnityEngine;
using System.Collections;

public class control_repel : MonoBehaviour {

	
	private Color mouseOverColor = Color.cyan;
	private Color originalColor;
	bool hover;
	public control_rover rover;
	public bool collideRepel = false;
	public bool activateRepel = false;
	public int attractRange = 3;
	private control_attractor attract;
	float roverDistancex;
	float roverDistancey;
	GameObject[] tiles;

	// Use this for initialization
	void Start () {
		GameObject attractObject = GameObject.FindWithTag ("Attract");
		if (attractObject != null) {
			attract = attractObject.GetComponent <control_attractor>();
		}
		hover = false;
		tiles = GameObject.FindGameObjectsWithTag("map");
		//originalColor = tiles [1].renderer.material.color;
		originalColor = Color.clear;
		collideRepel = false;

		//attractObject.transform.
	}




	void OnMouseEnter(){
		hover = true;
	//	print ("hover= "+hover+", attractor range:"+attractRange);
		
		//GameObject[] tiles = FindObjectsOfType(typeof(Sprite)) as GameObject[];
		//GameObject[] tiles = GameObject.FindGameObjectsWithTag("map");
		
		foreach (GameObject tile in tiles) {
			
			float tileDistancex = Mathf.Abs (Mathf.Abs (tile.transform.position.x) - Mathf.Abs (this.transform.position.x));
			float tileDistancey = Mathf.Abs (Mathf.Abs (tile.transform.position.y) - Mathf.Abs (this.transform.position.y));
			
			//print ("tiledistance: "+tileDistancex+","+tileDistancey);
			
			if( (tile.transform.position.x==this.transform.position.x && tileDistancey <= attractRange) || (tile.transform.position.y==this.transform.position.y && tileDistancex <= attractRange) )
				tile.renderer.material.color = mouseOverColor;	
		}
		
		
	}
	
	
	
	void OnMouseDown()	
	{	
		foreach (GameObject tile in tiles) {
			float tileDistancex = Mathf.Abs (Mathf.Abs (tile.transform.position.x) - Mathf.Abs (this.transform.position.x));
			float tileDistancey = Mathf.Abs (Mathf.Abs (tile.transform.position.y) - Mathf.Abs (this.transform.position.y));
			
			if( (tile.transform.position.x==this.transform.position.x && tileDistancex <= attractRange) || (tile.transform.position.y==this.transform.position.y && tileDistancey <= attractRange) )
				tile.renderer.material.color = originalColor;
		}
	}
	
	
	void OnMouseExit(){
		hover = false;
		//print ("hover= "+hover+", attractor range:"+attractRange);
		
		
		
		foreach (GameObject tile in tiles) {
			float tileDistancex = Mathf.Abs (Mathf.Abs (tile.transform.position.x) - Mathf.Abs (this.transform.position.x));
			float tileDistancey = Mathf.Abs (Mathf.Abs (tile.transform.position.y) - Mathf.Abs (this.transform.position.y));
			
			if( (tile.transform.position.x==this.transform.position.x && tileDistancex <= attractRange) || (tile.transform.position.y==this.transform.position.y && tileDistancey <= attractRange) )
				tile.renderer.material.color = originalColor;
		}
		
	}





	
	// Update is called once per frame
	void Update () {

		if (this.transform.position.y <= 2)
			return;

		//check if the rover needs to go up or down
		if (rover.transform.position.y == this.transform.position.y) {
			if (rover.impassable && !collideRepel) {
				rover.impassable = false;
			}

			//checks if the rover is in range of the attractor
			if (Mathf.Abs(Mathf.Abs (rover.transform.position.x) - Mathf.Abs (this.transform.position.x)) <= attractRange) {
			//	print ("mathx: " + Mathf.Abs(Mathf.Abs (rover.transform.position.x) - Mathf.Abs (this.transform.position.x)));
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
			if (rover.impassable && !collideRepel) {
				rover.impassable = false;
			}
			//checks if the rover is in range of the attractor
			if (Mathf.Abs(Mathf.Abs (rover.transform.position.y) - Mathf.Abs (this.transform.position.y)) <= attractRange) {
				//print ("mathy: " + Mathf.Abs(Mathf.Abs (rover.transform.position.y) - Mathf.Abs (this.transform.position.y)));
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
		else {
			activateRepel = false;
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			//Debug.Log("repel collide");
			collideRepel = true;
			activateRepel = false;
			return;
		}
	} 

}