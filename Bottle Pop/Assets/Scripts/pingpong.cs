using UnityEngine;
using System.Collections;

public class pingpong : MonoBehaviour {

	private float min=2f;
	private float max=3f;
	public float speed=3f;
	public float distance=11f;
	// Use this for initialization
	void Start () {
		
		min=transform.position.x;
		max=transform.position.x+distance;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		transform.position =new Vector3(Mathf.PingPong(Time.time*2*speed,max-min)+min, transform.position.y, transform.position.z);
		
	}


}
