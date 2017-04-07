using UnityEngine;
using System.Collections;

public class Level02ChangeTex : MonoBehaviour {

	public Texture newTexture;
	private Texture oldTexture;
	
	//monitor if the hand is hover to UI Play button
	private bool hoverLevel02 = false;
	//delegate to control AR display 
	public delegate void changeARDisplayLevel02(object sender, string state);
	public event changeARDisplayLevel02 changeARLevel02;
	// Use this for initialization
	void Start () {
		oldTexture = GetComponent<Renderer>().material.mainTexture;
	}
	
	void OnCollisionEnter(Collision col){
		hoverLevel02 = true;
		GetComponent<Renderer>().material.mainTexture = newTexture;
	}
	
	
	void OnCollisionExit(Collision col){
		hoverLevel02 = false;
		GetComponent<Renderer>().material.mainTexture = oldTexture;
	}

	void OnMouseEnter (){
		hoverLevel02 = true;
		GetComponent<Renderer>().material.mainTexture = newTexture;
	}
	
	void OnMouseExit (){
		hoverLevel02 = false;
		GetComponent<Renderer>().material.mainTexture = oldTexture;
	}
	
	void OnMouseDown (){
		changeARLevel02 (this, "Stop");
		Application.LoadLevel ("Level02");
	}

	IEnumerator Level02Selected(){
		yield return new WaitForSeconds (1.0f);
		if (hoverLevel02) {
			print ("Inside:: Level02ChangeTex:: Level02Selected:: Inside If");
			changeARLevel02 (this, "Stop");
			Application.LoadLevel ("Level02");
		}
	}

	void Level02Commanded(){
		changeARLevel02 (this, "Stop");
		Application.LoadLevel ("Level02");
	}
}