using UnityEngine;
using System.Collections;

public class UserMenuTextItems : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//When PlayMenu is selected bring the Restart mesh and collider 
		GameObject menuLabel01 = GameObject.Find("PlayItem");
		menuLabel01.GetComponent<PlayMenuChangeTex>().userMenuText01+= delegate(Object sender) {
			GetComponent<Renderer>().enabled = true;
		};
	}
	
	// Update is called once per frame
	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if(GetComponent<Renderer>().enabled){
				GetComponent<Renderer>().enabled = false;
			}
			else{
				GetComponent<Renderer>().enabled = true;
			}
		}
	}

	void OnWaveMenuItems(){
		GetComponent<Renderer>().enabled = false;
	}
}
