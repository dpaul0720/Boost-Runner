using UnityEngine;
using System.Collections;

public class WallLooperTexture : MonoBehaviour {
	
	Vector2 velocity = Vector2.zero;
	public Vector2 gravity;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (velocity.y <= -.1f) {
			GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (0f, -Time.time * -.3f);
		} 
		else {			
			velocity += gravity * Time.deltaTime;
			GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (0f, -Time.time * velocity.y);
		}
	}
}