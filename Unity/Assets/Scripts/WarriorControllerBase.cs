using UnityEngine;
using System.Collections;
using System;


public abstract class WarriorControllerBase : MonoBehaviour 
{
	// Properties
	protected WarriorModel model;
	protected DateTime     sleepTime;
	protected DateTime 	   wakeTime;

	// Methods declarations
	abstract public void Attack();
	abstract public void LevelUp();
		
	// Implementations
	public void Initialize()
	{
		model = GetComponent<WarriorModel>();
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

		//if (DateTime.Now GetComponent<WarriorModel>().IsAwake == false){

		//}
	}
	public void OnTrigger()
	{

	}
	public void SetName(string name)
	{
		GetComponent<WarriorModel>().Name = name;
	}
}
