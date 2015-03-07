using UnityEngine;
using System.Collections;

public class WarriorModel : MonoBehaviour {
  
  //public properties
	// Constructors with inital values
	public WarriorModel ()
	{
		IsAlive 	 	= true;
		Health  		= 100;
		Agility 		= 10;
		Intelligence	= 10;
		Strength 		= 10;
	}

	// Properties
	public  bool 	IsAlive 	{ get; set; }
	public  int 	Health 		{ get; set; }
	public  int  	Agility     { get; set; }
	public  int 	Intelligence{ get; set; }
	public  int     Strength    { get; set; }

}
