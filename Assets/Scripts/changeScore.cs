using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class changeScore : MonoBehaviour {

	public static int score = 0;
	
	Text text;

	void setScore (int points){
		score += points;
	}

	void Awake () {
		text = GetComponent <Text> ();
		score = 0;
	}

	void Update () {
		text.text = "Score: " + score;
	}
}
