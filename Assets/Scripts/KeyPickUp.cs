using UnityEngine;
using System.Collections;

public class KeyPickUp : MonoBehaviour {

	public float speed = 20;
	public int key = 0;
	
	
	GameObject player;
	playerHP playerHealth;
	
	
	void Awake(){
		
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <playerHP> ();
		
	}
	
	void Update () {
		
		transform.Rotate(Vector3.up, speed * Time.deltaTime);
	}
	
	void OnTriggerEnter(Collider other){
		
		if (other.tag == "Player" && key > 0) {
			playerHealth.pickupKey(key);
			Destroy(gameObject);
		}
	}
}
