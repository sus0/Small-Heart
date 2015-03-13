﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBarScroller : MonoBehaviour {

	public GameObject       warrior;	
	public Button			feedBtn;

	private Scrollbar 		_healthBar;
	private float 			_currHealth;
	private int 			_targetHealth;
	private int 			_totalHealth;
	private WarriorModel	_model;
	private float 			_smoothTime 		   = 0.3f;
	private float 			_maxSpeed   		   = 0.0f;
	private bool			_isIncreasingHealthbar = false;
	private bool 			_isAbleToEat		   = true;
	// Use this for initialization
	void Start () {
		_model 			= warrior.GetComponent<WarriorModel>();
		_healthBar 		= GetComponent<Scrollbar>();
		//RefreshHealthBar();
	}
	
	// Update is called once per frame
	void Update () {
		if (_isIncreasingHealthbar)
		{
			float newHealth = Mathf.SmoothDamp(_currHealth, _targetHealth, ref _maxSpeed, _smoothTime);
			_healthBar.size = newHealth/(float)_totalHealth; 
			_currHealth 	= newHealth;
			StopSmoothDamp(_currHealth, _targetHealth);
		}
		else
		{
			RefreshHealthBar();
		}

	}

	public void FoodBtnOnClick()
	{

		_isIncreasingHealthbar 	= true;
		feedBtn.interactable 	= false;
	}

	void StopSmoothDamp(float curr, float target)
	{
		if (Mathf.Abs(target - curr) <= 0.01)
		{
			_isIncreasingHealthbar = false;
			_model.CurrHealth      += 1;
			feedBtn.interactable   = true;
		}
	}
	public void RefreshHealthBar()
	{
		_currHealth  	= (float)_model.CurrHealth;
		_totalHealth 	= _model.TotalHealth;
		_targetHealth   = (int)_currHealth + 1;
		_healthBar.size = _currHealth/(float)_totalHealth;
	}
}
