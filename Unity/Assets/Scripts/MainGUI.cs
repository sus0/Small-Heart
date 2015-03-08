using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
public class MainGUI : MonoBehaviour {

	public GameObject equipment;
	public GUISkin    talkBtn;
	public GUISkin    feedBtn;
	public GUISkin    equipBtn;
	//GUISkin skin;
	public void TestButtonOnClick()
	{
		Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3((Input.mousePosition.x - Screen.width/2) , (Input.mousePosition.y+ Screen.width/2), 0 ));
		//print (Input.mousePosition);
		//print (position);
		position = new Vector3(position.x, position.y, 0);
		Instantiate(equipment, position, Quaternion.identity);
	}
	void OnGUI()
	{
		if (GUI.Button( new Rect(Screen.width /2 - 60, Screen.height - 100 , 50, 50), "", talkBtn.button) )
		{

		}
		if (GUI.Button( new Rect(Screen.width /2, Screen.height - 100,50, 50), "", feedBtn.button) )
		{
			
		}
		if (GUI.Button( new Rect(Screen.width /2 + 60, Screen.height - 100, 50, 50), "", equipBtn.button) )
		{
			
		}
	}
	public void TalkBtnToNormal()
	{
		//GameObject.Find("Talk Button").GetComponent<Image>().sprite = (Sprite) Resources.LoadAssetAtPath(ResourcesLoader.talkNormalPath, typeof(Sprite));
	}
	public void TalkBtnToClicked()
	{
		//GameObject.Find("Talk Button").GetComponent<Image>().sprite = (Sprite) Resources.LoadAssetAtPath(ResourcesLoader.talkOnclickPath, typeof(Sprite));
	}

}
