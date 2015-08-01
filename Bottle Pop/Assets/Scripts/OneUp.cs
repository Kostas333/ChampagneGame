using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
public class OneUp : MonoBehaviour {
	public GameObject oneup;
	public Image life1;
	public Image life2;
	public Image life3;
	// Use this for initialization
	void OnParticleCollision(GameObject other){
	
	// Update is called once per frame
	if (other.transform.tag == "Player") {
			Rotate.lives++;
			Debug.Log("Mush hit");
			Destroy(oneup);
			if(Rotate.lives==4)
			{
				
				
				life1.enabled= true;
				life2.enabled=true;
				life3.enabled=true;
				//life1.de
				
			}

			if(Rotate.lives==3)
			{
				
				
				life1.enabled= true;
				life2.enabled=true;
				life3.enabled=true;
				//life1.de
				
			}
			if (Rotate.lives == 2){
				
				life1.enabled= false;
				life2.enabled=true;
				life3.enabled=true;
			}
			if (Rotate.lives == 1){
				
				life1.enabled= false;
				life2.enabled=false;
				life3.enabled=true;
			}
	}

}
}