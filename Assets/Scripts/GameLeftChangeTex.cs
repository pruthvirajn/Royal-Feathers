using UnityEngine;
using System.Collections;

public class GameLeftChangeTex : MonoBehaviour {

	public Texture newTexture;
	private Texture oldTexture;
	
	//delegate to control AR display 
	public delegate void changeARDisplayLeft(object sender);
	public event changeARDisplayLeft changeARleft;
	// Use this for initialization
	void Start () {
		oldTexture = GetComponent<Renderer>().material.mainTexture;
	}
	
	void OnCollisionEnter(Collision col){
		GetComponent<Renderer>().material.mainTexture = newTexture;
		print ("Inside:: GameLeftChangeTex:: LeftSelected:: Inside If");
		changeARleft (this);
	}
	
	
	void OnCollisionExit(Collision col){
		GetComponent<Renderer>().material.mainTexture = oldTexture;
	}

}
