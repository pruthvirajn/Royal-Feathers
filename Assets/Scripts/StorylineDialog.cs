using UnityEngine;
using System.Collections;

public class StorylineDialog : MonoBehaviour {
	//delegate to control AR display 
	public delegate void changeARDisplayEvent03(object sender, string state);
	public event changeARDisplayEvent03 changeARstoryline;
	// Use this for initialization
	void Start () {
		StartCoroutine (SceneTimeout (30.0f));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			changeARstoryline (this, "Stop");
			Application.LoadLevel ("GameLevelScene");
		}
	}

	IEnumerator SkipSelected(){
		yield return new WaitForSeconds (1.0f);
		changeARstoryline (this, "Stop");
		Application.LoadLevel ("GameLevelScene");
	}

	//maximum scene skip wait timeout
	IEnumerator SceneTimeout(float waitValue){
		yield return new WaitForSeconds (waitValue);
		changeARstoryline (this, "Stop");
		Application.LoadLevel ("GameLevelScene");
	}
}
