using UnityEngine;
using System.Collections;

public class itemScript : MonoBehaviour {
	
	public bool dragging = false;
	private DragTransform drag;
	// Use this for initialization
	void Start () {
		drag = this.GetComponent <DragTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(!drag.dragging){
			this.transform.position = new Vector3(this.transform.position.x, 
			                                      this.transform.position.y,
			                                      0);
		}
	}
}