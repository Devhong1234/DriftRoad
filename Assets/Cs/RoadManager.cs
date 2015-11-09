using UnityEngine;
using System.Collections;

public class RoadManager : MonoBehaviour {


	public GameObject[] RoadCreator = new GameObject[3];

	public Transform CurrentRoad;
	public Transform BeforeRoad;

	public Transform CurrentRoadSave;
	public Transform BeforeRoadSave;


	void Start () {
	/*
		BeforeRoadSave = BeforeRoad.transform.FindChild ("Vertex2");

		CurrentRoad = Instantiate (RoadCreator [0], BeforeRoadSave.transform.position,transform.rotation)as Transform;
		
		CurrentRoad.transform.position = CurrentRoadSave.position;

		RoadPosition ();

		StartCoroutine(CreateRoad());
	*/	


	}
	

	void Update () {

	}


	IEnumerator CreateRoad()
	{
	

		yield return new WaitForSeconds(2f);






	
	}

	void RoadPosition()
	{
		CurrentRoadSave = CurrentRoad.transform.FindChild ("Vertex1");


	
	
	}

}
