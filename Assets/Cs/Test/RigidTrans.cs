using UnityEngine;
using System.Collections;

public class RigidTrans : MonoBehaviour {


	float h = 0f;
	float v = 0f;
	public int movespeed;
	public int rotspeed;
	public Material mat;

	public Vector3 _velocity;

	void Start () {
	

		//mat.color = Color.blue;
	
	}
	

	void Update () {
	
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");
		transform.Translate (Vector3.forward * v * movespeed * Time.deltaTime);
		transform.Rotate (Vector3.up, Time.deltaTime * rotspeed * h);
		//this.gameObject.GetComponent<Rigidbody> ().position += transform.forward * v * movespeed * Time.deltaTime; 
		//this.gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0,0,v * movespeed);
		//transform.Rotate (Vector3.up, Time.deltaTime *  h * 100);





		//this.gameObject.GetComponent<Rigidbody> ().angularVelocity = new Vector3(0,h * rotspeed * this.gameObject.GetComponent<Rigidbody>().angularVelocity.y,0);
	}
}
