using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;


public class WarriorInterface : MonoBehaviour {
	public Text  			intelligenceTxt;
	public Text  			agilityTxt;
	public Text  			strengthTxt;
	//public Text healthTxt;

	private int  			_currStage = 1;
	private SpriteRenderer 	_sprite;
	private Sprite[]		_sprites;

	void Start()
	{
		_sprite = GetComponent<SpriteRenderer>();

	}

	// Update is called once per frame
	void Update () 
	{
		intelligenceTxt.text = "Intelligence: " + GetComponent<WarriorModel>().Intelligence.ToString();
		agilityTxt.text 	 = "Agility: "      + GetComponent<WarriorModel>().Agility.ToString();
		strengthTxt.text 	 = "Strength: "     + GetComponent<WarriorModel>().Strength.ToString();

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
}
