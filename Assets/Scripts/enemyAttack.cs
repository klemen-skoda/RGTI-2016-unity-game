using UnityEngine;
using System.Collections;

public class enemyAttack : MonoBehaviour
{
	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;
	public bool playerInRange;

	GameObject player;
	playerHP playerHealth;
	enemyHP enemyHealth;
	float timer;
	
	
	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <playerHP> ();
		enemyHealth = GetComponent<enemyHP>();
	}
	
	
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = true;
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = false;
		}
	}
	
	
	void Update ()
	{
		timer += Time.deltaTime;
		
		if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
		{
			GetComponent<Animation>().CrossFade("Attack");
			Attack ();
		}

		if(playerHealth.currentHealth <= 0)
		{
			GetComponent<Animation>().CrossFade("Death");
		}
	}
	
	
	void Attack ()
	{
		timer = 0f;
		
		if(playerHealth.currentHealth > 0)
		{
			playerHealth.TakeDamage (attackDamage);
		}
	}
}
