using UnityEngine;
using System.Collections;

public class RotateTest : MonoBehaviour {


	Vector3 Dir;
	public GameObject cube;
	public int speed = 10;
	public Quaternion CarRot;

	State BoxRot;

	enum State
	{
		rotselect = 0,
		isRotate,

	
	}



	void Start () {
	
		Dir = new Vector3(this.gameObject.transform.rotation.x ,this.gameObject.transform.rotation.y, this.gameObject.transform.rotation.z);
		CarRot = cube.transform.rotation;
	}
	

	void FixedUpdate () {
	


		switch (BoxRot) 
		{
		case State.isRotate:
			IsRot();
			break;

		


		default:
			break;
		
		}




		if (Input.touchCount > 0 && Input.acceleration.x > 0) 
		{

			this.transform.RotateAround(this.gameObject.transform.position,Vector3.up, -1);

				
			}
			
		else if (Input.touchCount > 0 && Input.acceleration.x < 0) 
		{

			this.transform.RotateAround(this.gameObject.transform.position,Vector3.up,1);
			
			
		}
		

			
		
		if (Input.touchCount > 0) {
			if (Input.GetTouch (0).phase == TouchPhase.Ended) {
			





				if (this.gameObject.transform.rotation.y < 0) {



					BoxRot = State.isRotate;



					Debug.Log ("Left");


				
				} else if (this.gameObject.transform.rotation.y > 0) {

					BoxRot = State.isRotate;

					Debug.Log ("Right");

				}
			
			
			}
		}

		



}

	//중요

	public void IsRot()
	{


		speed -= 1;
		
		if (speed <= 0) { // MinSpeed Limit
			speed = 0;
			
		}
		
		transform.Rotate (-Vector3.up, Time.deltaTime * speed);
		
	






		/*

		Debug.Log ("isrotate");

		if (this.gameObject.transform.rotation.y > 0 && this.gameObject.transform.rotation.y < 180) {
		

			transform.Rotate (-Vector3.up, Time.deltaTime * speed);

		}

		if (this.gameObject.transform.rotation.y > 180 && this.gameObject.transform.rotation.y <= 359) 
		{
			
			transform.Rotate (Vector3.up, -Time.deltaTime * speed);
			
		} 



		if (this.gameObject.transform.localRotation.y < 0) {

			//transform.rotation = Quaternion.Euler (0, 0, 0); // 소숫점으로 회전하기때문에 오차범위도 어차피 눈에 뛰지않을정도기때문에 강제로 0으로 고정
			speed = 0;
			BoxRot = State.rotselect;
		} 

		else if (this.gameObject.transform.localRotation.y > 0) 
		{
		
			//transform.rotation = Quaternion.Euler (0, 0, 0); // 소숫점으로 회전하기때문에 오차범위도 어차피 눈에 뛰지않을정도기때문에 강제로 0으로 고정
			speed = 0;
			BoxRot = State.rotselect;

		}

*/
	}


	
}