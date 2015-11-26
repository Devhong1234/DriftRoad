﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ctrl : MonoBehaviour {

	public Transform CenterOfMass;

	public float MaxTorque;
	public float CarSpeed;
	public float MaxSpeed = 500;
	public float CarRotSpeed = 50;
	public float CarMaxRotSpeed = 200;

	public float prevSteerAngle;

	public float highestSpeed = 50f;
	public float lowSpeedSteerAngle = 10f;
	public float highSpeedSteerAngle = 1f;


	public GameObject[] Wheel;
	public WheelCollider[] WheelCol;
	public Rigidbody rb;

	
	public float _half_width;


	State CarState;
	
	
	public enum State
	{
		Wait_Touch = 0,
		CountDecision,
		CarSpeedUp,
		CarSpeedDown,
		CarRotSpeedUp,
		Drift,
		Lean,

	}
	

	
	void Start ()
	{

		_half_width = Screen.width * 0.5f;
		rb = this.GetComponent<Rigidbody>();
		rb.centerOfMass = CenterOfMass.localPosition;
	}
	

	void FixedUpdate()
	{



		float speedFactor = rb.velocity.magnitude / highestSpeed;
		float steerAngle = Mathf.Lerp (lowSpeedSteerAngle, highSpeedSteerAngle,speedFactor);
		steerAngle *= Input.acceleration.x;


		WheelCol[0].steerAngle = steerAngle;
		WheelCol[1].steerAngle = steerAngle;
	
	}




	void Update () {
		


		switch (CarState)
		{
			
		case State.CountDecision:
			M_CountDecision();
			break;
		case State.CarSpeedUp:
			M_CarSpeedUp();
			break;
		case State.CarSpeedDown:
			M_CarSpeedDown();
			break;
		case State.CarRotSpeedUp:
			M_CarRotSpeedUp();
			break;
		case State.Drift:
			M_Drift();
			break;
		case State.Lean:
			M_Lean();
			break;

			default:
			break;
		}



		if (Input.touchCount > 0 && Input.GetTouch(0).position.x < _half_width) 
		{
			
			M_CountDecision ();
			
		} 
		else 
		{
			
			CarState = State.CarSpeedDown;
			
		}
		
		
		
		
		M_Lean ();


		prevSteerAngle = WheelCol [0].steerAngle;

	}






	void M_CarSpeedUp()
	{

		CarSpeed += 1f;

		WheelCol[2].motorTorque = CarSpeed;
		WheelCol[3].motorTorque = CarSpeed;


		
		if (CarSpeed >= MaxSpeed) //MaxSpeed Limit
		{
			CarSpeed = MaxSpeed;
		} 

	}



	
	void M_CarSpeedDown()
	{
		
		CarSpeed -= 1f;
		
		if (CarSpeed <= 0) // MinSpeed Limit
		{
			CarSpeed = 0;
			
		}
		
		this.gameObject.transform.Translate (Vector3.forward * CarSpeed * Time.deltaTime);
		
	}
	



	void M_CarRotSpeedUp()
	{

		CarRotSpeed += 1f;

		
		if (CarRotSpeed >= CarMaxRotSpeed) 
		{
			CarRotSpeed = CarMaxRotSpeed;
		} 

	}
	
	
	

	
	
	
	
	
	public void M_Drift()
	{
		
		if (CarSpeed > 0 && Input.acceleration.x < 0) {
			
			for(int i = 0; i < 4; i++)
			{
				WheelCol[i].sidewaysFriction.stiffness = 10f;
			
			}
			

			//transform.RotateAround(Wheel[0].transform.position,Vector3.up,-1f);
			
			
		}
		else if (CarSpeed > 0 && Input.acceleration.x > 0) {
			
			for(int i = 0; i < 4; i++)
			{
				WheelCol[i].sidewaysFriction.stiffness = 10f;
				
			}

			//transform.RotateAround(Wheel[1].transform.position,Vector3.up,1f);
			
		}
		
		
		
	}
	
	
	
	public void M_CountDecision()
	{
		
		
		if(Input.GetTouch(0).position.x < _half_width)
		{

			CarState = State.CarSpeedUp;
			
		}
		
		if (Input.touchCount > 1 && Input.GetTouch (1).phase == TouchPhase.Began) 
		{

			M_Drift ();
			
		} 
		
		else if (Input.touchCount > 1 && Input.GetTouch (1).phase == TouchPhase.Stationary) 
		{

			CarRotSpeed += 5;
			CarSpeed -= 0.2f;
			
			if(CarRotSpeed >= CarMaxRotSpeed)
			{
				CarRotSpeed = CarMaxRotSpeed;
			}
			
			if(CarSpeed <= 0)
			{
				CarSpeed = 0;
				
			}

		}
		
		else if (Input.touchCount > 1 && Input.GetTouch (1).phase == TouchPhase.Ended) 
		{
			
			CarRotSpeed = 50;

		}

	}




	public void M_Lean()
	{
		
		if (CarSpeed > 0 &&  Input.acceleration.x < 0) {


			//this.gameObject.transform.Rotate(-Vector3.up * CarRotSpeed * Time.deltaTime);
			
		}
		
		else if (CarSpeed > 0 && Input.acceleration.x > 0) {

			//this.gameObject.transform.Rotate(Vector3.up * CarRotSpeed * Time.deltaTime);
			
		}
	}
	

	

	

	
	
	
	
	
}