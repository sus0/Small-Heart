using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SmallHeart;

public class LevelStatsMap : MonoBehaviour {
	// adding agiglity at stage 1
	public static string route1a = "abel";
	public static string route1b = "akanksha";
	// adding intelligence at stage 1
	public static string route2a = "isabel";
	public static string route2b = "irwin";
	// adding strength at stage 1
	public static string route3a = "seok";
	public static string route3b = "saffron";
	//private static string intelliSuffix = "int";
	private static string agiSuffix     = "agi";
	//private static string strSuffix 	= "str";


	// Changed int to string - take previous sprite path instead
	public static IDictionary<KeyPair<string, int>, Info> Route1Map = new Dictionary<KeyPair<string, int>, Info>();
	public static IDictionary<KeyPair<int, int>, Info> Route2Map = new Dictionary<KeyPair<int, int>, Info>();
	public static IDictionary<KeyPair<int, int>, Info> Route3Map = new Dictionary<KeyPair<int, int>, Info>();
	public static IDictionary<KeyPair<int, int>, Info> Route4Map = new Dictionary<KeyPair<int, int>, Info>();
	public static IDictionary<KeyPair<int, int>, Info> Route5Map = new Dictionary<KeyPair<int, int>, Info>();
	public static IDictionary<KeyPair<int, int>, Info> Route6Map = new Dictionary<KeyPair<int, int>, Info>();

	void Awake()
	{
		string prevPath = "";
		string loadPath = "";

		// Construct the first routeMap for testing
		for (int preStage = 1; preStage < 2; preStage ++)
		{

			// for agility
			loadPath = "Assets/Resources/Sprites/CharacterSprites/"+ route1a + "_"+preStage + "_"+ agiSuffix + ".png";
			Route1Map.Add(new KeyPair<string, int>(prevPath, (int)ResourcesLoader.Stats.Agility), new Info(loadPath, ( preStage+1)) );
		}


	}
}
