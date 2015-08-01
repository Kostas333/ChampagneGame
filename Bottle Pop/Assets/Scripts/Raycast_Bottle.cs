using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Raycast_Bottle : MonoBehaviour {
	int move_a;
	public static int TapCount;
	public static bool bottle_open=false;
	//public static bool anime_true;

	void Start(){

	}
	// Update is called once per frame
	void Update () {


		//anime_true = false;
		Image image =GetComponent<Image>();

		if (Input.GetMouseButtonDown(0)) {
			Ray toMouse= Camera.main.ScreenPointToRay(Input.mousePosition);
			//Debug.Log("mouse clicked");
		
			RaycastHit hit;
			bool didhit=Physics.Raycast(toMouse,out hit,500.0f);


			if(didhit){

				if (hit.collider.name=="Cork"){
				Debug.Log("cork hit");
					bottle_open=true;
					Rotate.accelerometer=true;
					Debug.Log("move");

				}




				//}
				if (hit.collider.name=="bottle"&&Rotate.stop==1){
					if(Rotate.once){
						Rotate.once=false;
						image.fillAmount=0;
					}
					Debug.Log("bottle hit");
					TapCount++;

					//score++;

					image.fillAmount=Mathf.MoveTowards(image.fillAmount,1f,Time.deltaTime*4*0.9f);


					Debug.Log("Tap Count"+TapCount);
					//anime_true=true;


				}
}




		}}}