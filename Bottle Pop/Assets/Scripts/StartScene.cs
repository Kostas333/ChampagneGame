using UnityEngine;
using System.Collections;

public class StartScene : MonoBehaviour
{
	public void Change (int scene_selection){
		
		if (scene_selection == 1)
			Application.LoadLevel ("LevelScene");
		//if (scene_selection==2)
			//Application.LoadLevel ("highScoresScene");
		
	}

}
