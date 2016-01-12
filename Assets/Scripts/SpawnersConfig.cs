using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SpawnersConfig : MonoBehaviour {

	public static int EnemyCount=10;
	public static float SpawnTime = 10f;
	public static List<GameObject> ListSpawners;
	public float timeLeft = 10.0f;
	public GameObject zombie;
	public GameObject infector;

	// Use this for initialization
	void Start () {
		ListSpawners = new List<GameObject> ();
		addSpawners();
	
	}
	
	// Update is called once per frame
	void Update () {

		timeLeft -= Time.deltaTime;
		if(timeLeft < 0)
		{
			spawnNow();
			timeLeft = SpawnTime;
		}
	
	}

	void addSpawners(){
		ListSpawners.AddRange (GameObject.FindGameObjectsWithTag("Spawn_lvl1"));
	}

	public static void addSpawner (GameObject tmp){
		//ListSpawners.Add (tmp);

		ListSpawners.AddRange (GameObject.FindGameObjectsWithTag("Spawn_lvl1"));
		//GameObject.FindGameObjectWithTag("Spawn_lvl1")
		//Debug.Log("AddedToList");
	}


	//constrains for lvl and spwaning
	void spawnNow(){
		Debug.Log (ListSpawners.Count);
	
		int randomSpawn = Random.Range (0, ListSpawners.Count);
		int randomEnemy = Random.Range (0, 2);

		///Debug.Log (randomSpawn+" "+randomEnemy);
		if (randomEnemy == 1) {
			spawnZombie (randomSpawn);
			//Debug.Log ("Zombie sawned");
		} else {
			spawnInfector(randomSpawn);

			//Debug.Log ("Infector sawned");
		}

	}

	void spawnZombie(int i){
		Instantiate (zombie, ListSpawners[i].transform.position, ListSpawners[i].transform.rotation);
	}
	void spawnInfector(int i){
		Instantiate (infector, ListSpawners[i].transform.position, ListSpawners[i].transform.rotation);
	}



}
