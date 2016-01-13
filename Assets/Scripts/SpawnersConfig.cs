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
	private int lvl;

	// Use this for initialization
	void Start () {
		ListSpawners = new List<GameObject> ();
		addSpawnersLvl1();
		lvl = 1;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (lvl == 1) {
			if (GameObject.FindGameObjectWithTag ("ForceKEY1") == null) {
				lvl = 2;
				addSpawnersLvl2 ();

			}
		}
		if (lvl == 2) {
			if (GameObject.FindGameObjectWithTag ("ForceKEY2") == null) {
				lvl = 3;
				addSpawnersLvl3 ();

			}
		}
		timeLeft -= Time.deltaTime;
		if(timeLeft < 0)
		{
			spawnNow();
			timeLeft = SpawnTime;
		}
	
	}

	void addSpawnersLvl1(){
		ListSpawners.AddRange (GameObject.FindGameObjectsWithTag("Spawn_lvl1"));
	}
	void addSpawnersLvl2(){
		GameObject[] tmp = GameObject.FindGameObjectsWithTag ("Spawn_lvl2");
		ListSpawners.AddRange (tmp);
		spawnPrime(tmp);
	}
	void addSpawnersLvl3(){
		GameObject[] tmp = GameObject.FindGameObjectsWithTag ("Spawn_lvl3");
		ListSpawners.AddRange (tmp);
		spawnPrime(tmp);
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

	void spawnPrime(GameObject[] list){
		for (int i = 0; i < list.Length; i++) {
			spawnRandomEnemyOnLocation (list [i]);
		}
	}


	void spawnRandomEnemyOnLocation(GameObject location){
		int randomEnemy = Random.Range (0, 2);
		if (randomEnemy == 1) {
			Instantiate (zombie, location.transform.position, location.transform.rotation);
			//Debug.Log ("Zombie sawned");
		} else {
			Instantiate (infector, location.transform.position, location.transform.rotation);

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
