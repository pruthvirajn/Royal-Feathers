using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public delegate void pausePlasmaEmitter01(object sender, bool status);
	public event pausePlasmaEmitter01 pausePlamaEm01;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Keep the below keyboard controls in this script only to support renderer for local gameobj
		if (Input.GetKeyDown (KeyCode.Space)) {
			if(Time.timeScale == 1.0f){
				Time.timeScale = 0.0f;
				GetComponent<Renderer>().enabled = true;
			}
			else{
				Time.timeScale = 1.0f;
				GetComponent<Renderer>().enabled = false;
			}
		}
	}
	//Uncheck and disable the mesh renderer by default
	//On wave gesture check for game timescale and freeze followed by renderer enable
	void OnPause(){
		if(Time.timeScale == 1.0f){
			Time.timeScale = 0.0f;
			GetComponent<Renderer>().enabled = true;
		}
	}

	//On fingers spread gesture check for game timescale and run the game usual with renderer disable
	void OnRun(){
		if(Time.timeScale == 0.0f){
			Time.timeScale = 1.0f;
			GetComponent<Renderer>().enabled = false;
		}
	}
}
