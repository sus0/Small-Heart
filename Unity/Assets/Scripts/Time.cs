using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Time : MonoBehaviour {

	public Text timeTxt;

	private string _txt; 
	// Update is called once per frame
	void Update () {
		_txt = String.Format("{0:00}:{1:00}", DateTime.Now.TimeOfDay.Hours, DateTime.Now.TimeOfDay.Minutes);
		timeTxt.text = _txt;
		//Debug.Log(_txt);
	}
}
