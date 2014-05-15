using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public GameObject sprite;
	//public GameObject border;
	private int width = 12;
	private int height = 11;

	private GameObject [,] grid = new GameObject[12,11];
	GameObject gridPlane;

	void Awake() {
		//cols
		for (int i = 0; i < width; i++) {
			//rows
			for (int j = 0; j < height; j++) {
				//if (j==height-1 || j== 1 || i == 0 || i == width-1){
				//	gridPlane = (GameObject)Instantiate(border);
				//}
				//else {
					gridPlane = (GameObject)Instantiate(sprite);
				//}
				gridPlane.transform.position = new Vector3 (gridPlane.transform.position.x+i, 
				                                            gridPlane.transform.position.y+j, 
				                                            0);
				grid[i,j] = gridPlane;
			}
		}
	}


	// Use this for initialization
	void Start () {

	}
}
