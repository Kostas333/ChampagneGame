using UnityEngine;
using System.Collections;

public class condm : MonoBehaviour {
	public ParticleSystem condmChampagne;
	private float condCounter;
	private bool condmBreak;
	public GameObject Condm;


	void OnParticleCollision(GameObject other){
		if (other.transform.tag == "Player") {
			condCounter+=20;
			Debug.Log ("hiiit");
			if (condCounter==3300){
				condmBreak=true;
				Debug.Log ("Condm filled");
				Condm.SetActive(false);
				condmChampagne.Play ();
			}
		}
	}


	}


