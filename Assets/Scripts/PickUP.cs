using UnityEngine;
using System.Collections;

public class PickUP : MonoBehaviour {

	public float speed = 20;
	public int healAmount = 5;


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

		if (other.tag == "Player" && playerHealth.currentHealth < playerHealth.startingHealth) {
			playerHealth.Heal(healAmount);
			Destroy(gameObject);
		}
	}
}
