using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CarCtrl : MonoBehaviour {

	int score = 0;


	public GameObject[] Current;



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
	public Text scorePoint;
	public Text XRot;
	public Text ZRot;
	public Text OverPoint;

	Vector3 ResetPos;
	Quaternion ResetRot;
	public GameObject[] GameOver;


	public float _half_width;
	bool accelOn = false;



	public enum State
	{
	Wait_Touch = 0,
	CountDecision,
	CarSpeedUp,
	CarSpeedDown,
	CarRotSpeedUp,

	Drift,
	Lean,
	GaneOver,
	
	

	
	}

	State CarState;

	void Start () {
	
		WheelPivot = Wheel [3];
		_half_width = Screen.width * 0.5f;

		ResetPos = this.gameObject.transform.position;
		ResetRot = this.gameObject.transform.rotation;
		this.gameObject.GetComponent<Animation>().Play("Run");

		//GetComponent<Rigidbody>().centerOfMass =new Vector3(0,-1,0);
	}
	

	void Update () {







		XRot.text = Input.acceleration.x.ToString();
		ZRot.text = Input.acceleration.y.ToString();
		speedtext.text = CarSpeed.ToString ();
		speedRottext.text = CarRotSpeed.ToString ();

		scorePoint.text = score.ToString ();



		Debug.Log (Input.touchCount);

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
		case State.GaneOver:
			M_GameOver();
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
		score += 1;
		//this.gameObject.transform.Translate (Vector3.forward * CarSpeed * Time.deltaTime);// 트랜스폼이동 





		//this.gameObject.GetComponent<Rigidbody> ().position += transform.forward * CarSpeed * Time.deltaTime; // 물직적용




		//this.gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (this.gameObject.GetComponent<Rigidbody> ().velocity.x ,this.gameObject.GetComponent<Rigidbody> ().velocity.y,this.gameObject.GetComponent<Rigidbody> ().velocity.z * 2);

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
			


			//CarState = State.CarRotSpeedUp;
			Car.transform.RotateAround(Wheel[0].transform.position,Vector3.up,-1f);

			
		}
		else if (CarSpeed > 0 && Input.acceleration.x > 0) {


			//CarState = State.CarRotSpeedUp;
			Car.transform.RotateAround(Wheel[1].transform.position,Vector3.up,1f);

		}


	
	}



	public void M_CountDecision()
	{

			
			if(Input.GetTouch(0).position.x < _half_width)
			{





			CarState = State.CarSpeedUp;

			}
			
		if (Input.touchCount > 1 && Input.GetTouch (1).phase == TouchPhase.Began) {



			M_Drift ();

		} 

		else if (Input.touchCount > 1 && Input.GetTouch (1).phase == TouchPhase.Stationary) {
			



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

	public void M_GameOver()
	{
	




		for (int i = 0; i < GameOver.Length; i++) 
		{
		
			GameOver[i].SetActive(true);
		}

		for (int i = 0; i < Current.Length; i++) 
		{
			
			Current[i].SetActive(false);
		}


		OverPoint.text = score.ToString();
		CarSpeed = 0;






	}

	public void M_Reset()
	{
		for (int i = 0; i < GameOver.Length; i++) 
		{
			
			GameOver[i].SetActive(false);
		}

		for (int i = 0; i < Current.Length; i++) 
		{
			
			Current[i].SetActive(true);
		}

		score = 0;

		this.gameObject.transform.position = ResetPos;
		this.gameObject.transform.rotation = ResetRot;
	
	}



	void OnTriggerEnter(Collider Coll)
	{
	if (Coll.tag == "Wall") {
		
			M_GameOver ();

			Debug.Log ("Game Over");

		} 
		else if (Coll.tag == "Reset") 
		{
			M_Reset();
		
		}

		else if (Coll.tag == "Defence") 
		{
			M_GameOver();
			
		}
	
	}






}