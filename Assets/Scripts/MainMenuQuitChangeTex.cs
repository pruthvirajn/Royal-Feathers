using UnityEngine;
using System.Collections;

public class MainMenuQuitChangeTex : MonoBehaviour {

	public Texture newTexture;
	private Texture oldTexture;
	//monitor hand hover on UI button about
	private bool hoverQuit = false;
	//delegate to control AR display 
	public delegate void changeARDisplayEvent01(object sender, string state);
	public event changeARDisplayEvent01 changeAR04;
	// Use this for initialization
	void Start () {
		oldTexture = GetComponent<Renderer>().material.mainTexture;
	}
	
	void OnCollisionEnter(Collision col){
		hoverQuit = true;
		GetComponent<Renderer>().material.mainTexture = newTexture;
	}
	
	
	void OnCollisionExit(Collision col){
		hoverQuit = false;
		GetComponent<Renderer>().material.mainTexture = oldTexture;
	}

	void OnMouseEnter (){
		hoverQuit = true;
		GetComponent<Renderer>().material.mainTexture = newTexture;
	}
	
	void OnMouseExit (){
		hoverQuit = false;
		GetComponent<Renderer>().material.mainTexture = oldTexture;
	}
	
	void OnMouseDown (){
		changeAR04 (this, "Stop");
		Application.Quit ();
	}

	IEnumerator QuitSelected(){
		yield return new WaitForSeconds (1.0f);
		if (hoverQuit) {
			print ("Inside:: MainMenuQuitChangeTex:: QuitSelected:: Inside If");
			changeAR04 (this, "Stop");
			Application.Quit ();
		}
	}

	void QuitCommanded(){
		changeAR04 (this, "Stop");
		Application.Quit ();
	}
}
