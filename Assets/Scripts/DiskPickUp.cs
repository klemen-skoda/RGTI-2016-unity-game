using UnityEngine;
using System.Collections;

public class DiskPickUp : MonoBehaviour {
		
		public float speed = 20;

		
		
		GameObject player;
		playerHP playerHealth;
		public AudioClip pickedDisk;
		
		
		void Awake(){
			
			player = GameObject.FindGameObjectWithTag ("Player");
			playerHealth = player.GetComponent <playerHP> ();
			
		}
		
		void Update () {
			
			transform.Rotate(Vector3.up, speed * Time.deltaTime);
		}
		
		void OnTriggerEnter(Collider other){
			
			if (other.tag == "Player") {
				changeScore.multiplier += 1;
			GetComponent<AudioSource>().PlayOneShot (pickedDisk);
				Destroy(gameObject);
			}
		}
}