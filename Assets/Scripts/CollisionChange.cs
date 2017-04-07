using UnityEngine;
using System.Collections;

public class CollisionChange : MonoBehaviour {
	public Texture newTexture;
	private Texture oldTexture;
	// Use this for initialization
	void Start () {
		oldTexture = GetComponent<Renderer>().material.mainTexture;
	}
	
	void OnCollisionEnter(Collision col){
		GetComponent<Renderer>().material.mainTexture = newTexture;
	}


	void OnCollisionExit(Collision col){
		GetComponent<Renderer>().material.mainTexture = oldTexture;
	}
}