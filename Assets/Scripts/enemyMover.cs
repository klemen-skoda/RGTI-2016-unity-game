using UnityEngine;
using System.Collections;

public class enemyMover : MonoBehaviour
{
	Transform player;
	playerHP playerHealth;
	enemyHP enemyHealth;
	NavMeshAgent nav;
	enemyAttack attack;
	
	
	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		playerHealth = player.GetComponent <playerHP> ();
		enemyHealth = GetComponent <enemyHP> ();
		nav = GetComponent <NavMeshAgent> ();
		attack = GetComponent <enemyAttack> ();
	}
	
	
	void Update ()
	{
		if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && !attack.playerInRange)
		{
			nav.enabled = true;
			nav.SetDestination (player.position);
			if (nav.hasPath) {
				GetComponent<Animation>().CrossFade("Walk");
			}else{
				GetComponent<Animation>().CrossFade("Idle");
			}
		}
		else
		{
		    nav.enabled = false;
		}
	}
}
