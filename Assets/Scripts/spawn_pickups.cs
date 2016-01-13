using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawnpickups : MonoBehaviour {

	public static List<GameObject> ListSpawners;
	public GameObject keylvl1;
	public GameObject keylvl2;
	public GameObject keylvl3;
	public GameObject floppy1;
	public GameObject floppy2;
	// Use this for initialization
	void Start () {
		//Level 1
		ListSpawners = new List<GameObject> ();
		ListSpawners.AddRange (GameObject.FindGameObjectsWithTag("pickups_lvl1"));

		Random rand = new Random();
		List<int> result = new List<int>();
		HashSet<int> check = new HashSet<int>();
		int curValue = 0;
		for (int i = 0; i < 6; i++) {
			curValue = rand(0, ListSpawners.Count);
			while (check.Contains(curValue)) {
				curValue = rand(0, ListSpawners.Count);
			}
			result.Add(curValue);
			check.Add(curValue);
		}

		for(int i = 0; i < result.Count; i++){
			if(i == 0){
				Instantiate (keylvl1, ListSpawners[result[i]].transform.position, ListSpawners[result[i]].transform.rotation);
			}else{
				int randomNum = Random.Range (0, 2);
				if(randomNum == 1){
					Instantiate (floppy1, ListSpawners[result[i]].transform.position, ListSpawners[result[i]].transform.rotation);
				}else{
					Instantiate (floppy2, ListSpawners[result[i]].transform.position, ListSpawners[result[i]].transform.rotation);
				}
			}
		}

		//Level2

		ListSpawners = new List<GameObject> ();
		ListSpawners.AddRange (GameObject.FindGameObjectsWithTag("pickups_lvl2"));
		
		rand = new Random();
		result = new List<int>();
		check = new HashSet<int>();
		curValue = 0;
		for (int i = 0; i < 6; i++) {
			curValue = rand(0, ListSpawners.Count);
			while (check.Contains(curValue)) {
				curValue = rand(0, ListSpawners.Count);
			}
			result.Add(curValue);
			check.Add(curValue);
		}
		
		for(int i = 0; i < result.Count; i++){
			if(i == 0){
				Instantiate (keylvl2, ListSpawners[result[i]].transform.position, ListSpawners[result[i]].transform.rotation);
			}else{
				int randomNum = Random.Range (0, 2);
				if(randomNum == 1){
					Instantiate (floppy1, ListSpawners[result[i]].transform.position, ListSpawners[result[i]].transform.rotation);
				}else{
					Instantiate (floppy2, ListSpawners[result[i]].transform.position, ListSpawners[result[i]].transform.rotation);
				}
			}
		}

		//Level3

		ListSpawners = new List<GameObject> ();
		ListSpawners.AddRange (GameObject.FindGameObjectsWithTag("pickups_lvl2"));
		
		rand = new Random();
		result = new List<int>();
		check = new HashSet<int>();
		curValue = 0;
		for (int i = 0; i < 6; i++) {
			curValue = rand(0, ListSpawners.Count);
			while (check.Contains(curValue)) {
				curValue = rand(0, ListSpawners.Count);
			}
			result.Add(curValue);
			check.Add(curValue);
		}
		
		for(int i = 0; i < result.Count; i++){
			if(i == 0){
				Instantiate (keylvl3, ListSpawners[result[i]].transform.position, ListSpawners[result[i]].transform.rotation);
			}else{
				int randomNum = Random.Range (0, 2);
				if(randomNum == 1){
					Instantiate (floppy1, ListSpawners[result[i]].transform.position, ListSpawners[result[i]].transform.rotation);
				}else{
					Instantiate (floppy2, ListSpawners[result[i]].transform.position, ListSpawners[result[i]].transform.rotation);
				}
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
