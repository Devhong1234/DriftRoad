using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ctrl : MonoBehaviour {

	

	public float CarSpeed;
	public float MaxSpeed = 20;
	public float CarRotSpeed = 50;
	public float CarMaxRotSpeed = 200;




	public GameObject[] Wheel;


	
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
		
		
	}






	void M_CarSpeedUp()
	{

		CarSpeed += 0.1f;


		this.gameObject.GetComponent<Rigidbody> ().position += transform.forward * CarSpeed * Time.deltaTime; // 물직적용

		
		if (CarSpeed >= MaxSpeed) //MaxSpeed Limit
		{
			CarSpeed = MaxSpeed;
		} 

	}



	
	void M_CarSpeedDown()
	{
		
		CarSpeed -= 0.1f;
		
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
			
			
			

			transform.RotateAround(Wheel[0].transform.position,Vector3.up,-1f);
			
			
		}
		else if (CarSpeed > 0 && Input.acceleration.x > 0) {
			
			

			transform.RotateAround(Wheel[1].transform.position,Vector3.up,1f);
			
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
			this.gameObject.transform.Rotate(-Vector3.up * CarRotSpeed * Time.deltaTime);
			
		}
		
		else if (CarSpeed > 0 && Input.acceleration.x > 0) {
			this.gameObject.transform.Rotate(Vector3.up * CarRotSpeed * Time.deltaTime);
			
		}
	}
	

	

	

	
	
	
	
	
}