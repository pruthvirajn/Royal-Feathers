using UnityEngine;
using System.Collections;

public class Level01ChangeTex : MonoBehaviour {

	public Texture newTexture;
	private Texture oldTexture;
	
	//monitor if the hand is hover to UI Play button
	private bool hoverLevel01 = false;
	//delegate to control AR display 
	public delegate void changeARDisplayLevel01(object sender, string state);
	public event changeARDisplayLevel01 changeARLevel01;
	// Use this for initialization
	void Start () {
		oldTexture = GetComponent<Renderer>().material.mainTexture;
	}
	
	void OnCollisionEnter(Collision col){
		hoverLevel01 = true;
		GetComponent<Renderer>().material.mainTexture = newTexture;
	}
	
	
	void OnCollisionExit(Collision col){
		hoverLevel01 = false;
		GetComponent<Renderer>().material.mainTexture = oldTexture;
	}

	void OnMouseEnter (){
		hoverLevel01 = true;
		GetComponent<Renderer>().material.mainTexture = newTexture;
	}
	
	void OnMouseExit (){
		hoverLevel01 = false;
		GetComponent<Renderer>().material.mainTexture = oldTexture;
	}
	
	void OnMouseDown (){
		changeARLevel01 (this, "Stop");
		Application.LoadLevel ("Level01");
	}

	IEnumerator Level01Selected(){
		yield return new WaitForSeconds (1.0f);
		if (hoverLevel01) {
			print ("Inside:: Level01ChangeTex:: Level01Selected:: Inside If");
			changeARLevel01 (this, "Stop");
			Application.LoadLevel ("Level01");
		}
	}

	void Level01Commanded(){
		changeARLevel01 (this, "Stop");
		Application.LoadLevel ("Level01");
	}
}
