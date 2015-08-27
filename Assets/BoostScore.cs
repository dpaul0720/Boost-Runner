using UnityEngine;
using System.Collections;

public class BoostScore : MonoBehaviour {


	public GameObject guiobject;
	private GUIText boostscore;
	public int score = 0;
	public void AddPoint() {
		score++;
	}


	// Use this for initialization
	void Start () {
		boostscore = guiobject.GetComponent<GUIText> ();
	}
	
	// Update is called once per frame
	void Update () {
		boostscore.text = "Score: " + score;
	}
}
