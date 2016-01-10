using UnityEngine;
using System.Collections;

public class collisionManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other) {
		if ( other.name == "Player" ) Physics.IgnoreLayerCollision( 8, 9, true );
		else Physics.IgnoreLayerCollision( 10, 9, true );
	}
	
}
