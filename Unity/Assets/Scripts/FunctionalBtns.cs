using UnityEngine;
using System.Collections;

public class FunctionalBtns : MonoBehaviour {
	public void StartBtnOnClick()
	{
		Application.LoadLevel("MainScene");
	}
	public void ContinueBtnOnClick()
	{
		Debug.Log("Continue button not implemented yet.");
		Application.LoadLevel("MainScene");
	}
	public void ExitBtnOnClick()
	{
		Application.Quit();
	}
	public void BackBtnOnClick()
	{
		// To be implemented 
	}
	public void EquipBtnOnClick()
	{
		// To be implemented 
		// Play Animation
	}

}
