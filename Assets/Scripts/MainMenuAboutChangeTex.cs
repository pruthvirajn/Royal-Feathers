using UnityEngine;
using System.Collections;

public class MainMenuAboutChangeTex : MonoBehaviour {

	public Texture newTexture;
	private Texture oldTexture;
	//monitor hand hover on UI button about
	private bool hoverAbout = false;
	//delegate to control AR display 
	public delegate void changeARDisplayEvent01(object sender, string state);
	public event changeARDisplayEvent01 changeAR01;
	// Use this for initialization
	void Start () {
		oldTexture = GetComponent<Renderer>().material.mainTexture;
	}
	
	void OnCollisionEnter(Collision col){
		hoverAbout = true;
		GetComponent<Renderer>().material.mainTexture = newTexture;
	}
	
	
	void OnCollisionExit(Collision col){
		hoverAbout = false;
		GetComponent<Renderer>().material.mainTexture = oldTexture;
	}

	void OnMouseEnter (){
		hoverAbout = true;
		GetComponent<Renderer>().material.mainTexture = newTexture;
	}
	
	void OnMouseExit (){
		hoverAbout = false;
		GetComponent<Renderer>().material.mainTexture = oldTexture;
	}
	
	void OnMouseDown (){
		changeAR01 (this, "Stop");
		Application.LoadLevel ("StorylineScene");
	}

	IEnumerator AboutSelected(){
		yield return new WaitForSeconds (1.0f);
		if (hoverAbout) {
			print ("Inside:: MainMenuAboutChangeTex:: AboutSelected:: Inside If");
			changeAR01 (this, "Stop");
			Application.LoadLevel ("StorylineScene");
		}
	}

	void AboutCommanded(){
		changeAR01 (this, "Stop");
		Application.LoadLevel ("StorylineScene");
	}
}
