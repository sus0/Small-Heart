using UnityEngine;
using System.Collections;

public class WarriorModel : MonoBehaviour {
  
	// Properties
	public  bool 	 IsAlive 	  { get; set; }
	public  bool     IsAwake      { get; set; }
	public  bool     IsSpeaking   { get; set; }
	public 	bool	 IsBusy   	  { get; set; }
	public  bool     IsScoreUp	  { get; set; }
	public  bool	 IsHealthy    { get; set; }
	public  int      Stage        { get; set; }
	public  int 	 TotalHealth  { get; set; }
	public  int      CurrHealth   { get; set; }
	public  int  	 Agility      { get; set; }
	public  int 	 Intelligence { get; set; }
	public  int      Strength     { get; set; }
	public  string   Name 		  { get; set; }
	public  Sprite   CurrSprite   { get; set; }
	public ArrayList SpeechboxTxt = new ArrayList();
  //public properties
	// Constructors with inital values
	void Awake()
	{
		IsAlive 	 	= true;
		IsSpeaking 		= false;
		IsBusy			= false;
		IsAwake         = true;
		IsScoreUp		= false;
		IsHealthy       = false;
		Stage           = 2;
		TotalHealth  	= 10;
		CurrHealth      = 1;
		Agility 		= 10;
		Intelligence	= 10;
		Strength 		= 10;
		Name 			= "";
		SpeechboxTxt.Add( ResourcesLoader.heroSpeechboxTxt0);
		SpeechboxTxt.Add( "Test0" );
		SpeechboxTxt.Add( "Test5" );
	}

	void Update()
	{
		if (CurrHealth == TotalHealth)
		{
			IsHealthy = true;
			Debug.Log( "The character is healthy!" );
		}
	}


}
