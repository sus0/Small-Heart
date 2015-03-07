using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WarriorInterface : MonoBehaviour {

	public Text intelligenceTxt;
	public Text agilityTxt;
	public Text strengthTxt;
	//public Text healthTxt;


	// Update is called once per frame
	void Update () {
		intelligenceTxt.text = "Intelligence: " + GetComponent<PlayerControl>().playerCtrl.model.Intelligence.ToString();
		agilityTxt.text 	 = "Agility: " + GetComponent<PlayerControl>().playerCtrl.model.Agility.ToString();
		strengthTxt.text 	 = "Strength: " + GetComponent<PlayerControl>().playerCtrl.model.Strength.ToString();
	}
}
