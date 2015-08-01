using UnityEngine;
using System.Collections;

public class cork : MonoBehaviour {

	// Use this for initialization

	public GameObject Cork;
	// Update is called once per frame
	void Update () {
		if (Raycast_Bottle.bottle_open) {
			Cork.SetActive (false);
//		} else {
//			Cork.SetActive (true);
//			//Debug.Log ("cork appear");
//		}
		//if(!Raycast_Bottle.bottle_open)
	}
	}}
