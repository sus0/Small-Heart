using UnityEngine;
using System.Collections;
using System;


public abstract class WarriorControllerBase : MonoBehaviour 
{
	// Properties
	protected WarriorModel model;
	protected TimeSpan     sleepTime;
	protected TimeSpan 	   wakeTime;

	// Methods declarations
	abstract public void Attack();
	abstract public void LevelUp();
		
	// Implementations
	public void Initialize()
	{
		model = GetComponent<WarriorModel>();
		sleepTime = new TimeSpan (23, 0, 0);
		wakeTime  = new TimeSpan ( 8, 0, 0);
	}
	public void CheckHealth()
	{
		if (model != null) {
			if ( model.Health <= 0)
			{
				Debug.Log ("GameOver");
				// game over
			}
		}
	}
	public void CheckSleepTime()
	{
		if ( TimeSpan.Compare(DateTime.Now.TimeOfDay, sleepTime)!= -1 
		 	&& model.IsAwake == true )
		{
			Debug.Log("Go to sleep");
		}
		else if (TimeSpan.Compare(DateTime.Now.TimeOfDay,wakeTime) != -1 
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
