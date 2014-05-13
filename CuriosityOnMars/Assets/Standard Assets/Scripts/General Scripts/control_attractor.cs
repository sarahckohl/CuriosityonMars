using UnityEngine;
using System.Collections;

public class control_attractor : MonoBehaviour {
	public Sprite range3;
	public Sprite range4;
	public Sprite range5;
	public Sprite range6;
	private Color mouseOverColor = Color.cyan;
	private Color originalColor;
	private SpriteRenderer spriteRenderer; 
	public control_rover rover;
	public bool collideAttract = false;
	public bool activateAttract = false;
	public int attractRange = 3;
	bool hover;
	float roverDistancex;
	float roverDistancey;
	GameObject[] tiles;
	// Use this for initialization
	void Start () {

		hover = false;
		tiles = GameObject.FindGameObjectsWithTag("map");
		//originalColor = tiles [1].renderer.material.color;
		originalColor = Color.clear;
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
		collideAttract = false;
	}


	void OnMouseEnter(){
		hover = true;
		print ("hover= "+hover+", attractor range:"+attractRange);

		//GameObject[] tiles = FindObjectsOfType(typeof(Sprite)) as GameObject[];
		GameObject[] tiles = GameObject.FindGameObjectsWithTag("map");

		foreach (GameObject tile in tiles) {

			float tileDistancex = Mathf.Abs (Mathf.Abs (tile.transform.position.x) - Mathf.Abs (this.transform.position.x));
			float tileDistancey = Mathf.Abs (Mathf.Abs (tile.transform.position.y) - Mathf.Abs (this.transform.position.y));

			print ("tiledistance: "+tileDistancex+","+tileDistancey);

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
		print ("hover= "+hover+", attractor range:"+attractRange);


		
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

		roverDistancex = Mathf.Abs (Mathf.Abs (rover.transform.position.x) - Mathf.Abs (this.transform.position.x));
		roverDistancey = Mathf.Abs (Mathf.Abs (rover.transform.position.y) - Mathf.Abs (this.transform.position.y));


		//check if the rover needs to go up or down
		if (rover.transform.position.y == this.transform.position.y) {
			if (rover.impassable && !collideAttract) {
				rover.impassable = false;

			}

			//checks if the rover is in range of the attractor
			if (roverDistancex <= attractRange) {
				print ("mathx: " + Mathf.Abs(Mathf.Abs (rover.transform.position.x) - Mathf.Abs (this.transform.position.x)));
				if (rover.transform.position.x > this.transform.position.x) {
					//checks if rover.x is greater than this.x for left or right
					rover.dir = control_rover.Direction.Left;
				} else {
					rover.dir = control_rover.Direction.Right;
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
				print ("mathy: " + Mathf.Abs(Mathf.Abs (rover.transform.position.y) - Mathf.Abs (this.transform.position.y)));
				if (rover.transform.position.y > this.transform.position.y) {
					//checks if rover.y is greater than this.y for up or down
					rover.dir = control_rover.Direction.Down;
				} else {
					rover.dir = control_rover.Direction.Up;
				}
			}
			//else if (Mathf.Abs (Mathf.Abs (rover.transform.position.y) - Mathf.Abs (this.transform.position.y)) >= attractRange) {;
				//when the rover reaches the max range, it stops
				//disabling the timer was the only way I could get it to stop
			//	rover.movementTimer.Enabled = false;
			//}
		} 
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
