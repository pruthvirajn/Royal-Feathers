using UnityEngine;
using System.Collections;

public class MainMenuWait : MonoBehaviour {

	public float waitTimeValue = 10.0f;
	
	//delegate to control AR display 
	public delegate void changeARDisplayEvent03(object sender, string state);
	public event changeARDisplayEvent03 changeAR03;
	
	// Use this for initialization
	void Start () {
		StartCoroutine (waitTime(waitTimeValue));
	}
	
	IEnumerator waitTime(float waitTimeValue){
		print ("Inside waitTime GameTitle");
		yield return new WaitForSeconds (waitTimeValue);
		//Use the changeAR delegate of Begin choice Yes and start AR display
		changeAR03(this, "Start");
	}
}
