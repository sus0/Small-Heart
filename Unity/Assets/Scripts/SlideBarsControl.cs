using UnityEngine;
using System.Collections;

public class SlideBarsControl : MonoBehaviour {

	public GameObject buttonPanel;
	public GameObject equipPanel;


	private Animator  _animButtonPanel;
	private Animator  _animEquipPanel;
	// Use this for initialization
	void Start () {
		_animButtonPanel 		 = buttonPanel.GetComponent<Animator>();
		_animEquipPanel  		 = equipPanel.GetComponent<Animator>();
		_animButtonPanel.enabled = false;
		_animEquipPanel.enabled  = false;
	}

	public void BackBtnOnClick()
	{
		_animButtonPanel.Play("menu_slidein");
		_animEquipPanel.Play ("equip_slideout");
	}
	public void EquipBtnOnClick()
	{
		_animButtonPanel.enabled = true;
		_animButtonPanel.Play("menu_slideout");
		_animEquipPanel.enabled  = true;
		_animEquipPanel.Play ("equip_slidein");
	}

}
