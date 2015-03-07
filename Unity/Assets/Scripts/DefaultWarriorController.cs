using UnityEngine;
using System.Collections;

public class DefaultWarriorController : WarriorControllerBase {
	
	void Awake()
	{
		Initialize();
	}

	void Update () {
		CheckHealth();
	}

	override public void Attack()
	{

	}
	override public void LevelUp()
	{

	}

}
