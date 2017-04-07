using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Material newMaterial;
	private Material oldMaterial;
	
	//monitor if the hand is hover to UI Play button
	private bool hoverLevel01 = false;
	//delegate to control AR display 
	public delegate void changeARDisplayGame01(object sender, string state);
	public event changeARDisplayGame01 changeARGame01;
	// Use this for initialization
	void Start () {
		oldMaterial = GetComponent<Renderer>().material;
		//When PlayMenu is selected bring the Restart mesh and collider 
		GameObject mainMenu01 = GameObject.Find("PlayItem");
		mainMenu01.GetComponent<PlayMenuChangeTex>().mainMenuItem01+= delegate(Object sender) {
			GetComponent<Renderer>().enabled = true;
			GetComponent<Collider>().enabled = true;
		};
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if(GetComponent<Renderer>().enabled){
				GetComponent<Renderer>().enabled = false;
				GetComponent<Collider>().enabled = false;
			}
			else{
				GetComponent<Renderer>().enabled = true;
				GetComponent<Collider>().enabled = true;
			}
		}
	}

	void OnCollisionEnter(Collision col){
		hoverLevel01 = true;
		GetComponent<Renderer>().material = newMaterial;
	}

	void OnCollisionExit(Collision col){
		hoverLevel01 = false;
		GetComponent<Renderer>().material = oldMaterial;
	}
	
	void OnMouseEnter (){
		hoverLevel01 = true;
		GetComponent<Renderer>().material = newMaterial;
	}
	
	void OnMouseExit (){
		hoverLevel01 = false;
		GetComponent<Renderer>().material = oldMaterial;
	}
	
	void OnMouseDown (){
		changeARGame01 (this, "Stop");
		Application.LoadLevel ("GameLevelScene");
	}

	void OnWaveMainMenu(){
		GetComponent<Renderer>().enabled = false;
		GetComponent<Collider>().enabled = false;
	}

	IEnumerator MainMenuSelected(){
		yield return new WaitForSeconds (1.0f);
		if (hoverLevel01) {
			print ("Inside:: MainMenu:: MainMenuSelected:: Inside If");
			changeARGame01 (this, "Stop");
			Application.LoadLevel ("GameLevelScene");
		}
	}

	void MainMenuCommanded(){
		changeARGame01 (this, "Stop");
		Application.LoadLevel ("GameLevelScene");
	}
}
