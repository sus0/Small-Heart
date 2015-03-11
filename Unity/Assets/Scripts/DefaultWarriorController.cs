using UnityEngine;
using System.Collections;

public class DefaultWarriorController : WarriorControllerBase {
	
	void Awake()
	{
		Initialize();
	}

	void Update () {
		CheckHealth();

		// Start to check when to sleep after the first revolution
		if(model.Stage > 1)
		{
			CheckSleepTime();
		}
	}



	override public void Attack()
	{

	}
	override public void LevelUp()
	{

	}

}
