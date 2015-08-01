using UnityEngine;
using System.Collections;

public class head : MonoBehaviour {

	public ParticleSystem drunkChampagne;
	private bool drunktrue=true;

	public GameObject dChampagne;
	
	
	void OnParticleCollision(GameObject other){
		if (other.transform.tag == "Player") {

			Debug.Log ("hiiit");
			//if (condCounter==3300){
				//condmBreak=true;
				//Debug.Log ("Condm filled");
				//Condm.SetActive(false);
			if(drunktrue){
			drunkChampagne.Play ();
				drunktrue=false;
			}
			}
		}
	}
	
	
