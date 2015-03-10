using UnityEngine;
using System.Collections;

public class ResourcesLoader : MonoBehaviour {

	public static string path			 	= "Assets/Sprites/game_equipment1.png";
	public static string heroSpritePath	 	= "Sprites/game_hero";
	public static string heroSpeechboxTxt0 	= "I'll become stronger, just you wait!";
	public static Object[] heroSprites;


	// Equipment Initialization Positions:
	public static Vector3 equipInitPos  	    = new Vector3 ( 2 , 1, 0 );
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
