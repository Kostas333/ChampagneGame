using UnityEngine;
using System.Collections;

public class Superpower1 : MonoBehaviour {

	private float dist;
	private Vector3 v3Offset;
	private Plane plane;

	
	//begin=true;
	void OnMouseDown() {
		if (Rotate.superpowerOn) {
			if (Rotate.stopMoving == true) {
				plane.SetNormalAndPosition (Camera.main.transform.forward, transform.position);
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				float dist;
				plane.Raycast (ray, out dist);
				v3Offset = transform.position - ray.GetPoint (dist); 
			}
		}
	}
	
	void OnMouseDrag() {
		if (Rotate.superpowerOn) {
			if (Rotate.stopMoving == true) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				float dist;
				plane.Raycast (ray, out dist);
				Vector3 v3Pos = ray.GetPoint (dist);
				transform.position = v3Pos + v3Offset;   

			}
		}
	}
}