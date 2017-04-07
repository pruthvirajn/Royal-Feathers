using UnityEngine;
using System.Collections;

public class GameLevelChoose : MonoBehaviour {

	public Texture2D normal;
	public Texture2D glow;

	void OnMouseEnter (){
		GetComponent<GUITexture>().texture = glow;
	}
	
	void OnMouseExit (){
		GetComponent<GUITexture>().texture = normal;
	}
	
	void OnMouseDown (){
		Application.LoadLevel ("Level01");
	}
}
