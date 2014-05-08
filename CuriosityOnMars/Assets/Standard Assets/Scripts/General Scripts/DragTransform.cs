using System.Collections;
using UnityEngine;

class DragTransform : MonoBehaviour
{
	private Color mouseOverColor = Color.blue;
	private Color originalColor = Color.yellow;
	public bool dragging = false;
	public bool gotMoveItems = false;
	private float distance;
	private GameController gameController;
	private Vector3 screenPoint;
	
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
			if (gameController.moveItems) {
				//for testing to make sure that the gamecontroller vool is passing through
				gotMoveItems = true;
			}
		}
	}
	
	void OnMouseEnter()	
	{	
		if (gameController.moveItems) {
			renderer.material.color = mouseOverColor;	
		}
	}
	
	void OnMouseExit()	
	{	
		if (gameController.moveItems) {
			renderer.material.color = originalColor;	
		}
	}
	
	void OnMouseDown()	
	{	
		if (gameController.moveItems) {
			//distance = Vector3.Distance (transform.position, Camera.main.transform.position);
			screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
			dragging = true;
		}
	}
	
	void OnMouseDrag () {
		if (gameController.moveItems) {
			Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 currentPos = Camera.main.ScreenToWorldPoint(currentScreenPoint);
			transform.position = currentPos;
		}
	}
	
	void OnMouseUp()	
	{	
		if (gameController.moveItems) {
			dragging = false;	
		}
	}
	
	void Update()	
	{	
		//if (dragging)	
		//{	
		//	Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);	
		//	Vector3 rayPoint = ray.GetPoint(distance);	
		//	transform.position = rayPoint;	
		//}
	}
}