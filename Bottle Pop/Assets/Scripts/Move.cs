using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Move : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
	public void OnBeginDrag(PointerEventData evendata)
	{
		//this.transform.position = evendata.position;
	}

	public void OnDrag(PointerEventData evendata)
	{
		this.transform.position = evendata.position;
	}

	public void OnEndDrag(PointerEventData evendata)
	{
		//this.transform.position = evendata.position;
	}

}

