using UnityEngine;
using System.Collections;

public class ResourcesLoader : MonoBehaviour {
	public static string path			 = "Assets/Sprites/game_equipment1.png";
	public static string heroSpritePath	 = "Sprites/game_hero";
	public static Object[] heroSprites;

	void Awake()
	{
		heroSprites = Resources.LoadAll(heroSpritePath);
	}

	public static Sprite HeroSpriteLoader(int stage, int branch)
	{
		return (Sprite)heroSprites[stage];
	}
}
