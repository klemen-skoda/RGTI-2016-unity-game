using UnityEngine;
using System.Collections;

public class mover : MonoBehaviour {

	public float speed;

	void Update () {
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}

}
