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
		intelligenceTxt.text = "Intelligence: " + GetComponent<PlayerControl>().playerCtrl.model.Intelligence.ToString();
		agilityTxt.text 	 = "Agility: " + GetComponent<PlayerControl>().playerCtrl.model.Agility.ToString();
		strengthTxt.text 	 = "Strength: " + GetComponent<PlayerControl>().playerCtrl.model.Strength.ToString();

		if (GetComponent<PlayerControl>().playerCtrl.model.Stage > _currStage)
		{
			_currStage = GetComponent<PlayerControl>().playerCtrl.model.Stage;
			LevelUpOnGUI();
		}
	}
	public void LevelUpOnGUI()
	{
		_sprite.sprite = ResourcesLoader.HeroSpriteLoader(_currStage, 1);

	}
}
