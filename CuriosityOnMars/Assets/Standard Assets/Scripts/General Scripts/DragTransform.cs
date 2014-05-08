using System.Collections;
using UnityEngine;

class DragTransform : MonoBehaviour
{
	private Color mouseOverColor = Color.blue;
	private Color originalColor = Color.yellow;
	public bool dragging = false;
	private float distance;

	void OnMouseEnter()	
	{	
		print ("hi");
		renderer.material.color = mouseOverColor;	
	}

	void OnMouseExit()	
	{	
		renderer.material.color = originalColor;	
	}

	void OnMouseDown()	
	{	
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);
		dragging = true;
	}

	void OnMouseUp()	
	{	
		dragging = false;	
	}

	void Update()	
	{	
		if (dragging)	
		{	
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);	
			Vector3 rayPoint = ray.GetPoint(distance);	
			transform.position = rayPoint;	
		}
	}
}