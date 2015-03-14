using UnityEngine;
using System.Collections;
using System;

public class ResourcesLoader : MonoBehaviour {

	// Warrior Interface Resources
	public static string path			 	= "Assets/Sprites/game_equipment1.png";
	public static string heroSpritePath	 	= "Sprites/game_hero";
	public static string heroSpeechboxTxt0 	= "I'll become stronger, just you wait!";
	public static float  speakingTime 		= 3.0f;
	public static float  smoothTime 		= 0.05f;
	public static int    boostPerTraining	= 10;
	public static float  trainingTime 		= 10;
	// Equipment Initialization Positions:
	// the default pos of the character
	// Keep the y coordinate of both equipInitTransformPos and initTransformPos the same for only horizontal lerping
	public static Vector3 equipInitPos  	    = new Vector3 (-0.8f ,-2.45f, 0 );
	public static Vector3 equipInitTranformPos 	= new Vector3 ( -2.5f, 1, 0 );
	public static Vector3 initTransformPos 		= new Vector3 ( 0, 1, 0);


	public enum   Stats{
		Intelligence,
		Agility,
		Strength,
		CurrHealth
	};
	public enum MenuStates{
		MainMenu,
		EquipMenu
	};

	public static UnityEngine.Object[] heroSprites;


	// Warrior Controller Resources
	public static TimeSpan sleepTime		= new TimeSpan (23, 0, 0); 
	public static TimeSpan wakeTime     	= new TimeSpan ( 8, 0, 0);


	// Health Bar controlls (part of the Warrior Interface control but put in a separate script)
	public static float eatingTime 			= 0.3f;


	void Awake()
	{
		heroSprites = Resources.LoadAll(heroSpritePath);
	}

	public static Sprite HeroSpriteLoader(int stage, int branch)
	{
		return (Sprite)heroSprites[stage];
	}

	public static Sprite SpriteLoader (string path)
	{
		return (Sprite)Resources.LoadAssetAtPath( path, typeof(Sprite) );
	}
	
}
