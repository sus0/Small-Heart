using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

[RequireComponent(typeof(SlideBarsControl))]
public class WarriorInterface : MonoBehaviour {
	public Text  				intelligenceTxt;
	public Text  				agilityTxt;
	public Text  				strengthTxt;
	public GameObject       	speechBox;
	public Text					speechBoxTxt;
	public GameObject			equipIntelligence;
	public GameObject			equipAgi;
	public GameObject			equipStrn;
	public GameObject			equipFood;
	public Button				talkBtn;
	public Button				feedBtn;
	public Button				equipBtn;
	public Button 				equipIntelliBtn;
	public Button				equipAgiBtn;
	public Button				equipStrnBtn;
	public GameObject			healthBar;
	public GameObject			slideBar;

	private int  				_currStage 			= 1;
	private SpriteRenderer 		_sprite;
	private Sprite[]			_sprites;
	private WarriorModel		_model;
	private WarriorController 	_controller;
	private HealthBarScroller   _healthBar;
	private bool				 _IsLerpingAway			= false;
	private bool				_IsLerpingBack			= false;
	private Image 				_speechBoxSprite;
	private SlideBarsControl	_slideBar;

	void Awake()
	{
		_sprite 					= GetComponent<SpriteRenderer>();
		_model 						= GetComponent<WarriorModel>();
		_controller					= GetComponent<WarriorController>();
		_speechBoxSprite 			= speechBox.GetComponent<Image>();
		_speechBoxSprite.enabled	= false;
		_healthBar					= healthBar.GetComponent<HealthBarScroller>();
		_slideBar					= slideBar.GetComponent<SlideBarsControl>();
		speechBoxTxt.enabled		= false;
		if ( _model != null && _model.Stage == 1) // if statement for safe
		{
			Debug.Log(_model.Stage);
			talkBtn.interactable = false;
			feedBtn.interactable = false;
			Debug.Log(feedBtn.IsInteractable());
		}
	}

	// Update is called once per frame
	void Update () 
	{
		intelligenceTxt.text 		= _model.Intelligence.ToString();
		//Debug.Log (intelligenceTxt.text.ToString());
		agilityTxt.text 	 		= _model.Agility.ToString();
		strengthTxt.text 	 		= _model.Strength.ToString();

		if (_model.Stage > _currStage)
		{
			_currStage = _model.Stage;
			LevelUpOnGUI();
		}
		if (_IsLerpingAway == true)
		{
			LerpCharacter( ResourcesLoader.smoothTime, ResourcesLoader.equipInitTranformPos );
			StopLerpCharacter( ResourcesLoader.equipInitTranformPos );
		}
		if (_IsLerpingBack == true)
		{
			LerpCharacter( ResourcesLoader.smoothTime, ResourcesLoader.initTransformPos );
			StopLerpCharacter( ResourcesLoader.initTransformPos );
		}
		if ( _model.IsBusy )
		{
			feedBtn.interactable 		 = false;
			equipAgiBtn.interactable 	 = false;
			equipStrnBtn.interactable 	 = false;
			equipIntelliBtn.interactable = false;

			if( (int)_slideBar.menuState  == 1)
			{
				_slideBar.BackBtnOnClick();
				_slideBar.menuState = ResourcesLoader.MenuStates.MainMenu;
				equipBtn.interactable = false;
			}


		}
		else {
			if(_model.Stage != 1)
			{
				feedBtn.interactable 		 = true;
			}
			equipAgiBtn.interactable 	 = true;
			equipStrnBtn.interactable 	 = true;
			equipIntelliBtn.interactable = true;
			equipBtn.interactable		= true;
		}
	}
	public void LevelUpOnGUI()
	{	
		_sprite.sprite = ResourcesLoader.HeroSpriteLoader(_currStage, 1);

	}

	/////////////////////////////////////////////////////////////////////////////////////////
	///  Talk btn on Click event
	/// /////////////////////////////////////////////////////////////////////////////////////	
	public void TalbBtnOnClick()
	{
		if(!_model.IsSpeaking)
		{
			_model.IsSpeaking 			= true;
			speechBoxTxt.text 			= _controller.RandomSpeechBoxTxtGenerator();
			_speechBoxSprite.enabled	= true;
			speechBoxTxt.enabled		= true;
			StartCoroutine ( SpeakForSeconds ( ResourcesLoader.speakingTime ) );
		}
	}

	private IEnumerator SpeakForSeconds ( float speakTime )
	{
		yield return new WaitForSeconds( speakTime );
		_speechBoxSprite.enabled 		= false;
		speechBoxTxt.enabled 			= false;
		_model.IsSpeaking				= false;
	}



	/////////////////////////////////////////////////////////////////////////////////////////
	///  Equip button on click events
	/// /////////////////////////////////////////////////////////////////////////////////////
	public void EquipIntelliBtnOnClick()
	{
		if( !_model.IsBusy )
		{
			EquipBtnOnClick(equipIntelligence, (int)ResourcesLoader.Stats.Intelligence );
		}
	}
	public void EquipAgiBtnOnClick()
	{
		if( !_model.IsBusy )
		{
			EquipBtnOnClick(equipAgi, (int)ResourcesLoader.Stats.Agility );
		}
	}
	public void EquipStrnBtnOnClick()
	{
		if( !_model.IsBusy )
		{
			EquipBtnOnClick(equipStrn, (int)ResourcesLoader.Stats.Strength );
		}
	}

	private void EquipBtnOnClick(GameObject obj, int statsType)
	{

		_IsLerpingAway 			= true;
		_model.IsBusy 			= true;
		GameObject instantiatedEquip = (GameObject)Instantiate( obj, ResourcesLoader.equipInitPos, Quaternion.identity );
		StartCoroutine(TrainingForSeconds(instantiatedEquip, ResourcesLoader.trainingTime, statsType));

	}
	private IEnumerator TrainingForSeconds( GameObject equip, float sec, int statsType )
	{
		yield return new WaitForSeconds ( sec );
		
		Destroy(equip);
		_IsLerpingBack = true;

		
		switch(statsType)
		{
		case 0:
			_model.Intelligence += ResourcesLoader.boostPerTraining;
			break;
		case 1:
			_model.Agility += ResourcesLoader.boostPerTraining;
			break;
		case 2:
			_model.Strength += ResourcesLoader.boostPerTraining;
			break;
		default:
			Debug.Log("Nothing matches this type of stats");
			break;
		}
		// Tell Controller it just scoreup
		if (_model.Stage == 1)
		{
			talkBtn.interactable = true;
			feedBtn.interactable = true;
		}

		_controller.LevelUp(statsType);
		_model.IsBusy = false;

		// Update view
		// render the _sprite here!!!!


		Debug.Log("Destroy the game object at this point");
	}

	/////////////////////////////////////////////////////////////////////////////////////////
	///  Food button on click events
	/// /////////////////////////////////////////////////////////////////////////////////////
	public void FoodBtnOnClick()
	{
		if( !_model.IsBusy )
		{
			Debug.Log ("Starting to eat");
			_model.IsBusy					 = true;
			//_healthBar.isIncreasingHealthbar = true;
			feedBtn.interactable 			 = false;
			_IsLerpingAway					 = true;
			GameObject instantiatedEquip = (GameObject)Instantiate( equipFood, ResourcesLoader.equipInitPos, Quaternion.identity );
			StartCoroutine( EatingForSeconds(instantiatedEquip,3));
		}
	}

	private IEnumerator EatingForSeconds( GameObject obj, float sec)
	{
		yield return new WaitForSeconds ( sec );
		_healthBar.isIncreasingHealthbar = true;
		Destroy(obj);
		_IsLerpingBack = true;
	}
	/////////////////////////////////////////////////////////////////////////////////////////
	///  Lerping Character 
	///  - lerping back
	///  - lerping forth
	/// /////////////////////////////////////////////////////////////////////////////////////
	private void LerpCharacter(float smoothTime, Vector3 target)
	{
		Vector3	velocity = Vector3.zero;
		transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothTime);
	}
	private void StopLerpCharacter(Vector3 target)
	{
		float rounded = Mathf.Round(transform.position.x * 1000f) / 1000f;
		if (rounded == target.x)
		{
			if (_IsLerpingAway == true)
			{
				_IsLerpingAway = false;
			}
			else if (_IsLerpingBack == true)
			{
				_IsLerpingBack = false;
			}
			transform.position = target;
		}
	}
	/////////////////////////////////////////////////////////////////////////////////////////
	///  Other functions
	/// /////////////////////////////////////////////////////////////////////////////////////
}
