using UnityEngine;
using System.Collections;

public class RoverScript : MonoBehaviour {
	
	public enum Direction
	{
		Left, Right, Up, Down, Stop
	}
	public Direction dir = Direction.Stop;
	public System.Timers.Timer movementTimer;
	public bool shouldMove;
	//public GameObject[] repellers;
	//public GameObject[] attractors;
	//public GameObject[] impasses;
	private GameController gameController;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (gameController.gameOver) {
		}
	
	}

	//public IEnumerator Move(Vector3 from, Vector3 to){
	//	if (from.Equals (to)) {
	//		yield break;
	//	}
	//	float startTime = Time.time;
	//	float dist = Vector3.Distance(from, to);
	//	while(gameObject.rigidbody.position != to){
	//		float timePassed = (Time.time - startTime)*speed;
	//		gameObject.rigidbody.position = Vector3.Lerp (from, to, timePassed/dist);
	//		yield return null;
	//	}
	//}
}
