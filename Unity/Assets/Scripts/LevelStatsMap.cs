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

	private CharacterDetailsContainer CharacterDetails;

	void Awake()
	{

		SetSpriteBase();
		LoadInfo();

		//////////////////////////////////////////////
		/// Construct all the strings first 
		/// /////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////////////
		/// Isabel Path (0a)
		//////////////////////////////////////////////////////////////////////////////////
		StartPushing (Route0aMap, route0a);
		FillInfo (CharacterDetails.Route0aDetails, Route0aMap);

		//////////////////////////////////////////////////////////////////////////////////
		/// Irwin Path (0b)
		//////////////////////////////////////////////////////////////////////////////////
		StartPushing (Route0bMap, route0b);
		FillInfo (CharacterDetails.Route0bDetails, Route0bMap);
		//////////////////////////////////////////////////////////////////////////////////
		/// Abel Path (1a)
		//////////////////////////////////////////////////////////////////////////////////
		StartPushing (Route1aMap, route1a);
		FillInfo (CharacterDetails.Route1aDetails, Route1aMap);
		//////////////////////////////////////////////////////////////////////////////////
		/// Akanksha Path (1b)
		//////////////////////////////////////////////////////////////////////////////////
		StartPushing (Route1bMap, route1b);
		FillInfo (CharacterDetails.Route1bDetails, Route1bMap);
		//////////////////////////////////////////////////////////////////////////////////
		/// Seok Path (2a)
		//////////////////////////////////////////////////////////////////////////////////
		StartPushing (Route2aMap, route2a);
		FillInfo (CharacterDetails.Route2aDetails, Route2aMap);
		//////////////////////////////////////////////////////////////////////////////////
		/// Saffron Path (2b)
		//////////////////////////////////////////////////////////////////////////////////
		StartPushing (Route2bMap, route2b);
		FillInfo (CharacterDetails.Route2bDetails, Route2bMap);
	}


	private void StartPushing ( IDictionary<string, Info> map, string routeId)
	{
		string loadPath = routeId;
		map.Add( loadPath, new Info( 1 ) );
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
		map.Add(loadPath, new Info( prevStage + 1 ) );
		RecursivePushing(map, loadPath, (prevStage + 1));

		loadPath = prevPath + (int)ResourcesLoader.Stats.Agility;
		map.Add(loadPath, new Info( prevStage + 1 ) );
		RecursivePushing(map, loadPath, (prevStage + 1));

		loadPath = prevPath + (int)ResourcesLoader.Stats.Strength;
		map.Add(loadPath, new Info( prevStage + 1 ) );
		RecursivePushing(map, loadPath, (prevStage + 1));
	}

	private void LoadInfo()
	{
		string xmlPath 	  = "Assets/Scripts/Config/CharactersInfo.xml";
		CharacterDetails  = CharacterDetailsContainer.Load(xmlPath);
	}

	private void FillInfo(List<CharacterDetails> routeDetails, IDictionary<string, Info> routeMap)
	{
		foreach (CharacterDetails details in routeDetails)
		{
			string spritePath = details.SpritePath;
			Info curInfo = new Info();
			if ( routeMap.TryGetValue(spritePath, out curInfo) )
			{
				curInfo.details = details;
				curInfo.SplitSpeechBoxText();
			}
			else
			{
				Debug.Log ("Cannot find sprite path: " + spritePath);
			}
		}
	}

	private void SetSpriteBase()
	{
		#if UNITY_EDITOR
		ResourcesLoader.spriteBase = "Assets/Resources/Sprites/CharacterSprites/";
		#endif
		
		#if UNITY_ANDROID
		ResourcesLoader.spriteBase =  "jar:file://" + Application.dataPath + "!/assets/";;
		#endif
	}
}
