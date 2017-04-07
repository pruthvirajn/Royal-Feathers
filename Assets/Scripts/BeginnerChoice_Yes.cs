using UnityEngine;
using System.Collections;

public class BeginnerChoice_Yes : MonoBehaviour {

	public Texture2D normal;
	public Texture2D glow;
	//delegate to control AR display 
	public delegate void changeARDisplayEvent01(object sender, string state);
	public event changeARDisplayEvent01 changeAR01;

	void OnMouseEnter (){
		GetComponent<GUITexture>().texture = glow;
	}

	void OnMouseExit (){
		GetComponent<GUITexture>().texture = normal;
	}

	void OnMouseDown (){
		Application.LoadLevel ("GestureTrainingScene");
		changeAR01 (this, "Stop");
	}

	void ThumbUpTrigger(){
		Application.LoadLevel ("GestureTrainingScene");
		//make sure to turn off the camera
		changeAR01 (this, "Stop");
	}

}
