using UnityEngine;
using System.Collections;

public class StorylineFadeDialog : MonoBehaviour {
		
		public float start = 0f; //from
		public float end = 1f; //to
		public float speed = 2f; //t float
		public float waitTimeValue = 0.75f;

		void Start () {
			Color colorT = GetComponent<GUITexture>().color;
			colorT.a = 0.0f;
			GetComponent<GUITexture>().color = colorT;
			//Start the coroutine waitTime prior
			StartCoroutine (SlideShow(waitTimeValue));
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
				//return yield null - resume from here from next frame
				yield return null;
			}
		}
		
		IEnumerator SlideShow(float waitTimeValue){
			print ("Inside waitTime GameTitle");
			//yield stops execution and continues next frame from here when it gets return 'null' instead of instance
			yield return new WaitForSeconds (waitTimeValue);
			//continues from here only when above yield finds null return
			StartCoroutine (Fade(start, end, speed));
		}
}
