using UnityEngine;
using System.Collections;

public class DefaultWarriorController : WarriorControllerBase {
	
	void Awake()
	{
		Initialize();
	}

	void Update () 
	{
		CheckHealth();
		// Chech if Levels Up
		if (model.IsScoreUp == true)
		{
			
			model.IsScoreUp = false;
		}

		// Start to check when to sleep after the first revolution
		if(model.Stage > 1)
		{
			CheckSleepTime();
		}
	}

	public void LevelUp()
	{
		// Parameters: Input Stats, curStage
			// Task1: get the path from another script- not implemented yet
			// put the path into resourceLoader get the sprite
			// assign the sprite to the model
			// call interface to change sprites
			
			// Initialize the speechbox
			// retrieve the speechbox texts from resource script



	}

}
