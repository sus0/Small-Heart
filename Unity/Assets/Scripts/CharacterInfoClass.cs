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
		public string[] SpeechBoxText	{ get; set; }
		private char[]  _deliminatorChars = {'#'};

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
		public void SplitSpeechBoxText()
		{
			if (details.SpeechBoxString != null)
			{
				SpeechBoxText = details.SpeechBoxString.Split(_deliminatorChars);
				if (SpeechBoxText.Length == 0)
				{
					Debug.Log ("Speech box text for " + details.CharacterClass + " is empty.");
				}
			}
			else
			{
				Debug.Log ("Speech box string for " + details.CharacterClass + " is null.");
			}
		}
	}

}