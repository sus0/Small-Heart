﻿using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CameraAspectRatio : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AdjustApectRatio();
	}
	void Update() {
		Screen.orientation = ScreenOrientation.Portrait;
	}

	private void AdjustApectRatio()
	{
		float  targetAspect = 1;
		float  windowAspect = (float)Screen.width / (float)Screen.height;
		float  scaleHeight  = windowAspect / targetAspect;
		Camera camera       = GetComponent<Camera>();
		// if scaled height is less than current height, add letterbox
		if (scaleHeight < 1.0f)
		{  
			Rect rect 		 = camera.rect;
			rect.width 		 = 1.0f;
			rect.height 	 = scaleHeight;
			rect.x 			 = 0;
			rect.y 			 = (1.0f - scaleHeight) / 2.0f;
			camera.rect 	 = rect;
		}
		else // add pillarbox
		{
			float scaleWidth = 1.0f / scaleHeight;
			Rect rect 		 = camera.rect;
			rect.width 		 = scaleWidth;
			rect.height 	 = 1.0f;
			rect.x 			 = (1.0f - scaleWidth) / 2.0f;
			rect.y 			 = 0;
			camera.rect 	 = rect;
		}
	}
}
