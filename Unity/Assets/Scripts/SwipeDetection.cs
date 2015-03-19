using UnityEngine;
using System.Collections;

public class SwipeDetection : MonoBehaviour {

	private float   _minSwipeX = 100;
	private Vector2 _startPos;
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0)
		{
			Touch touch = Input.touches[0];
			Debug.Log ("TEST");
			switch( touch.phase )
			{
			case TouchPhase.Began:
				_startPos = touch.position;
				break;

			case TouchPhase.Ended:
				float swipeDistanceX = ( new Vector3( touch.position.x,0, 0 ) - new Vector3( _startPos.x, 0, 0) ).magnitude;
				if (swipeDistanceX > _minSwipeX)
				{
					float swipeDir = Mathf.Sign( touch.position.x - _startPos.x );

					if (swipeDir > 0)
					{
						Debug.Log ("Swipe Right");
					}
					else if (swipeDir < 0)
					{
						Debug.Log ("swipe left");
					}
				}
				break;

			default:
				break;
			}
		}
	}
}
