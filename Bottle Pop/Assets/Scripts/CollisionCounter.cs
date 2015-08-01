using UnityEngine;
using System.Collections;

public class CollisionCounter : MonoBehaviour {
	public static int check;
	int countr=0;
	//int x=0;
	public static int score;
	void OnParticleCollision(GameObject other){
		//if(other.name=
		if (other.transform.tag == "OneUp") {
			Rotate.lives++;
			Debug.Log ("Mush hit");
		}
		if (other.transform.tag == "Player") {
			if (countr<20){
			countr++;
			score+=10;
			Debug.Log ("Score" + score);
			}
			//Debug.Log (countr);
			if (countr == 20){
				Debug.Log ("Target Reached");
				check++;
				countr++;
			}

		}
	}

	void Start(){

		Raycast_Bottle.TapCount = 0;
	}
	void Update(){
		if(Rotate.loseTrue==1){
			resetlevel();
			Application.LoadLevel("loseScreen");}
		if(Rotate.reset){
			resetlevel();
			Rotate.reset=false;
			Application.LoadLevel(Application.loadedLevel);
		}
		if (Input.GetKeyDown(KeyCode.Escape)) { 
			resetlevel ();
			Application.LoadLevel("LevelScene"); }
		if(Input.GetKeyDown(KeyCode.Menu)){ Application.Quit(); }

	}
	void OnGUI(){
		//score.ToString()
		var style = new GUIStyle("label");
		style.fontSize = 37;
		GUI.Label(new Rect(10, 10, 390, 160), "Score "+"  "+ score.ToString(),style);

		if (check==1)	
		GUI.Label(new Rect(10, 90, 390, 160), "Glass 1 Full",style);

		if (check == 2) {
			GUI.Label (new Rect (10, 140, 390, 160), "Glass 2 Full",style);
			GUI.Label (new Rect (10, 90, 390, 160), "Glass 1 Full",style);
		}
		if (check == 3) {

			GUI.Label (new Rect (10, 90, 390, 160), "Glass 3 Full",style);
			GUI.Label (new Rect (10, 140, 390, 160), "Glass 1 Full",style);
			GUI.Label (new Rect (10, 190, 390, 160), "Glass 2 Full",style);
			resetlevel ();

			//yield return new WaitForSeconds(5);

			Application.LoadLevel ("winScreen");
		}
		if (Rotate.message) 
		{
			GUI.Label (new Rect (610, 90, 900, 160), " Tap for bigger burst, In order to open the Bottle press the cork and then swipe up, then move your phone to rotate the bottle ",style);
		
		}
		if (Rotate.pregameMessage) 
		{
			GUI.Label (new Rect (610, 90, 900, 160), "Move the bottle wherever you want, but be careful you have only one chance, if you open the bottle you have to play it through in that position ",style);
			
		}
	}

	void resetlevel(){

		Rotate.pregameMessage = true;
		Rotate.accelerometer = false;
		check=0;
		score=0;
		countr=0;
		Rotate.lives=3;
		Rotate.loseTrue = 0;
		Rotate.message = false;
		Rotate.pregameMessage = false;
		eye.eyeHit = false;
		Rotate.stopMoving = true;
	}
	///score.ToString ()

}
