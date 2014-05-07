using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public GameObject sprite;
	public GameObject border;
	public int width = 10;
	public int height = 10;

	private GameObject [,] grid = new GameObject[10,10];
	GameObject gridPlane;

	void Awake() {
		//cols
		for (int i = 0; i < width; i++) {
			//rows
			for (int j = 0; j < height; j++) {
				if (j==height-1 || j== 2 || i == 0 || i == width-1){
					gridPlane = (GameObject)Instantiate(border);
					gridPlane.transform.position = new Vector3 (gridPlane.transform.position.x+i, 
					                                            gridPlane.transform.position.y+j, 
					                                            0);
					grid[i,j] = gridPlane;
				}
				else {
					gridPlane = (GameObject)Instantiate(sprite);
					gridPlane.transform.position = new Vector3 (gridPlane.transform.position.x+i, 
				                                            	gridPlane.transform.position.y+j, 
				                                            	0);
					grid[i,j] = gridPlane;
				}
			}
		}
	}

	void OnGUI() {
		if (GUI.Button (new Rect (10, 10, 150, 100), "Delete grid[6,6]")) {
			Destroy(grid[6,6]);
		}
	}

	// Use this for initialization
	void Start () {

	}
}
