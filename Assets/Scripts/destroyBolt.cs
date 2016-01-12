using UnityEngine;
using System.Collections;

public class destroyBolt : MonoBehaviour {

	public int boltDamage = 20;
	
	enemyHP enemy;

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary" || other.tag == "Player")
		{
			return;
		}
		if(!other.isTrigger){

			Destroy(gameObject);

			if(other.tag=="Infector"|| other.tag=="Zombie"){
				//Debug.Log (other.tag);

				enemy = other.GetComponent <enemyHP> ();

				if(enemy!=null){
					enemy.TakeDamage(boltDamage, transform.position);
				}

			}
		}
	}
}
