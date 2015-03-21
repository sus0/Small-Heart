using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SmallHeart;

public class LevelStatsMap : MonoBehaviour {

	// adding intelligence at stage 1
	public static string route0a = "isabel_base";
	public static string route0b = "irwin_base";

	// adding agiglity at stage 1
	public static string route1a = "abel_base";
	public static string route1b = "akanksha_base";

	// adding strength at stage 1
	public static string route2a = "seok_base";
	public static string route2b = "saffron_base";

	//private static int intelliSuffix = "int";
	//private static int agiSuffix     = "agi";
	//private static string strSuffix 	= "str";


	// Changed int to string - take previous sprite path instead
	public static IDictionary<string, Info> Route0aMap = new Dictionary<string, Info>();
	public static IDictionary<string, Info> Route0bMap = new Dictionary<string, Info>();

	public static IDictionary<string, Info> Route1aMap = new Dictionary<string, Info>();
	public static IDictionary<string, Info> Route1bMap = new Dictionary<string, Info>();

	public static IDictionary<string, Info> Route2aMap = new Dictionary<string, Info>();
	public static IDictionary<string, Info> Route2bMap = new Dictionary<string, Info>();

	private InfoContainer allInfos;

	void Awake()
	{
		LoadInfo();

		//////////////////////////////////////////////
		/// Construct all the strings first 
		/// /////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////////////
		/// Isabel Path (0a)
		//////////////////////////////////////////////////////////////////////////////////
		StartPushing (Route0aMap, route0a, ResourcesLoader.Stats.Intelligence);


		//////////////////////////////////////////////////////////////////////////////////
		/// Irwin Path (0b)
		//////////////////////////////////////////////////////////////////////////////////
		StartPushing (Route0bMap, route0b, ResourcesLoader.Stats.Intelligence);

		//////////////////////////////////////////////////////////////////////////////////
		/// Abel Path (1a)
		//////////////////////////////////////////////////////////////////////////////////
		StartPushing (Route1aMap, route1a, ResourcesLoader.Stats.Agility);

		//////////////////////////////////////////////////////////////////////////////////
		/// Akanksha Path (1b)
		//////////////////////////////////////////////////////////////////////////////////
		StartPushing (Route1bMap, route1b, ResourcesLoader.Stats.Agility);

		//////////////////////////////////////////////////////////////////////////////////
		/// Seok Path (2a)
		//////////////////////////////////////////////////////////////////////////////////
		StartPushing (Route2aMap, route2a, ResourcesLoader.Stats.Strength);

		//////////////////////////////////////////////////////////////////////////////////
		/// Saffron Path (2b)
		//////////////////////////////////////////////////////////////////////////////////
		StartPushing (Route2bMap, route2b, ResourcesLoader.Stats.Strength);
	}


	private void StartPushing ( IDictionary<string, Info> map, string routeId, ResourcesLoader.Stats statesType)
	{
		string loadPath = "Assets/Resources/Sprites/CharacterSprites/"+ routeId;
		int stats= (int)statesType;
		map.Add(stats.ToString(), new Info(loadPath, 1 ) );
		RecursivePushing (map, loadPath, 1);
	}

	private void RecursivePushing ( IDictionary<string, Info> map, string prevPath, int prevStage)
	{
		if (prevStage >= ResourcesLoader.maxStage)
		{
			return;
		}

		string loadPath = "" ;
		loadPath = prevPath + (int)ResourcesLoader.Stats.Intelligence;
		map.Add(loadPath, new Info(loadPath, ( prevStage + 1 ) ) );
		RecursivePushing(map, loadPath, (prevStage + 1));

		loadPath = prevPath + (int)ResourcesLoader.Stats.Agility;
		map.Add(loadPath, new Info(loadPath, ( prevStage + 1 ) ) );
		RecursivePushing(map, loadPath, (prevStage + 1));

		loadPath = prevPath + (int)ResourcesLoader.Stats.Strength;
		map.Add(loadPath, new Info(loadPath, ( prevStage + 1 ) ) );
		RecursivePushing(map, loadPath, (prevStage + 1));
	}

	private void LoadInfo()
	{
		string xmlPath = "Assets/Scripts/Config/CharactersInfo.xml";
		allInfos 	   = InfoContainer.Load(xmlPath);
	}

	private void FillInfo(List<Info> routeInfo, IDictionary<KeyPair<string, int>, Info> routeMap)
	{
		foreach (Info info in routeInfo)
		{
			string spritePath = info.SpritePath;


		}
	}
}
