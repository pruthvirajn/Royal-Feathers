using UnityEngine;
using System.Collections;

public class ChoiceDialogFade : MonoBehaviour {
	
	public float start = 0f; //from
	public float end = 0.5f; //to
	public float speed = 2.5f; //t float
	public float waitTimeValue = 10.0f;
	
	// Update is called once per frame
	void Start () {
		Color colorT = GetComponent<GUITexture>().color;
		//hide the texture by fading to 0 initially
		colorT.a = 0.0f;
		GetComponent<GUITexture>().color = colorT;
		StartCoroutine (waitTime(waitTimeValue));
	}
	
	IEnumerator Fade(float start, float end, float speed)
	{
		Color colorT = GetComponent<GUITexture>().color;
		float speedVal = 1.0f / speed;
		for (float i = 0.0f; i < 1.0f; i += Time.deltaTime * speedVal) {
			colorT.a = Mathf.Lerp(start, end, i);
			GetComponent<GUITexture>().color = colorT;
			//keeping yield inside the for loop makes the loop to continue further in next frames
			yield return null;
		}
	}
	
	IEnumerator waitTime(float waitTimeValue){
		print ("Inside waitTime GameTitle");
		yield return new WaitForSeconds (waitTimeValue);
		StartCoroutine (Fade(start, end, speed));
	}

}
