using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public Vector3 velocity = Vector3.zero;
	public Vector3 gravity;
	public Vector2 JumpVelocity;
	public float minSwipeDistX;
	private Vector2 startPos;
	bool isdead = false;
	bool didjump = false;
	public GameObject ninjaobject;
	Animator anim;
	public bool readyrestart = false;

	//bool didjump = false;

	// Use this for initialization
	void Start () {
		velocity.y = 3f;
		anim = ninjaobject.GetComponent<Animator> ();
	}

	void Update () {
		// Do inputs and shit here BRAHHHHH
		//if (Input.GetMouseButtonDown (0)) 
		//	didjump = true;
		if (isdead == true) {
			Time.timeScale = 0;
			readyrestart = true;
		}

		if (readyrestart == true && Input.GetMouseButtonDown(0)) {
			Time.timeScale = 1;
			Application.LoadLevel (Application.loadedLevel);
		

		}
	}





	void OnTriggerStay2D(Collider2D collider) {
		if (collider.tag == "BalconyR") {
			anim.SetTrigger ("didfallR");

		} 
		else if (collider.tag == "BalconyL") {
			anim.SetTrigger ("didfallL");

		}

	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "SpikesR") {
			anim.SetTrigger ("diddieR");
			isdead = true;

		} 
		else if (collider.tag == "SpikesL") {
			anim.SetTrigger ("diddieL");
			isdead = true;

		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		
		if (velocity.y <= -4f) {
			transform.position += velocity * Time.deltaTime;
		} 
		else {			
			velocity += gravity * Time.deltaTime;
		
			transform.position += velocity * Time.deltaTime;
		}


		if (Input.touchCount > 0) {
			Touch touch = Input.touches [0];
			switch (touch.phase) {
			case TouchPhase.Began:
				startPos = touch.position;
				break;
				
			case TouchPhase.Ended:
				float swipeDistHorizontal = (new Vector3 (touch.position.x, 0, 0) - new Vector3 (startPos.x, 0, 0)).magnitude;
				
				if (swipeDistHorizontal > minSwipeDistX) {					
					float swipeValue = Mathf.Sign (touch.position.x - startPos.x);
					if (swipeValue > 0 && transform.position.x < -2.1f) {//right swipe
						//MoveRight ();
						anim.SetTrigger("didjumpLR");
						velocity.x = 0f;
						velocity.x += JumpVelocity.x;
					} else if (swipeValue < 0 && transform.position.x > 2.1f) {//left swipe
						//MoveLeft ();
						anim.SetTrigger("didjumpRL");
						velocity.x = 0f;
						velocity.x += -JumpVelocity.x;
						//transform.rotation.z += -90f;
					}
				}
				break;
			}
		}


		//if (didjump == true && transform.position.x < -2.1f){
		//	anim.SetTrigger("didjumpLR");
		//	velocity.x = 0f;
		//	velocity.x += JumpVelocity.x;
		//	didjump = false;

		//}
		//if (didjump == true && transform.position.x > 2.1f){
		//	anim.SetTrigger("didjumpRL");
		//	velocity.x = 0f;
		//	velocity.x += -JumpVelocity.x;
		//	didjump = false;
			
		//}
	}	
}
