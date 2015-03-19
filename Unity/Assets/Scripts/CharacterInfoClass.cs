using UnityEngine;
using System.Collections;

namespace SmallHeart
{
	public class Info {
		public string SpritePath 	 { get; set; }
		public int 	  CurrStage  	 { get; set; }
		public string CharacterClass { get; set; }
		public string ClassInfo      { get; set; }
		public int    TrainingTime 	 { get; set; }
		public int    HealthTotal    { get; set; }
		
		public Info()
		{}
		
		public Info (string path, int currStage)
		{
			SpritePath     = path;
			CurrStage  	   = currStage;
			CharacterClass = "";
			ClassInfo	   = "";
		}
		public bool SetStats (int training, int healthTotal)
		{
			TrainingTime = training;
			HealthTotal  = healthTotal;
			return true;
		}
		
		
	}

}