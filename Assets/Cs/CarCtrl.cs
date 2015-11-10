using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CarCtrl : MonoBehaviour {


	public GameObject Car;
	public float CarSpeed;
	public float MaxSpeed = 20;
	public float CarRotSpeed = 50;
	public float CarMaxRotSpeed = 200;
	public bool CarSpeedDown = false;
	public bool DriftWheel = false;
	public GameObject[] Wheel;
	public GameObject WheelPivot;
	public Vector3 pivot;
	public Text speedtext;
	public Text speedRottext;
	public Text XRot;
	public Text ZRot;


	bool accelOn = false;

	void Start () {
	
		WheelPivot = Wheel [3];

	}
	

	void Update () {

		pivot = WheelPivot.transform.position;
	
		XRot.text = Input.acceleration.x.ToString();
		ZRot.text = Input.acceleration.y.ToString();
		speedtext.text = CarSpeed.ToString ();
		speedRottext.text = CarRotSpeed.ToString ();


		if (CarSpeedDown == true) {
		
			CarSpeed -= 0.5f;

			if (CarSpeed <= 0) 
			{
				CarSpeed = 0;
				CarRotSpeed = 50;
				
			}

		}
	
		if (accelOn == true) 
		{
		
			CarSpeed += 0.1f;
			this.gameObject.transform.Translate (Vector3.forward * CarSpeed * Time.deltaTime);
		
			if (CarSpeed >= MaxSpeed) 
				CarSpeed = MaxSpeed;
				

		
		
		}

		if (CarSpeed > 0 &&  Input.acceleration.x < 0) {
			this.gameObject.transform.Rotate(-Vector3.up * CarRotSpeed * Time.deltaTime);
			
		}
		else if (CarSpeed > 0 && Input.acceleration.x > 0) {
			this.gameObject.transform.Rotate(Vector3.up * CarRotSpeed * Time.deltaTime);
			
		}


		/*
		if (CarSpeed > 10 && Input.acceleration.x < 0.3) {

			this.transform.RotateAround(Wheel[0].transform.position,Vector3.up,-3);
		}

		else if (CarSpeed > 10 && Input.acceleration.x < -0.3) {
			
			this.transform.RotateAround(Wheel[0].transform.position,Vector3.up,3);
		}

*/






		if (DriftWheel && Input.acceleration.x < 0) {
		
			this.transform.RotateAround(Wheel[0].transform.position,Vector3.up,-1f);
		
		}
		else if (DriftWheel && Input.acceleration.x > 0) {

			this.transform.RotateAround(Wheel[1].transform.position,Vector3.up,1f);
		}






	
	}


	public void Drift()
	{
		CarSpeedDown = false;
		DriftWheel = true;


		CarSpeed = CarSpeed/2;
		CarRotSpeed = 100;
	
	
	}

	public void DriftExit()
	{
		CarSpeedDown = true;
		CarRotSpeed = 50;
		DriftWheel = false;
	
	}


	public void Accel()
	{
		CarSpeedDown = false;
		accelOn = true;

			
			
			

			

	
	}





	public void AccelExit()
	{

		accelOn = false;
		CarSpeedDown = true;

		Debug.Log ("exit");
	}

}