using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {

	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		if (eye.eyeHit) {
			Destroy(gameObject);
		}
	
	}
}
