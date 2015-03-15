﻿using UnityEngine;
using System;
using SmallHeart;
using System.Collections;

public class WarriorController : MonoBehaviour {

	private WarriorModel _model;
	// Use this for initialization
	void Awake () {
		_model = GetComponent<WarriorModel>();
	}
	
	void Update () 
	{
		CheckHealth();
		
		// Start to check when to sleep after the first revolution
		if( _model.Stage > 1)
		{
			CheckSleepTime();
		}
	}
	
	public void LevelUp(int statsType)
	{
		if (_model.Stage == 1)
		{
			// Roll a number to determine its route
			DetermineRoute();
		}
		Debug.Log(_model.Stage);
		// Parameters: Input Stats, curStage
		// Task1: get the path from another script- not implemented yet
		// put the path into resourceLoader get the sprite
		// assign the sprite to the model
		// call interface to change sprites
		
		// Initialize the speechbox
		// retrieve the speechbox texts from resource script
		
		// Initialize Training time

		// Initialize Health Total




		// refres Health bar

		// un load unused assets


		RefreshGame();
		RefreshSprite (_model.Stage, statsType);
		_model.Stage ++;
		Debug.Log ("check level up");
	}

	private void DetermineRoute()
	{
		// lets roll a number from 1 to 7 (exclusive because of int)
		int routeNum = UnityEngine.Random.Range(1, 7);
		// for testing 
		routeNum = 1;
		switch (routeNum)
		{
		case 1:
			ResourcesLoader.RouteMap = LevelStatsMap.Route1Map;
			break;
		default:
			break;
		}
	}

	private void RefreshGame()
	{
		// currenthealth = 0
		_model.CurrHealth = 0;
		// set health Total
		_model.TotalHealth = 2;

	}

	public void RefreshSprite(int prevStage, int statsType)
	{
		Info nextLvlInfo = new Info(); 
		ResourcesLoader.RouteMap.TryGetValue(new KeyPair<int, int> (prevStage, statsType), out nextLvlInfo);
		if ( ResourcesLoader.RouteMap.TryGetValue(new KeyPair<int, int> (prevStage, statsType), out nextLvlInfo) )
		{
			//string loadPath = "Assets/Resources/Sprites/CharacterSprites/abel_1_agi.png";
			//Debug.Log(loadPath);
			Sprite nextLvlSprite = (Sprite)Resources.LoadAssetAtPath(nextLvlInfo.SpritePath, typeof(Sprite));
			if (nextLvlSprite != null)
			{
				_model.CurrSprite = nextLvlSprite;
			}
		else {
			Debug.Log ("none is loaded");
			}
		}

	}

	public void CheckHealth()
	{
		if (_model != null) {
			if ( _model.TotalHealth <= 0)
			{
				Debug.Log ("GameOver");
				// game over
			}
		}
	}
	
	public void CheckSleepTime()
	{
		if ( TimeSpan.Compare(DateTime.Now.TimeOfDay, ResourcesLoader.sleepTime)!= -1 
		    && _model.IsAwake == true )
		{
			//Debug.Log("Go to sleep");
		}
		else if (TimeSpan.Compare(DateTime.Now.TimeOfDay,ResourcesLoader.wakeTime) != -1 
		         && _model.IsAwake == false)
		{
			Debug.Log("Wake up");
		}
	}
	
	public void SetName(string name)
	{
		_model.Name = name;
	}

	public string  RandomSpeechBoxTxtGenerator()
	{
		// during awake time
		int randomNum = UnityEngine.Random.Range (0, _model.SpeechboxTxt.Count);
		return _model.SpeechboxTxt[randomNum].ToString();
	}

}
