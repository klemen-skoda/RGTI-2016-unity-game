using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class changeScore : MonoBehaviour {

	public static int score = 0;
	public static int multiplier = 1;
	
	Text text;

	void setScore (int points){
		points = points * multiplier;
		score += points;
	}

	void multiplierAdd (){
		multiplier += 1;
	}

	void Awake () {
		text = GetComponent <Text> ();
		score = 0;
	}

	void Update () {
		text.text = "Score: " + score;
	}
}
