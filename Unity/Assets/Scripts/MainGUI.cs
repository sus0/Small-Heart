using UnityEngine;
using System.Collections;

public class MainGUI : MonoBehaviour {

	public GameObject equipment;

	public void TestButtonOnClick()
	{
		Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3((Input.mousePosition.x - Screen.width/2) , (Input.mousePosition.y+ Screen.width/2), 0 ));
		print (Input.mousePosition);
		print (position);
		position = new Vector3(position.x, position.y, 0);
		Instantiate(equipment, position, Quaternion.identity);
	}
}
