using UnityEngine;
using System.Collections;

public class Wheel : MonoBehaviour {


	public Transform TireFL;
	public Transform TireFR;
	public Transform TireBL;
	public Transform TireBR;

	
	public Collider ColFL;
	public Collider ColFR;
	public Collider ColBL;
	public Collider ColBR;

	
	public Transform TransFL;
	public Transform TransFR;
	public Transform TransBL;
	public Transform TranBR;





	void Start () {
		GetComponent<Rigidbody>().centerOfMass =new Vector3(0,-1,0);
	}
	

	void FixedUpdate () {
		this.gameObject.GetComponent<Rigidbody> ().position += transform.forward * 100 * Time.deltaTime * Input.GetAxis("Vertical"); // 물직적용
		//transform.Rotate (Vector3.right * 100 * Input.GetAxis("Vertical"));
		ColFL.transform.Rotate (Vector3.right * 100 * Input.GetAxis("Vertical"));
		ColFR.transform.Rotate (Vector3.right * 100 * Input.GetAxis("Vertical"));
		ColBL.transform.Rotate (Vector3.right * 100 * Input.GetAxis("Vertical"));
		ColBR.transform.Rotate (Vector3.right * 100 * Input.GetAxis("Vertical"));


	}
}
