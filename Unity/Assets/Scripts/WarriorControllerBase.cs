using UnityEngine;
using System.Collections;
using System;


public abstract class WarriorControllerBase : MonoBehaviour 
{
	// Public constructor
	public WarriorControllerBase() 
	{
		model = new WarriorModel();
	}

	// Properties
	private string 		 name  = "";
	public WarriorModel model = null;

	// Methods
	abstract public void Attack();
	abstract public void LevelUp();

	public void Update()
	{
		if (model != null) {
			if ( model.Health <= 0)
			{
				// game over
			}
		}
	}

	public void OnTrigger()
	{

	}
	public void SetName()
	{
	
	}
}
