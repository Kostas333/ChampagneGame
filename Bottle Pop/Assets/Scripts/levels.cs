using UnityEngine;
using System.Collections;

public class levels : MonoBehaviour {

	public void ChangeLevel (int level_selection){
		
		if (level_selection == 1)
			Application.LoadLevel ("Main_Game2");
		if (level_selection == 2)
			Application.LoadLevel ("Main_Game");
		if (level_selection == 3)
			Application.LoadLevel ("Main_Game3");
		if (level_selection == 4)
			Application.LoadLevel ("Main_Game4");
		if (level_selection == 5)
			Application.LoadLevel ("Main_Game5");
		if (level_selection == 6)
			Application.LoadLevel ("Main_Game6");
		if (level_selection == 7)
			Application.LoadLevel ("Main_Game7");
		if (level_selection == 8)
			Application.LoadLevel ("Main_Game8");
		if (level_selection == 9)
			Application.LoadLevel ("Main_Game9");
		if (level_selection == 10)
			Application.LoadLevel ("Main_Game10");


}
}