using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour
{


	void Update ()
	{

	
		CamCtrl ();
	

	}


	void CamCtrl()
	{
		if(Input.GetMouseButton(0))
		{
			Camera.main.fieldOfView += 1;
				if(Camera.main.fieldOfView >=80)
				{
				Camera.main.fieldOfView = 80;
				}
		}
		
		else
			
			Camera.main.fieldOfView -= 0.5f;

		if (Camera.main.fieldOfView <= 60) 
		{
			Camera.main.fieldOfView = 60;
		}
		

	
	}

}

