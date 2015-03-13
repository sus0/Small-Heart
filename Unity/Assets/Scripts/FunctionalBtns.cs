using UnityEngine;
using System.Collections;

/////////////////////////////////////////////////////////////////////////////////////////
///  UI button Events NOT relating to character control
/// /////////////////////////////////////////////////////////////////////////////////////
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

}
