using UnityEngine;
using System.Collections;

public class goalScript : MonoBehaviour {
	private GameObject rover;
	// Use this for initialization
	void Start () {
		rover = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (rover.transform.position == this.transform.position) {
			// move to next scene
			Application.LoadLevel(Application.loadedLevel + 1);
				}
	}
}
