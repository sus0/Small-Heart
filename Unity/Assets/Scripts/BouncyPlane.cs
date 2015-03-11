using UnityEngine;
using System.Collections;

public class BouncyPlane : MonoBehaviour {

	private float bounceForce = 4;
 	
	void OnCollisionEnter(Collision hit)
	{
		if (hit.gameObject.tag == "Equipment" && bounceForce >= 0)
		{
			hit.rigidbody.AddForce(bounceForce*transform.up, ForceMode.VelocityChange);
			//if(bounceForce >= 4)
			//{
			//	bounceForce -= 2;
			//}
			//else
			//{
				bounceForce --;
		}
	}

}
