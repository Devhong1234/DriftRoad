using UnityEngine;
using System.Collections;

public class CarCtrl : MonoBehaviour {


	public GameObject Car;
	public float CarSpeed;
	public float MaxSpeed = 20;
	public float CarRotSpeed = 50;
	public float CarMaxRotSpeed = 200;
	public bool CarSpeedDown = false;
	public bool DriftWheel = false;
	public GameObject[] Wheel;



	bool accelOn = false;

	void Start () {
	


	}
	

	void Update () {
	
		Debug.Log (Input.acceleration.x);


		if (CarSpeedDown == true) {
		
			CarSpeed -= 1;

			if (CarSpeed <= 0) 
			{
				CarSpeed = 0;
				CarRotSpeed = 50;
				
			}

		}
	
		if (accelOn == true) 
		{
		
			CarSpeed += 0.2f;
			this.gameObject.transform.Translate (Vector3.forward * CarSpeed * Time.deltaTime);
		
			if (CarSpeed >= MaxSpeed) 
				CarSpeed = MaxSpeed;
				

		
		
		}

		if (CarSpeed > 0.1 &&  Input.acceleration.x < 0) {
			this.gameObject.transform.Rotate(-Vector3.up * CarRotSpeed * Time.deltaTime);
			
		}
		else if (CarSpeed > 0.1 && Input.acceleration.x > 0) {
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
		DriftWheel = true;


		CarSpeed = CarSpeed/2;
		CarRotSpeed = 25;
	
	
	}

	public void DriftExit()
	{
	
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