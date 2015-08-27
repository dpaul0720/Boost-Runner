using UnityEngine;
using System.Collections;

public class BalconyScript : MonoBehaviour {
	public Vector3 velocity = Vector3.zero;
	public Vector3 gravity;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "BoostPad") {
			transform.position += new Vector3 (0f, ((Random.value + 10f) * 2f), 0f); 
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		
		if (velocity.y <= -6f) {
			transform.position += velocity * Time.deltaTime;
		} else {			
			velocity += gravity * Time.deltaTime;
			
			transform.position += velocity * Time.deltaTime;
		}
	}
}
