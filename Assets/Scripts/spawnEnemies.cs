using UnityEngine;

public class spawnEnemies : MonoBehaviour
{
	public playerHP playerHealth;
	public Transform[] spawnPoints;
	public GameObject enemy;
	public float spawnDelay = 3f;
	
	void Start ()
	{
		InvokeRepeating ("Spawn", spawnDelay, spawnDelay);
	}
	
	
	void Spawn ()
	{
		if(playerHealth.currentHealth <= 0f)
		{
			return;
		}
		
		int randomSpawn = Random.Range (0, spawnPoints.Length);
		
		Instantiate (enemy, spawnPoints[randomSpawn].position, spawnPoints[randomSpawn].rotation);
	}
}
