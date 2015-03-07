using UnityEngine;
using System.Collections;

public class WarriorModel : MonoBehaviour {
  
	// Properties
	public  bool 	IsAlive 	{ get; set; }
	public  bool    IsAwake     { get; set; }
	public  int     Stage       { get; set;	}
	public  int 	Health 		{ get; set; }
	public  int  	Agility     { get; set; }
	public  int 	Intelligence{ get; set; }
	public  int     Strength    { get; set; }
	public  string  Name 		{ get; set; }
  //public properties
	// Constructors with inital values
	void Awake()
	{
		IsAlive 	 	= true;
		Stage           = 2;
		Health  		= 100;
		Agility 		= 10;
		Intelligence	= 10;
		Strength 		= 10;
		Name 			= "";
	}

}
