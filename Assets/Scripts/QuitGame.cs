using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {

	public Material newMaterial;
	private Material oldMaterial;
	
	//monitor if the hand is hover to UI Play button
	private bool hoverLevel01 = false;
	//delegate to control AR display 
	public delegate void changeARDisplayGame02(object sender, string state);
	public event changeARDisplayGame02 changeARGame02;
	// Use this for initialization
	void Start () {
		oldMaterial = GetComponent<Renderer>().material;
		//When PlayMenu is selected bring the Restart mesh and collider 
		GameObject quit01 = GameObject.Find("PlayItem");
		quit01.GetComponent<PlayMenuChangeTex>().quitItem01+= delegate(Object sender) {
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
		if (Input.GetKeyDown (KeyCode.Q)) {
			changeARGame02 (this, "Stop");
			Application.Quit ();
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
		changeARGame02 (this, "Stop");
		Application.Quit ();
	}

	void OnMainMenuItemSelected(){
		GetComponent<Renderer>().enabled = true;
		GetComponent<Collider>().enabled = true;
	}
	
	void OnWaveQuitGame(){
		GetComponent<Renderer>().enabled = false;
		GetComponent<Collider>().enabled = false;
	}

	IEnumerator QuitGameSelected(){
		yield return new WaitForSeconds (1.0f);
		if (hoverLevel01) {
			print ("Inside:: QuitGame:: QuitSelected:: Inside If");
			changeARGame02 (this, "Stop");
			Application.Quit ();
		}
	}

	void QuitCommanded(){
		changeARGame02 (this, "Stop");
		Application.Quit ();
	}
}
