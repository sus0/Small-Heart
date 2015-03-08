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

	IEnumerator OnTriggerEnter(Collider other)
	{
		yield return new WaitForSeconds(3f);
		if(other.gameObject.tag == "Equipment") 
		{
			model.Health += 80;
		}
		print (model.Health);
	}

	override public void Attack()
	{

	}
	override public void LevelUp()
	{

	}

}
