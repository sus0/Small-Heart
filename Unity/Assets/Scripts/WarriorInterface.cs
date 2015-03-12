using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;


public class WarriorInterface : MonoBehaviour {
	public Text  			intelligenceTxt;
	public Text  			agilityTxt;
	public Text  			strengthTxt;
	public GameObject       speechBox;
	public Text				speechBoxTxt;
	public GameObject		equipIntelligence;
	public GameObject		equipAgi;
	public GameObject		equipStrn;


	private int  			_currStage 			= 1;
	private SpriteRenderer 	_sprite;
	private Sprite[]		_sprites;
	private WarriorModel	_model;
	private WarriorController _controller;
	private bool			_IsLerpingAway			= false;
	private bool			_IsLerpingBack			= false;
	private Image 			_speechBoxSprite;


	void Start()
	{
		_sprite 					= GetComponent<SpriteRenderer>();
		_model 						= GetComponent<WarriorModel>();
		_controller					= GetComponent<WarriorController>();
		_speechBoxSprite 			= speechBox.GetComponent<Image>();
		_speechBoxSprite.enabled	= false;
		speechBoxTxt.enabled		= false;
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
	}
	public void LevelUpOnGUI()
	{	
		//Resize box collider for safe?
		_sprite.sprite = ResourcesLoader.HeroSpriteLoader(_currStage, 1);

	}
		
	public void SpeakOnGUI()
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

	/// <summary>
	/// Button events	/// </summary>
	public void EquipIntelliBtnOnClick()
	{
		EquipBtnOnClick(equipIntelligence, (int)ResourcesLoader.Stats.Intelligence );
	}
	public void EquipAgiBtnOnClick()
	{
		EquipBtnOnClick(equipAgi, (int)ResourcesLoader.Stats.Agility );
	}
	public void EquipStrnBtnOnClick()
	{
		EquipBtnOnClick(equipStrn, (int)ResourcesLoader.Stats.Strength );
	}

	private void EquipBtnOnClick(GameObject obj, int statsType)
	{
		if(_model.IsTraining == false)
		{
			_IsLerpingAway 					 = true;
			_model.IsTraining 			 = true;
			GameObject instantiatedEquip = (GameObject)Instantiate( obj, ResourcesLoader.equipInitPos, Quaternion.identity );
			StartCoroutine(TrainingForSeconds(instantiatedEquip, ResourcesLoader.trainingTime, statsType));
		}

	}
	/// <summary>
	/// Lerping Character	/// </summary>
	/// <param name="smoothTime">Smooth time.</param>
	/// <param name="target">Target.</param>
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

	private IEnumerator TrainingForSeconds( GameObject equip, float sec, int statsType )
	{
		yield return new WaitForSeconds ( sec );

		Destroy(equip);
		_model.IsTraining = false;

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
		_controller.LevelUp(statsType);
		_IsLerpingBack = true;
		Debug.Log("Destroy the game object at this point");
	}
}
