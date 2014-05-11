using UnityEngine;
using System.Collections;

public class ShowPicture : MonoBehaviour {

	GameObject Rover;
	//public control_rover Rover;
	//GameObject levelCompleted;

	// Use this for initialization
	void Start () {

		Rover = GameObject.FindGameObjectWithTag("Player");



	}
	
	// Update is called once per frame
	void Update () {

		if (Rover.transform.position == this.transform.position) {
			Instantiate("levelCompleted");		
		}
	
	}
}
