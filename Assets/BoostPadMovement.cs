using UnityEngine;
using System.Collections;

public class BoostPadMovement : MonoBehaviour {


	public Vector3 velocityBoostPads = Vector3.zero;
	public Vector3 gravity;
	public float minSwipeDistY;
	private Vector2 startPos;
	public Vector3 CharBoostVelocity;
	public GameObject characterobject;
	public GameObject scoreobject;
	private CharacterMovement characterMovement;
	private BoostScore boostscore;
	bool didjump = false;



	void Start () {
		characterMovement = characterobject.GetComponent<CharacterMovement>();
		boostscore = scoreobject.GetComponent<BoostScore> ();
	}

	void OnTriggerStay2D(Collider2D collider) {
		if (Input.touchCount > 0) {
			Touch touch = Input.touches [0];
			switch (touch.phase) {
			case TouchPhase.Began:
				startPos = touch.position;
				break;
				
			case TouchPhase.Ended:
				float swipeDistVertical = (new Vector3 (0, touch.position.y, 0) - new Vector3 (0, startPos.y, 0)).magnitude;
				if (swipeDistVertical > minSwipeDistY) {
					float swipeValue = Mathf.Sign (touch.position.y - startPos.y);
					if (swipeValue > 0) {
						didjump = true;
						boostscore.AddPoint();
					}
				}	
				break;
			}
		}
	}

	void FixedUpdate (){
		if (didjump == true) {
			didjump = false;
			if (characterMovement.velocity.y < 0f) {
				characterMovement.velocity.y = 0f;
				characterMovement.velocity.y += CharBoostVelocity.y;
			} else {
				characterMovement.velocity.y += CharBoostVelocity.y;
			}
		}
		if (velocityBoostPads.y <= -6f) {
			transform.position += velocityBoostPads * Time.deltaTime;
		} 
		else {			
			velocityBoostPads += gravity * Time.deltaTime;
			
			transform.position += velocityBoostPads * Time.deltaTime;
		}
	}
}


	