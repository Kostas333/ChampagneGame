using UnityEngine;
using System.Collections;

public class acmetr : MonoBehaviour {

	private Quaternion localRotation,resetLocation; // 
	public float speed = 1.0f; // ajustable speed from Inspector in Unity editor


	void Start () 
	{
		// copy the rotation of the object itself into a buffer
		localRotation = transform.rotation;
		//resetLocation = localRotation;
	}
	void Update () {
		if (Rotate.accelerometer) {
			float curSpeed = Time.deltaTime * speed;
			//dir.y = Input.acceleration.y;444444
			//	if (localRotation.y<.2)
			// first update the current rotation angles with input from acceleration axis
			//localRotation.y += Input.acceleration.y * curSpeed;
			//localRotation.x += Input.acceleration.x * curSpeed;
			localRotation.z += -Input.acceleration.x * curSpeed;
			// then rotate this object accordingly to the new angle
			transform.rotation = localRotation;
		}

	}
	
}

	// Use this for initialization
	//void Start () {
		
	//}
	/*
	// Update is called once per frame
	void Update () {
		Vector3 rotationAccel = new Vector3(0,0,0);
		rotationAccel.z = Input.acceleration.y;
		dir.y = Input.acceleration.y;
		
		
		if (dir.y > .2)
		{
			transform.Rotate(Vector3.up * (-rotSpeed * Time.deltaTime), Space.World);
		}
		else if (dir.y < -.2)
		{
			transform.Rotate(Vector3.up * (rotSpeed * Time.deltaTime), Space.World);
		}
	}
}*/
