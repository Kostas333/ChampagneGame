
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Rotate_demo : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler {
	//public static bool MoveRight=false;
	//public static bool MoveLeft=false;
	private float angle;
	public ParticleSystem Champagne;
	//private Raycast_Bottle ray;
	public float minSwipeDistY;
	public float minSwipeDistX;
	
	//zoom
	public float moveSensitivityX = 0.5f;
	public float moveSensitivityY = 0.5f;
	public bool updateZoomSensitivity = true;
	public float orthoZoomSpeed = 0.03f;
	public float minZoom = 1.0f;
	public float maxZoom = 16.0f;
	public bool invertMoveX = false;
	public bool invertMoveY = false;
	public float mapWidth = 60.0f;
	public float mapHeight = 40.0f;
	public static bool pregameMessage=true;
	public float inertiaDuration = 1.0f;
	public static bool begin;
	public static bool play;
	private Camera _camera;
	
	private float minX, maxX, minY, maxY;
	private float horizontalExtent, verticalExtent;
	
	private float scrollVelocity = 0.0f;
	private float timeTouchPhaseEnded;
	private Vector2 scrollDirection = Vector2.zero;
	//
	
	public float gravityModifier;
	private Vector2 startPos;
	public static int lives=3;
	//private static int score;
	//Image image =GetComponent<Image>();
	//public Image life0;
	public Image life1;
	public Image life2;
	public Image life3;
	public int z;
	public static bool stopMoving=true;
	public static int loseTrue;
	public static int stop;
	public static bool message=false;
	int move_a;
	public SpriteRenderer sprender;
	public GameObject Cork;
	public static bool once=false;
	public static int superpower=1;
	public static bool superpowerOn=false;
	public static bool reset=false;
	//Button Script
//	public void ArrowL(){
//		angle = angle + 7;
//		transform.eulerAngles = new Vector3 (0, 0, angle);
//		
//	}
//	public void ArrowR(){
//		angle = angle - 7;
//		transform.eulerAngles = new Vector3 (0, 0, angle);
//		
//	}
	public void Reset(){
		
		reset = true;
	}
	public void SuperPower(){
		//superpower = 0;
		superpowerOn = true;
		
	}
	
	void Start(){
		
		//	_transform = transform;
		_camera = Camera.main;
		maxZoom = 0.5f * (mapWidth / _camera.aspect);
		
		float diffY = mapHeight / 2 - minZoom;
		float diffX = (mapWidth / 2 - (minZoom * Camera.main.aspect))/ Camera.main.aspect;
		maxZoom = minZoom + Mathf.Min (diffY, diffX);
		if (Camera.main.orthographicSize > maxZoom)
			Camera.main.orthographicSize = maxZoom;
		
		CalculateLevelBounds ();
		//Raycast_Bottle ray=GetComponent<Raycast_Bottle>();
	}
	
	void Update()
	{
		//Champagne begin
		
		if (Drag.gamestart && Champagne.isStopped) {
			message = true;
			pregameMessage=false;
		}
		
		if (Drag.gamestart) {
			if (Champagne.isPlaying) {
				begin = false;
				message = false;
				play=true;
			}
			
			if (!Raycast_Bottle.bottle_open&&Champagne.isStopped){
				if (once){
					Raycast_Bottle.TapCount=0;
				}
				Cork.SetActive (true);
				stopMoving = true;
				stop = 1;
			}
			if (Champagne.isStopped && lives == 0) {
				loseTrue = 1;
				
			}
//			if (Input.GetKey ("a")) {
//				
//				MoveLeft = true;
//				
//			}
//			//rotate right
//			if (Input.GetKey ("d")) {
//				MoveRight = true;
//				
//			}
			//swipe and open bottle
			if (Input.GetKey ("e") && Champagne.isStopped&& Raycast_Bottle.bottle_open) {
				
				
				if (lives >0) {
					stop=0;
					pregameMessage=false;
					stopMoving=false;
					Champagne.Play ();
					once=true;
					Raycast_Bottle.bottle_open=false;
					superpowerOn=false;				
					
					if(lives==3)
					{
						
						
						life1.enabled= false;
						life2.enabled=true;
						life3.enabled=true;
						//life1.de
						
					}
					if (lives == 2){
						
						life1.enabled= false;
						life2.enabled=false;
						life3.enabled=true;
					}
					if (lives == 1){
						
						life1.enabled= false;
						life2.enabled=false;
						life3.enabled=false;
					}
					lives--;
				} else if (lives == 0) {
					Debug.Log ("No more Champagne Left");
				}
			}
			//		if (move_a==2){
			//			Debug.Log("hit right");
			//			Rotate.MoveRight=true;
			//			
			//		}
			//		if (move_a==1){
			//			Debug.Log("hit left");
			//			//	Rotate.MoveLeft=true;
			//			Rotate.MoveLeft=true;
			//		}
			//	if (MoveLeft) {
			//			angle = angle + 7;
			//			transform.eulerAngles = new Vector3 (0, 0, angle);
			//			MoveLeft=false;
			//		}
			//		if (MoveRight) {
			//			angle = angle - 7;
			//			transform.eulerAngles = new Vector3 (0, 0, angle);
			//			MoveRight=false;
			//		}
			if (Raycast_Bottle.TapCount == 0) {
				//Debug.Log ("SMALL BURST");
				//Champagne=GetComponent<ParticleSystem>();
				Champagne.gravityModifier = 2;
			}
			
			if (Raycast_Bottle.TapCount < 2) {
				//Debug.Log ("SMALL BURST");
				//Champagne=GetComponent<ParticleSystem>();
				Champagne.gravityModifier = 1.2f;
			}
			if (Raycast_Bottle.TapCount > 2 && Raycast_Bottle.TapCount < 8) {
				//Debug.Log ("MEDIUM BURST");
				Champagne.gravityModifier = 0.9f;
			}
			if (Raycast_Bottle.TapCount > 7 && Raycast_Bottle.TapCount < 12) {
				//	Debug.Log ("BIGGER BURST");
				Champagne.gravityModifier = 0.7f;
			}
			if (Raycast_Bottle.TapCount > 11) {
				//Debug.Log ("HUGE BURST");
				Champagne.gravityModifier = 0.5f;
			}
		}
		//#if UNITY_ANDROID
		
		//Zoom in-out
		
		if (updateZoomSensitivity)
		{
			moveSensitivityX = _camera.orthographicSize / 5.0f;
			moveSensitivityY = _camera.orthographicSize / 5.0f;
		}
		
		Touch[] touches = Input.touches;
		
		if (touches.Length < 1)
		{
			//if the camera is currently scrolling
			if (scrollVelocity != 0.0f)
			{
				//slow down over time
				float t = (Time.time - timeTouchPhaseEnded) / inertiaDuration;
				float frameVelocity = Mathf.Lerp (scrollVelocity, 0.0f, t);
				_camera.transform.position += -(Vector3)scrollDirection.normalized * (frameVelocity * 0.05f) * Time.deltaTime;
				
				if (t >= 1.0f)
					scrollVelocity = 0.0f;
			}
		}
		if (touches.Length > 0)
		{
			//Single touch (move)
			//			if (touches.Length == 1)
			//			{
			//				if (touches[0].phase == TouchPhase.Began)
			//				{
			//					scrollVelocity = 0.0f;
			//				}
			//				else if (touches[0].phase == TouchPhase.Moved)
			//				{
			//					Vector2 delta = touches[0].deltaPosition;
			//					
			//					float positionX = delta.x * moveSensitivityX * Time.deltaTime;
			//					positionX = invertMoveX ? positionX : positionX * -1;
			//					
			//					float positionY = delta.y * moveSensitivityY * Time.deltaTime;
			//					positionY = invertMoveY ? positionY : positionY * -1;
			//					
			//					_camera.transform.position += new Vector3 (positionX, positionY, 0);
			//					
			//					scrollDirection = touches[0].deltaPosition.normalized;
			//					scrollVelocity = touches[0].deltaPosition.magnitude / touches[0].deltaTime/2;
			//					
			//					
			//					if (scrollVelocity <= 100)
			//						scrollVelocity = 0;
			//				}
			//				else if (touches[0].phase == TouchPhase.Ended)
			//				{
			//					timeTouchPhaseEnded = Time.time;
			//				}
			//			}
			
			
			//Double touch (zoom)
			if (touches.Length == 2)
			{
				Vector2 cameraViewsize = new Vector2 (_camera.pixelWidth, _camera.pixelHeight);
				
				Touch touchOne = touches[0];
				Touch touchTwo = touches[1];
				
				Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
				Vector2 touchTwoPrevPos = touchTwo.position - touchTwo.deltaPosition;
				
				float prevTouchDeltaMag = (touchOnePrevPos - touchTwoPrevPos).magnitude;
				float touchDeltaMag = (touchOne.position - touchTwo.position).magnitude;
				
				float deltaMagDiff = prevTouchDeltaMag - touchDeltaMag;
				
				_camera.transform.position += _camera.transform.TransformDirection ((touchOnePrevPos + touchTwoPrevPos - cameraViewsize) * _camera.orthographicSize / cameraViewsize.y);
				
				_camera.orthographicSize += deltaMagDiff * orthoZoomSpeed;
				_camera.orthographicSize = Mathf.Clamp (_camera.orthographicSize, minZoom, maxZoom) - 0.001f;
				
				_camera.transform.position -= _camera.transform.TransformDirection ((touchOne.position + touchTwo.position - cameraViewsize) * _camera.orthographicSize / cameraViewsize.y);
				
				CalculateLevelBounds ();
			}
		}
		
		
		
		
		//Swipe
		if (Input.touchCount > 0) 
			
		{
			
			Touch touch = Input.touches[0];
			
			
			
			switch (touch.phase) 
			{
				
			case TouchPhase.Began:
				
				startPos = touch.position;
				
				break;
				
				
				
			case TouchPhase.Ended:
				
				float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
				
				if (swipeDistVertical > minSwipeDistY) 
					
				{
					
					float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
					
					if (swipeValue > 0)//up swipe
					{
						if(Champagne.isStopped&& Raycast_Bottle.bottle_open){
							
							if (lives >0) {
								stop=0;
								pregameMessage=false;
								stopMoving=false;
								Champagne.Play ();
								once=true;
								Raycast_Bottle.bottle_open=false;
								superpowerOn=false;				
								
								if(lives==3)
								{
									
									
									life1.enabled= false;
									life2.enabled=true;
									life3.enabled=true;
									//life1.de
									
								}
								if (lives == 2){
									
									life1.enabled= false;
									life2.enabled=false;
									life3.enabled=true;
								}
								if (lives == 1){
									
									life1.enabled= false;
									life2.enabled=false;
									life3.enabled=false;
								}
								lives--;
							} else if (lives == 0) {
								Debug.Log ("No more Champagne Left");
							}
							//else 
							//		break;
							
						}
					}
					
				}
				break;
			}}}
	
	public void OnBeginDrag(PointerEventData evendata)
	{
		Debug.Log ("begin drag");
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
	void CalculateLevelBounds ()
	{
		verticalExtent = _camera.orthographicSize;
		horizontalExtent = _camera.orthographicSize * Screen.width / Screen.height;
		minX = horizontalExtent - mapWidth / 2.0f;
		maxX = mapWidth / 2.0f - horizontalExtent;
		minY = verticalExtent - mapHeight / 2.0f;
		maxY = mapHeight / 2.0f - verticalExtent;
	}
	
	void LateUpdate ()
	{
		Vector3 limitedCameraPosition = _camera.transform.position;
		limitedCameraPosition.x = Mathf.Clamp (limitedCameraPosition.x, minX, maxX);
		limitedCameraPosition.y = Mathf.Clamp (limitedCameraPosition.y, minY, maxY);
		_camera.transform.position = limitedCameraPosition;
	}
	
	void OnDrawGizmos ()
	{
		Gizmos.DrawWireCube (Vector3.zero, new Vector3 (mapWidth, mapHeight, 0));
	}
	
}