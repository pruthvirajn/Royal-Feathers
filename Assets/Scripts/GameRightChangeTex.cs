using UnityEngine;
using System.Collections;

public class GameRightChangeTex : MonoBehaviour {

	public Texture newTexture;
	private Texture oldTexture;
	
	//delegate to control AR display 
	public delegate void changeARDisplayRight(object sender);
	public event changeARDisplayRight changeARright;
	// Use this for initialization
	void Start () {
		oldTexture = GetComponent<Renderer>().material.mainTexture;
	}
	
	void OnCollisionEnter(Collision col){
		GetComponent<Renderer>().material.mainTexture = newTexture;
		print ("Inside:: GameRightChangeTex:: RightSelected:: Inside If");
		changeARright (this);
	}
	
	
	void OnCollisionExit(Collision col){
		GetComponent<Renderer>().material.mainTexture = oldTexture;
	}

}