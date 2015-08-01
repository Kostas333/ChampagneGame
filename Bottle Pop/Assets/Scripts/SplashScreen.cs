using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("WaitThreeSeconds");

	}
	
	// Update is called once per frame
	void Update () {


	}
	IEnumerator WaitThreeSeconds(){

		yield return new WaitForSeconds(4);
		Application.LoadLevel ("LevelScene");
	}
}
