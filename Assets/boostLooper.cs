using UnityEngine;
using System.Collections;

public class boostLooper : MonoBehaviour {



	void OnTriggerEnter2D(Collider2D collider) {


		Vector3 pos = collider.transform.position;

		pos.y += 23f+(Random.value+1)*3;
		collider.transform.position = pos;
	}
}
