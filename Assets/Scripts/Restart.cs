using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	public Material newMaterial;
	private Material oldMaterial;

	//monitor if the hand is hover to UI Play button
	private bool hoverLevel01 = false;
	//delegate to control AR display 
	public delegate void changeARDisplayRestart03(object sender, string state);
	public event changeARDisplayRestart03 changeARGame03;

	// Use this for initialization
	void Start () {
		oldMaterial = GetComponent<Renderer>().material;
		//When PlayMenu is selected bring the Restart mesh and collider 
		GameObject restart01 = GameObject.Find("PlayItem");
		restart01.GetComponent<PlayMenuChangeTex>().restartItem01+= delegate(Object sender) {
			GetComponent<Renderer>().enabled = true;
			GetComponent<Collider>().enabled = true;
		};
	}

	// Update is called once per frame
	void Update () {
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
		if (Input.GetKeyDown (KeyCode.R)) {
			changeARGame03(this, "Stop");
			//Application.LoadLevel ("Level01");
			Application.LoadLevel (Application.loadedLevelName);
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
		GetComponent<Renderer>().enabled = true;
		GetComponent<Collider>().enabled = true;
		changeARGame03(this, "Stop");
		Application.LoadLevel (Application.loadedLevelName);
	}
	
	void OnWaveRestart(){
		GetComponent<Renderer>().enabled = false;
		GetComponent<Collider>().enabled = false;
	}
	
	IEnumerator RestartGameSelected(){
		yield return new WaitForSeconds (1.0f);
		if (hoverLevel01) {
			print ("Inside:: QuitGame:: QuitSelected:: Inside If");
			changeARGame03(this, "Stop");
			//Application.LoadLevel ("Level01");
			Application.LoadLevel (Application.loadedLevelName);
		}
	}

	void RestartCommanded(){
		changeARGame03(this, "Stop");
		//Application.LoadLevel ("Level01");
		Application.LoadLevel (Application.loadedLevelName);
	}
}
