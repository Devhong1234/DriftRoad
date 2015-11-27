using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestCtrl : MonoBehaviour {

	public Transform CenterOfMass;

	public WheelFrictionCurve[] wfc;

	public float MaxTorque;

	public float MaxSpeed = 500;
	public float CarRotSpeed = 50;
	public float CarMaxRotSpeed = 200;

	public float prevSteerAngle;

	public float highestSpeed = 50f;
	public float lowSpeedSteerAngle = 10f;
	public float highSpeedSteerAngle = 1f;


	public GameObject[] Wheel;
	public WheelCollider[] WheelColl;

	Rigidbody rbody;

	public float decspeed = 7f;
	
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

		rbody = this.GetComponent<Rigidbody>();

		rbody.centerOfMass = CenterOfMass.transform.localPosition;

		wfc = new WheelFrictionCurve[4];


	}


	void Update()
	
	{
		Debug.Log (WheelColl[3].brakeTorque);



		switch (CarState)
		{
			
	
		case State.CarSpeedUp:
			M_CarSpeedUp();
			break;

		default:
			break;
		}


		if (Input.GetMouseButton (0)) {


			if (MaxTorque > MaxSpeed) {
			
				MaxTorque = MaxSpeed;
			}


			CarState = State.CarSpeedUp;


		
		} 
		else if (!Input.GetMouseButton (0)) 
		{
		
			MaxTorque = 0;

		}

		if (Input.GetMouseButton (1)) {

			WheelColl[2].brakeTorque = 1000;
			WheelColl[3].brakeTorque = 1000;
		
		}

	
	
	
	}
	
	
	void M_CarSpeedUp()
	{
		
		WheelColl[2].brakeTorque = 0;
		WheelColl[3].brakeTorque = 0;
		WheelColl[2].motorTorque = MaxTorque;
		WheelColl[3].motorTorque = MaxTorque;
		
		MaxTorque += 1f;
		
		

	}
	
	
}