using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	// Update is called once per frame
	public void changeScene (int scene) {
		Application.LoadLevel(scene);
	}

	public void exitGame ()
	{
		Application.Quit ();
	}
}
