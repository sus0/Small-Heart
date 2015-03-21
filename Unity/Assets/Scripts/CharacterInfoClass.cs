using UnityEngine;
using System.Collections;


namespace SmallHeart
{
	public class Info {
		public CharacterDetails details = new CharacterDetails();

		// Set from constructing the dictionary 
		public int 	  CurrStage  	 	{ get; set; }
		public int    TrainingTime 	 	{ get; set; }
		public int    HealthTotal    	{ get; set; }


		public Info()
		{}
		
		public Info (int currStage)
		{
			CurrStage  	   = currStage;
		}
		public bool SetStats (int training, int healthTotal)
		{
			TrainingTime = training;
			HealthTotal  = healthTotal;
			return true;
		}
	}

}