using System.Collections;
using UnityEngine;

class DragTransform : MonoBehaviour
{
	private Color mouseOverColor = Color.green;
	private Color originalColor;
	public bool dragging = false;
	public bool gotMoveItems = false;
	private float distance;
	//private GameController GameController;
	private Vector3 screenPoint;
	private bool canMove;
	
	void Start()
	{
<<<<<<< HEAD
		//originalColor = renderer.material.color;
		if (gameObject.transform.position.y == 0)
			canMove = true;
		else
			canMove = false;
=======
		originalColor = gameObject.renderer.material.color;

>>>>>>> origin/master
		//GameObject GameControllerObject = GameObject.FindWithTag ("GameController");
		//if (GameControllerObject != null) {
		//GameController = GameControllerObject.GetComponent <GameController>();
		if (GameController.moveItems) {
			//for testing to make sure that the gamecontroller vool is passing through
			gotMoveItems = true;
		}
		//}
	}
	
	void OnMouseEnter()	
	{	
		if (GameController.moveItems) {
			renderer.material.color = mouseOverColor;	
		}
	}
	
	void OnMouseExit()	
	{	
		if (GameController.moveItems) {
			renderer.material.color = originalColor;	
		}
	}
	
	void OnMouseDown()	
	{	
		if (GameController.moveItems && canMove) {
			//distance = Vector3.Distance (transform.position, Camera.main.transform.position);
			screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
			dragging = true;
		}
	}
	
	void OnMouseDrag () {
		if (GameController.moveItems && canMove) {
			Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 currentPos = Camera.main.ScreenToWorldPoint(currentScreenPoint);
			transform.position = currentPos;
		}
	}
	
	void OnMouseUp()	
	{	
		if (GameController.moveItems) {
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