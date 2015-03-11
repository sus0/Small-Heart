using UnityEngine;
using System.Collections;

public class ResourcesLoader : MonoBehaviour {

	// Warrior Interface Resources
	public static string path			 	= "Assets/Sprites/game_equipment1.png";
	public static string heroSpritePath	 	= "Sprites/game_hero";
	public static string heroSpeechboxTxt0 	= "I'll become stronger, just you wait!";
	public static float  speakingTime 		= 3.0f;
	public static float  smoothTime 		= 0.05f;
	public static int    boostPerTraining	= 10;
	public static Object[] heroSprites;

	// Equipment Initialization Positions:
	public static Vector3 equipInitPos  	    = new Vector3 (-0.8f ,-2.45f, 0 );
	public static Vector3 equipInitTranformPos 	= new Vector3 ( -2.5f, 1, 0 );


	void Awake()
	{
		heroSprites = Resources.LoadAll(heroSpritePath);
	}

	public static Sprite HeroSpriteLoader(int stage, int branch)
	{
		return (Sprite)heroSprites[stage];
	}
	
}
