using UnityEngine;
using System.Collections;

public class DragTransform : MonoBehaviour {

	private bool  dragging = false;
	private float distance;

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
			// TODO: fix the gui bar size issues
			Vector3 mousePos = Input.mousePosition;
			if (mousePos.x < 0)
			{
				mousePos.x = 0;
			} 
			else if (mousePos.x > Screen.width)
			{
				mousePos.x = Screen.width;
			}
			if (mousePos.y < 0)
			{
				mousePos.y = 0;
			}
			else if (mousePos.y > Screen.height)
			{
				mousePos.y = Screen.height;
			}

			Ray ray = Camera.main.ScreenPointToRay(mousePos);
			Vector3 rayPoint = ray.GetPoint(distance);
			transform.position = new Vector3(rayPoint.x, rayPoint.y, 0);
		}
	}
}
