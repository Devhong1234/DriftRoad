using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CarCtrl_Back : MonoBehaviour {


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

	public float _half_width;
	bool accelOn = false;

	State CarState;

	public enum State
	{
	Wait_Touch = 0,
	CountDecision,
	CarSpeedUp,
	CarSpeedDown,
	CarSpeedZero,
	Accel,
	Drift,
	Lean
	
	

	
	}



	void Start () {
	
		WheelPivot = Wheel [3];
		_half_width = Screen.width * 0.5f;
	}
	

	void FixedUpdate () {

		Debug.Log (Input.touchCount);

		switch (CarState)
		{

		case State.CarSpeedUp:
			M_CarSpeedUp();
			break;
		case State.Accel:
			M_Accel();
			break;
		case State.Drift:
			M_Drift();
			break;
		case State.CountDecision:
			M_CountDecision();
			break;
		case State.Lean:
			M_Lean();
			break;



		default:
			break;
		}


		if (Input.touchCount > 0) {
			M_CountDecision ();
		
		} 











		//pivot = WheelPivot.transform.position;
	
		XRot.text = Input.acceleration.x.ToString();
		ZRot.text = Input.acceleration.y.ToString();
		speedtext.text = CarSpeed.ToString ();
		speedRottext.text = CarRotSpeed.ToString ();



		/*

		if (CarSpeed > 0 &&  Input.acceleration.x < 0) {
			this.gameObject.transform.Rotate(-Vector3.up * CarRotSpeed * Time.deltaTime);
			
		}
		else if (CarSpeed > 0 && Input.acceleration.x > 0) {
			this.gameObject.transform.Rotate(Vector3.up * CarRotSpeed * Time.deltaTime);
			
		}








		if (DriftWheel && Input.acceleration.x < 0) {
		
			this.transform.RotateAround(Wheel[0].transform.position,Vector3.up,-1f);
		
		}
		else if (DriftWheel && Input.acceleration.x > 0) {

			this.transform.RotateAround(Wheel[1].transform.position,Vector3.up,1f);
		}






*/

	
	}

	void M_CarSpeedUp()
	{

		CarSpeed += 0.1f;
		this.gameObject.transform.Translate (Vector3.forward * CarSpeed * Time.deltaTime);

if (Input.acceleration.x != 0) 
		{
			CarState = State.Lean;

		}


		if (CarSpeed >= MaxSpeed) {
			CarSpeed = MaxSpeed;
		} 

		if (Input.touchCount == 0) 
		{
			Debug.Log("log");
			CarSpeed -= 0.2f;

			if(CarSpeed < 0)
			{
				CarSpeed = 0;
			}
			
		}

		if (CarSpeed > 0 &&  Input.acceleration.x < 0) {
			this.gameObject.transform.Rotate(-Vector3.up * CarRotSpeed * Time.deltaTime);
			
		}
		else if (CarSpeed > 0 && Input.acceleration.x > 0) {
			this.gameObject.transform.Rotate(Vector3.up * CarRotSpeed * Time.deltaTime);
			
		}


	}







	public void M_Drift()
	{






	
	
	}

	public void DriftExit()
	{
		CarSpeedDown = true;
		CarRotSpeed = 50;
		DriftWheel = false;


	
	}




	public void M_Accel()
	{
		CarSpeed += 0.1f;


			
			
			

			

	
	}





	public void AccelExit()
	{

		accelOn = false;
		CarSpeedDown = true;

		Debug.Log ("exit");

	}

	public void M_CountDecision()
	{

			
			if(Input.GetTouch(0).position.x < _half_width)
			{
				//Debug.Log("Left -> Accel");
			CarState = State.CarSpeedUp;





			}
			
			else 
			{
			Debug.Log("Right -> Drift");
			CarState = State.Lean;

			}


			
			



	}
	public void M_Lean()
	{
		if(Input.touchCount > 1)
		{
			

			CarSpeed = CarSpeed * 0.5f;
			CarRotSpeed = 1000;
			
			if (Input.acceleration.x < 0) {
				
				this.transform.RotateAround(Wheel[0].transform.position,Vector3.up,-1f);
				
			}
			else if (Input.acceleration.x > 0) {
				
				this.transform.RotateAround(Wheel[1].transform.position,Vector3.up,1f);
			}
	
	}

}

}