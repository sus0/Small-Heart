using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	[HideInInspector]
	public WarriorControllerBase playerCtrl;
	// Use this for initialization
	void Start () {
		playerCtrl = new DefaultWarriorController();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
