using UnityEngine;
using System.Collections;

public class GameTitleFade : MonoBehaviour {
	
	public float start = 1f; //from
	public float end = 0f; //to
	public float speed = 2.5f; //t float
	public float waitTimeValue = 5.0f;

	void Start () {
		//Start the coroutine waitTime prior
		StartCoroutine (waitTime(waitTimeValue));
	}

	IEnumerator Fade(float start, float end, float speed)
	{
		//store the alpha value 
		Color colorT = GetComponent<GUITexture>().color;
		float speedVal = 1.0f / speed;
		//lerp the fade in loop controlled by speed value
		for (float i = 0.0f; i < 1.0f; i += Time.deltaTime * speedVal) {
			colorT.a = Mathf.Lerp(start, end, i);
			GetComponent<GUITexture>().color = colorT;
			//return yield null
			yield return null;
		}
		if (GetComponent<GUITexture>().color.a <= 0.0) {
			GameObject.Destroy(this);
		}
	}

	IEnumerator waitTime(float waitTimeValue){
		print ("Inside waitTime GameTitle");
		//yield stops execution and continues next frame from here when it gets return 'null' instead of instance
		yield return new WaitForSeconds (waitTimeValue);
		//continues from here only when above yield finds null return
		StartCoroutine (Fade(start, end, speed));
	}
}
