using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		pauseGame ();
	}

	// Update is called once per frame
	void Update () {
		if ( Input.GetButtonDown( "Cancel" )) {
			pauseGame();
		}
	}

	private void enablePanel( string name ){

		GameObject giuCanvas = GameObject.Find ("GuiCanvas");
		
		foreach (Transform child in giuCanvas.transform) {
			if( child.name == name ) child.gameObject.SetActive( true );
			else child.gameObject.SetActive( false );
		}
	}

	private void selectCamera( string name){

		foreach (Camera camera in Camera.allCameras) {
			if( camera.name == name) camera.enabled= true;
			else camera.enabled= false;
		}
	}

	public void restartGame(){
		SceneManager.LoadScene ("start scene");
		//Application.LoadLevel(0);
	}

	public void startGame(){


		enablePanel ("hud");
		selectCamera ("MainCamera");
		Cursor.visible = false;
		Time.timeScale = 1;
		enableControll ();

	}

	public void pauseGame(){

		Time.timeScale = 0;
		//selectCamera ("MenuCamera");
		enablePanel ("mainMenu");
		Cursor.visible = true;
		disableControl ();
	}

	public void gameOver(){

		Time.timeScale = 0;
		enablePanel ("gameOver");
		Cursor.visible = true;
		disableControl ();

	}

	public void win(){
		
		Time.timeScale = 0;
		enablePanel ("win");
		Cursor.visible = true;
		disableControl ();
		
	}

	public void exitGame(){
		Application.Quit ();
	}

	void disableControl(){
		GameObject player = GameObject.Find ("Player");
		player.GetComponent<CharacterController> ().enabled = false;
		player.GetComponent<MouseLook> ().sensitivityX = 0;
		player.GetComponent<MouseLook> ().sensitivityY = 0;
	}

	void enableControll(){
		GameObject player = GameObject.Find ("Player");
		player.GetComponent<CharacterController> ().enabled = true;
		player.GetComponent<MouseLook> ().sensitivityX = 3;
		player.GetComponent<MouseLook> ().sensitivityY = 3;
	}
}
