using UnityEngine;
using System.Collections;
using System;


public abstract class WarriorControllerBase : MonoBehaviour 
{
	// Properties
	protected WarriorModel model;
		
	// Implementations
	public void Initialize()
	{
		model = GetComponent<WarriorModel>();
	}

	public void CheckHealth()
	{
		if (model != null) {
			if ( model.TotalHealth <= 0)
			{
				Debug.Log ("GameOver");
				// game over
			}
		}
	}

	public void CheckSleepTime()
	{
		if ( TimeSpan.Compare(DateTime.Now.TimeOfDay, ResourcesLoader.sleepTime)!= -1 
		 	&& model.IsAwake == true )
		{
			Debug.Log("Go to sleep");
		}
		else if (TimeSpan.Compare(DateTime.Now.TimeOfDay,ResourcesLoader.wakeTime) != -1 
		     && model.IsAwake == false)
		{
			Debug.Log("Wake up");
		}
	}

	public void SetName(string name)
	{
		model.Name = name;
	}
}
