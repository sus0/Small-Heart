using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using SmallHeart;

public class ResourcesLoader : MonoBehaviour {

	// Warrior Interface Resources
	public static readonly string heroSpeechboxTxt0 = "I'll become stronger, just you wait!";
	public static readonly float  speakingTime 		= 3.0f;
	public static readonly float  smoothTime 		= 0.05f;
	public static readonly int    boostPerTraining	= 10;
	public static readonly float  initialTrainingTime 		= 3;
	// Equipment Initialization Positions:
	// the default pos of the character
	// Keep the y coordinate of both equipInitTransformPos and initTransformPos the same for only horizontal lerping
	public static readonly Vector3 equipInitPos  	     = new Vector3 (-0.8f ,-2.45f, 0 );
	public static readonly Vector3 equipInitTranformPos  = new Vector3 ( -2.5f, 1, 0 );
	public static readonly Vector3 initTransformPos 	 = new Vector3 ( 0, 1, 0);

	public enum   Stats{
		Intelligence,
		Agility,
		Strength,
	};
	public enum MenuStates{
		MainMenu,
		EquipMenu
	};
	
	public static UnityEngine.Object[] heroSprites;
	public static IDictionary<string, Info> RouteMap = new Dictionary<string, Info>();
	public static readonly string 			spriteBase = "Assets/Resources/Sprites/CharacterSprites/";
	public static readonly int maxStage 	 = 2;
	// Warrior Controller Resources
	public static readonly  TimeSpan sleepTime		= new TimeSpan (23, 0, 0); 
	public static readonly  TimeSpan wakeTime     	= new TimeSpan ( 8, 0, 0);


	// Health Bar controlls (part of the Warrior Interface control but put in a separate script)
	public static float eatingTime 			= 0.3f;
	

}
