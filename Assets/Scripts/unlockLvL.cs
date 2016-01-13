using UnityEngine;
using System.Collections;

public class unlockLvL : MonoBehaviour {
	
	public int keyNeed = 0;
	
	
	GameObject player;
	playerHP playerHealth;
	
	
	void Awake(){
		
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <playerHP> ();
		
	}
	
	void Update () {

	}
	
	void OnTriggerEnter(Collider other){

		if (keyNeed == 1) {
			if (other.tag == "Player" && playerHealth.key1 == true) {
				Destroy(gameObject);
			}
		} else if (keyNeed == 2) {
			if (other.tag == "Player" && playerHealth.key2 == true) {
				Destroy(gameObject);
			}
		} else if (keyNeed == 3) {
			if (other.tag == "Player" && playerHealth.key3 == true) {
				
				GameObject manager = GameObject.Find ("_manager");
				manager.GetComponent<gameManager> ().win ();
				Destroy(gameObject);
			}
		}
	}
}
