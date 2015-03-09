using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;


public class WarriorInterface : MonoBehaviour {
	public Text  			intelligenceTxt;
	public Text  			agilityTxt;
	public Text  			strengthTxt;
	public GameObject       speechBox;
	public GameObject		equipIntelligence;
	public GameObject		equipAgi;
	public GameObject		equipStrn;
	//public Text healthTxt;

	private int  			_currStage 			= 1;
	private SpriteRenderer 	_sprite;
	private Sprite[]		_sprites;
	private WarriorModel	_model;

	void Start()
	{
		speechBox.renderer.enabled = false;
		_sprite = GetComponent<SpriteRenderer>();
		_model = GetComponent<WarriorModel>();
	}

	// Update is called once per frame
	void Update () 
	{
		intelligenceTxt.text = _model.Intelligence.ToString();
		agilityTxt.text 	 = _model.Agility.ToString();
		strengthTxt.text 	 = _model.Strength.ToString();

		if (GetComponent<WarriorModel>().Stage > _currStage)
		{
			_currStage = GetComponent<WarriorModel>().Stage;
			LevelUpOnGUI();
		}
	}
	public void LevelUpOnGUI()
	{	
		//Resize box collider for safe?
		_sprite.sprite = ResourcesLoader.HeroSpriteLoader(_currStage, 1);

	}
		
	public void SpeakOnGUI()
	{
		speechBox.renderer.enabled = true;
		Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3((Input.mousePosition.x - Screen.width/2) , (Input.mousePosition.y + Screen.width), 0 ));
		position.y = -1;
		position.z = 0;
		Instantiate(speechBox, position, Quaternion.identity);

	}
	public void EquipIntelliBtnOnClick()
	{
		transform.position  = ResourcesLoader.equipInitTranformPos;
		Instantiate( equipIntelligence, ResourcesLoader.equipInitPos, Quaternion.identity );
		_model.Intelligence += 10;

	}
	public void EquipAgiBtnOnClick()
	{
		transform.position  = ResourcesLoader.equipInitTranformPos;
		Instantiate( equipAgi, ResourcesLoader.equipInitPos, Quaternion.identity );
		_model.Agility += 10;
		
	}
	public void EquipStrnBtnOnClick()
	{
		transform.position  = ResourcesLoader.equipInitTranformPos;
		Instantiate( equipStrn, ResourcesLoader.equipInitPos, Quaternion.identity );
		_model.Strength += 10;
		
	}
}
