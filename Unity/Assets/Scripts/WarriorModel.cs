using UnityEngine;
using System.Collections;

public class WarriorModel : MonoBehaviour {
  
	// Properties
	public  bool 	 IsAlive 	  { get; set; }
	public  bool     IsAwake      { get; set; }
	public  bool     IsSpeaking   { get; set; }
	public  int      Stage        { get; set; }
	public  int 	 Health 	  { get; set; }
	public  int  	 Agility      { get; set; }
	public  int 	 Intelligence { get; set; }
	public  int      Strength     { get; set; }
	public  string   Name 		  { get; set; }
	private ArrayList _speechboxTxt = new ArrayList();
  //public properties
	// Constructors with inital values
	void Awake()
	{
		IsAlive 	 	= true;
		IsSpeaking 		= false;
		IsAwake         = true;
		Stage           = 2;
		Health  		= 100;
		Agility 		= 10;
		Intelligence	= 10;
		Strength 		= 10;
		Name 			= "";
		_speechboxTxt.Add( ResourcesLoader.heroSpeechboxTxt0);
	}

	public string  RandomSpeechBoxTxtGenerator()
	{
		int randomNum = Random.Range (0, _speechboxTxt.Count);
		return _speechboxTxt[randomNum].ToString();
	}
}
