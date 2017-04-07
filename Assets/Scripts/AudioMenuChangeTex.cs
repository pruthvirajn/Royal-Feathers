using UnityEngine;
using System.Collections;

public class AudioMenuChangeTex : MonoBehaviour {

	public Material newMaterial;
	private Material oldMaterial;

	//monitor if the hand is hover to UI Play button
	private bool hoverLevel01 = false;
	//toggle audio icon color from/to red on mouse click
	private bool isRed = false;
	//now delegate the event to start/pause audio
	public delegate void audioStartStop01(Object sender);
	public event audioStartStop01 audioItem01;
	// Use this for initialization
	void Start () {
		oldMaterial = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		hoverLevel01 = true;
		GetComponent<Renderer>().material = newMaterial;
		if (isRed) {
			GetComponent<Renderer>().material.color = Color.red;
		}
	}
	
	void OnCollisionExit(Collision col){
		hoverLevel01 = false;
		GetComponent<Renderer>().material = oldMaterial;
		GetComponent<Renderer>().material.color = Color.green;
		if (isRed) {
			GetComponent<Renderer>().material.color = Color.red;
		}
	}
	
	void OnMouseEnter (){
		hoverLevel01 = true;
		GetComponent<Renderer>().material = newMaterial;
		if (isRed) {
			GetComponent<Renderer>().material.color = Color.red;
		}
	}
	
	void OnMouseExit (){
		hoverLevel01 = false;
		GetComponent<Renderer>().material = oldMaterial;
		GetComponent<Renderer>().material.color = Color.green;
		if (isRed) {
			GetComponent<Renderer>().material.color = Color.red;
		}
	}
	
	void OnMouseDown (){
		if (isRed) {
			GetComponent<Renderer>().material.color = Color.green;
			isRed = false;
		} else {
			GetComponent<Renderer>().material.color = Color.red;
			isRed = true;
		}
		//delegate audio pause start event
		audioItem01 (this);
	}

	IEnumerator AudioMenuItemSelected(){
		yield return new WaitForSeconds (2.0f);
		if (hoverLevel01) {
			if (isRed) {
				GetComponent<Renderer>().material.color = Color.green;
				isRed = false;
			} else {
				GetComponent<Renderer>().material.color = Color.red;
				isRed = true;
			}
			print ("Inside:: AudioMenuChangeTex:: AudioMenuItemSelected:: Inside If");
			audioItem01 (this);
		}
	}
}
