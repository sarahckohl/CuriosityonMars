using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public GameObject sprite;
	public int width = 10;
	public int height = 10;

	private GameObject [,] grid = new GameObject[10,10];

	void Awake() {
		//cols
		for (int i = 0; i < width; i++) {
			//rows
			for (int j = 0; j < height; j++) {
				GameObject gridPlane = (GameObject)Instantiate(sprite);
				gridPlane.transform.position = new Vector3 (gridPlane.transform.position.x+i, 
				                                            gridPlane.transform.position.y+j, 
				                                            0);
				grid[i,j] = gridPlane;
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
