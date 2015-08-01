using UnityEngine;
using System.Collections;

public class eye : MonoBehaviour {
	public static bool eyeHit;
	void OnParticleCollision(GameObject other){
		//if(other.name=
		
		if (other.transform.tag == "Player") {
			Debug.Log("EYE");
			eyeHit=true;
			}
			
		}
	}
