using UnityEngine;
using System.Collections;

public class AutoRot : MonoBehaviour {

	public int speed = 250;
	public GameObject Car;
	float v = 0;
	float h = 0;


	void Start () {
	
	}
	

	void FixedUpdate () {
	

		v = Input.GetAxis ("Vertical");
		h = Input.GetAxis ("Horizontal");

		if (Car.transform.localRotation.y >= 0) // 자동회전.. 중력과같은원리로 기본적으로 로컬방향을 바라보게함
		{
			Car.transform.Rotate (-Vector3.up, Time.deltaTime * speed);



		}

		if (Car.transform.localRotation.y <= 0)  // 자동회전
		{
			Car.transform.Rotate (Vector3.up, Time.deltaTime * speed);
		



		
		
		}



		this.gameObject.GetComponent<Rigidbody> ().position = transform.forward * v * speed * Time.deltaTime;	//부모조정
		transform.Rotate (Vector3.up, Time.deltaTime *  h * 100); //부모조정



		if (v > 0 && Input.GetKey ("a")) // 두개의 키입력이 있을때만 자식회전..
		{

			Car.transform.Rotate (-Vector3.up, Time.deltaTime * v * 150); // 자식회전
		
		} 

		else if (v < 0 && Input.GetKey ("a")) // 같음
		
		{
		
			Car.transform.Rotate (Vector3.up, Time.deltaTime *  v * 150);// 같음
		
		}





	
	
	}
}
