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
	private bool			_initEquip			= false;
	private Image 			_speechBoxSprite;


	void Start()
	{
		_sprite 					= GetComponent<SpriteRenderer>();
		_model 						= GetComponent<WarriorModel>();
		_speechBoxSprite 			= speechBox.GetComponent<Image>();
		_speechBoxSprite.enabled	= false;
		speechBoxTxt.enabled		= false;
	}

	// Update is called once per frame
	void Update () 
	{
		intelligenceTxt.text 		= GetComponent<WarriorModel>().Intelligence.ToString();
		agilityTxt.text 	 		= GetComponent<WarriorModel>().Agility.ToString();
		strengthTxt.text 	 		= GetComponent<WarriorModel>().Strength.ToString();

		if (GetComponent<WarriorModel>().Stage > _currStage)
		{
			_currStage = GetComponent<WarriorModel>().Stage;
			LevelUpOnGUI();
		}
		if (_initEquip == true)
		{
			LerpCharacter( ResourcesLoader.smoothTime );
			StopLerpCharacter( ResourcesLoader.equipInitTranformPos );
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
			speechBoxTxt.text 			= _model.RandomSpeechBoxTxtGenerator();
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

	public void EquipIntelliBtnOnClick()
	{
		_initEquip = true;
		Instantiate( equipIntelligence, ResourcesLoader.equipInitPos, Quaternion.identity );
		_model.Intelligence += ResourcesLoader.boostPerTraining;

	}
	public void EquipAgiBtnOnClick()
	{
		_initEquip = true;
		Instantiate( equipAgi, ResourcesLoader.equipInitPos, Quaternion.identity );
		_model.Agility += ResourcesLoader.boostPerTraining;
		
	}
	public void EquipStrnBtnOnClick()
	{
		_initEquip = true;
		Instantiate( equipStrn, ResourcesLoader.equipInitPos, Quaternion.identity );
		_model.Strength += ResourcesLoader.boostPerTraining;
		
	}

	private void LerpCharacter(float smoothTime)
	{
		Vector3	velocity = Vector3.zero;
		transform.position = Vector3.SmoothDamp(transform.position, ResourcesLoader.equipInitTranformPos, ref velocity, smoothTime);
	}
	private void StopLerpCharacter(Vector3 target)
	{
		float rounded = Mathf.Round(transform.position.x * 1000f) / 1000f;
		if (rounded == target.x)
		{
			_initEquip = false;
			transform.position = target;
		}
	}
}
