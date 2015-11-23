using UnityEngine;
using System.Collections;

public class WheelCtrl : MonoBehaviour {


	public WheelCollider[] WheelCol;
	public Transform[] WheelMesh;
	public Transform CenterOfMass;
	public float Speed;

	public float prevSteerAngle;

	public float highestSpeed = 50f;
	public float lowSpeedSteerAngle = 10f;
	public float highSpeedSteerAngle = 1f;

	public float steermax;

	public float decspeed = 7f;

	public Rigidbody rb;

	void Start () {
	
		rb = this.GetComponent<Rigidbody>();
		rb.centerOfMass = CenterOfMass.localPosition;

	}
	

	void FixedUpdate () {
	
		/*

		float accelerate = Input.GetAxis("Vertical");
		float steer = Input.GetAxis("Horizontal");

		float finalAngle = steer * 45;
		WheelCol [0].steerAngle = finalAngle;
		WheelCol [1].steerAngle = finalAngle;


		WheelCol[2].motorTorque = accelerate * Speed;
		WheelCol[3].motorTorque = accelerate * Speed;

*/
		Control ();




	}


	void Update()
	{
	





		WheelMesh[0].Rotate (Vector3.up, WheelCol[0].steerAngle-prevSteerAngle, Space.World);
		WheelMesh[1].Rotate (Vector3.up, WheelCol[1].steerAngle-prevSteerAngle, Space.World);
		
		prevSteerAngle = WheelCol [0].steerAngle;
	
	
	}


	void Control()
	{
		WheelCol[2].motorTorque = Speed * Input.GetAxis("Vertical");
		WheelCol[3].motorTorque = Speed * Input.GetAxis("Vertical");
		

		if (!Input.GetButton ("Vertical")) {
		
			WheelCol [2].brakeTorque = decspeed;
			WheelCol [3].brakeTorque = decspeed;
		} 
		else 
		{
			WheelCol[2].brakeTorque = 0;
			WheelCol[3].brakeTorque = 0;

		}



		float speedFactor = rb.velocity.magnitude / highestSpeed;
		float steerAngle = Mathf.Lerp (lowSpeedSteerAngle, highSpeedSteerAngle,speedFactor);
		steerAngle *= Input.GetAxis ("Horizontal");
		
		
		
		
		
		
		
		//WheelCol[0].steerAngle = 45 * Input.GetAxis("Horizontal");
		//WheelCol[1].steerAngle = 45 * Input.GetAxis("Horizontal");
		WheelCol[0].steerAngle = steerAngle;
		WheelCol[1].steerAngle = steerAngle;
		
		
		WheelMesh [0].transform.Rotate (WheelCol[0].rpm/60 * 360 * Time.fixedDeltaTime ,0 ,0);
		WheelMesh [1].transform.Rotate (WheelCol[1].rpm/60 * 360 * Time.fixedDeltaTime ,0 ,0);
		WheelMesh [2].transform.Rotate (WheelCol[2].rpm/60 * 360 * Time.fixedDeltaTime ,0 ,0);

	
	
	}


}

