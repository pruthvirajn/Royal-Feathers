using UnityEngine;
using System.Collections;

public class PlayMenuChangeTex : MonoBehaviour {

	public Material newMaterial;
	private Material oldMaterial;
	//open up the user menu by activating their mesh and colliders using delegates below
	public delegate void openRestartMenuItem01(Object sender);
	public event openRestartMenuItem01 restartItem01;
	public delegate void openMainMenuItem01(Object sender);
	public event openMainMenuItem01 mainMenuItem01;
	public delegate void openQuitMenuItem01(Object sender);
	public event openQuitMenuItem01 quitItem01;
	//now activate the menu text label as well by one call
	public delegate void userMenuTextItems01(Object sender);
	public event userMenuTextItems01 userMenuText01;
	//monitor if the hand is hover to UI Play button
	private bool hoverLevel01 = false;
	
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
		//delegate the even to menu items
		restartItem01 (this);
		mainMenuItem01 (this);
		quitItem01 (this);
		userMenuText01 (this);
	}

	//On gesture call the below function - similar to mouse down events
	IEnumerator PlayMenuItemSelected(){
		//to make sure the user is really intend to select the menu item
		yield return new WaitForSeconds (2.0f);
		if (hoverLevel01) {
			print ("Inside:: PlayMenuChangeTex:: PlayMenuItemSelected:: Inside If");
			restartItem01 (this);
			mainMenuItem01 (this);
			quitItem01 (this);
			userMenuText01 (this);
		}
	}
}
