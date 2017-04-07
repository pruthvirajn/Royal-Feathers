using UnityEngine;
using System.Collections;

public class BeginnerChoice_No : MonoBehaviour {

	public Texture2D normal;
	public Texture2D glow;
	//delegate to control AR display 
	public delegate void changeARDisplayEvent02(object sender, string state);
	public event changeARDisplayEvent02 changeAR02;

	void OnMouseEnter (){
		GetComponent<GUITexture>().texture = glow;
	}
	
	void OnMouseExit (){
		GetComponent<GUITexture>().texture = normal;
	}
	
	void OnMouseDown (){
		Application.LoadLevel ("GameLevelScene");
		changeAR02 (this, "Stop");
	}

	void ThumbDownTrigger(){
		Application.LoadLevel ("GameLevelScene");
		//make sure to turn off camera
		changeAR02 (this, "Stop");
	}
}
