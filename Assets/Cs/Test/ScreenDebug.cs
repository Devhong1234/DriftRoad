using UnityEngine;
using System.Collections;

public class ScreenDebug : MonoBehaviour {

	float _half_width;


	void Start () {
	
		_half_width = Screen.width * 0.5f;

	}
	

	void Update () {





		if(Input.touchCount > 0)
		{
		
			if(Input.GetTouch(0).position.x < _half_width)
			{
				Debug.Log("Left");
			
			}

			else
			{
				Debug.Log("Right");
			}

		
		}
	

	}
}
