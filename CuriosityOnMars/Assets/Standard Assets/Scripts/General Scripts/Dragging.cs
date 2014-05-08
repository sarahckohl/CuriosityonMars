using System.Collections;
using UnityEngine;

class Dragging : MonoBehaviour
	
{
	private Color mouseOverColor = Color.blue;
	private Color originalColor ;
	public bool dragging = false;
	public bool gotController = false;
	private float distance;
	private GameController gameController;
	
	void Start()
	{
		Debug.Log(Camera.main);
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
			gotController = true;
		}
	}
	
	void OnMouseEnter()
	{
		print ("hi");
		if (gameController.moveItems) {
			originalColor = gameObject.transform.parent.renderer.material.GetColor ("_Color");
			gameObject.transform.parent.renderer.material.color = mouseOverColor;
		}
	}

	void OnMouseExit()
	{
		if (gameController.moveItems) {
			gameObject.transform.parent.renderer.material.color = originalColor;
		}
	}

	void OnMouseDown()
	{
		print ("down");
		if (gameController.moveItems) {
			distance = Vector3.Distance (transform.position, Camera.main.transform.position);
			dragging = true;
		}
	}

	void OnMouseUp()
	{
		if (gameController.moveItems) {
			dragging = false;
			Vector3 currentPos = transform.position;
			//snapping to grid
			float temp;
			if(currentPos.x >=0){
				if (currentPos.x % 1f < 0.5f){
					temp = 0.5f;
				}
				else{
					temp = -0.5f;
				}
			}
			else{
				if (currentPos.x % 1f > -0.5f ){
					temp = -0.5f;
				}
				else{
					temp = 0.5f;
				}
			}
			gameObject.transform.parent.transform.position = new Vector3(Mathf.Round(currentPos.x) + temp,
			                                                             Mathf.Round(currentPos.y),
			                                                             currentPos.z);
		}
	}

	void Update()	
	{
		if (dragging)	
		{	
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);	
			Vector3 rayPoint = ray.GetPoint(distance);
			transform.parent.position = rayPoint;
			transform.position = rayPoint;
		}
	}
	
}