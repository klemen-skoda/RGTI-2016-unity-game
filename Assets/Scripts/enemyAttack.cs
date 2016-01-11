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

	Animator animator;
	
	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <playerHP> ();
		enemyHealth = GetComponent<enemyHP>();
		animator = GetComponent<Animator> ();
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
			animator.Play ("attack", -1, 0f);
			Attack ();
		}

		if(playerHealth.currentHealth <= 0)
		{
			animator.Play ("death", -1, 0f);
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
