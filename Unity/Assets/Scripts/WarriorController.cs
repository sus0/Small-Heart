using UnityEngine;
using System;
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

		// currenthealth = 0

		// refres Health bar

		// un load unused assets

		Debug.Log ("check level up");
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
			Debug.Log("Go to sleep");
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
