using UnityEngine;
using System.Collections;

public class MainMenuPlayChangeTex : MonoBehaviour {

	public Texture newTexture;
	private Texture oldTexture;

	//monitor if the hand is hover to UI Play button
	private bool hoverPlay = false;
	//delegate to control AR display 
	public delegate void changeARDisplayEvent02(object sender, string state);
	public event changeARDisplayEvent02 changeAR02;
	// Use this for initialization
	void Start () {
		oldTexture = GetComponent<Renderer>().material.mainTexture;
	}
	
	void OnCollisionEnter(Collision col){
		hoverPlay = true;
		GetComponent<Renderer>().material.mainTexture = newTexture;
	}
	
	
	void OnCollisionExit(Collision col){
		hoverPlay = false;
		GetComponent<Renderer>().material.mainTexture = oldTexture;
	}

	void OnMouseEnter (){
		hoverPlay = true;
		GetComponent<Renderer>().material.mainTexture = newTexture;
	}
	
	void OnMouseExit (){
		hoverPlay = false;
		GetComponent<Renderer>().material.mainTexture = oldTexture;
	}
	
	void OnMouseDown (){
		changeAR02 (this, "Stop");
		Application.LoadLevel ("GameLevelScene");
	}

	IEnumerator PlaySelected(){
		yield return new WaitForSeconds (1.0f);
		if (hoverPlay) {
			print ("Inside:: MainMenuPlayChangeTex:: PlaySelected:: Inside If");
			changeAR02 (this, "Stop");
			Application.LoadLevel ("GameLevelScene");
		}
	}

	void PlayCommanded(){
		changeAR02 (this, "Stop");
		Application.LoadLevel ("GameLevelScene");
	}
}
