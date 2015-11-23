using UnityEngine;

using System.Collections;




public class FollowCam : MonoBehaviour
	
{
	
	public Transform carTransform;
	
	public float distance = 6.4f;
	
	public float height = 20f;
	
	public float rotationDamping = 3.0f;
	
	public float heightDamping = 2.0f;
	
	public float zoomRatio = 0.5f;
	
	public float defaultFOV = 60f;
	
	
	
	
	private Vector3 rotationVector = new Vector3();
	
	// Use this for initialization
	
	void Start ()
		
	{
		
	}
	
	
	
	
	void LateUpdate() {
		
		float wantedAngle = rotationVector.y;//carTransform.eulerAngles.y;
		
		float wantedHeight = carTransform.position.y + height;
		
		float camAngle = transform.eulerAngles.y;
		
		float camHeight = transform.position.y;
		
		camAngle = Mathf.LerpAngle(camAngle, wantedAngle, rotationDamping*Time.deltaTime);
		
		camHeight = Mathf.Lerp(camHeight, wantedHeight, heightDamping*Time.deltaTime);
		
		Quaternion qt = Quaternion.Euler(0,camAngle,0);
		
		transform.position = carTransform.position;
		
		transform.position -= qt * Vector3.forward*distance;
		
		transform.position += qt * Vector3.up * camHeight; //trouble

		transform.Rotate(Vector3.up*rotationVector.y);
		
		transform.LookAt(carTransform);
		
	}
	
	
	
	
	void FixedUpdate() {
		
		Vector3 localVelocity = carTransform.InverseTransformDirection(carTransform.GetComponent<Rigidbody>().velocity);



		if(localVelocity.z < -0.5f) {
			
			rotationVector.y = carTransform.eulerAngles.y + 180; // 후진시 카메라가 앞쪽에서 차를 바라보도록 한다
			
		}else{
			
			rotationVector.y = carTransform.eulerAngles.y;
			
		}


		float acc = carTransform.GetComponent<Rigidbody>().velocity.magnitude;
		
		GetComponent<Camera>().fieldOfView = defaultFOV + acc*zoomRatio;
		
	}
	
}

