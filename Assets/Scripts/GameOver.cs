using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	public float start04 = 0f; //from
	public float end04 = 1f; //to
	public float speed04 = 2.5f; //t float
	public float waitTimeValue04 = 0.75f;
	
	// Update is called once per frame
	void Start () {
		Color colorT = GetComponent<GUITexture>().color;
		//hide the texture by fading to 0 initially
		colorT.a = 0.0f;
		GetComponent<GUITexture>().color = colorT;
		GameObject bar = GameObject.Find ("CageHealthBars");
//		if(bar.GetComponent<FormulaBar>().redCount == 1 &&
//		   bar.GetComponent<FormulaBar>().greenCount == 1 &&
//		   bar.GetComponent<FormulaBar>().cyanCount == 1 &&
//		   bar.GetComponent<FormulaBar>().violetCount == 1 ){
//			
//		}
	}
	
	public void displayGameOver(){
		StartCoroutine (waitTime(waitTimeValue04));
	}
	
	IEnumerator Fade(float start, float end, float speed)
	{
		Color colorT = GetComponent<GUITexture>().color;
		float speedVal = 1.0f / speed;
		for (float i = 0.0f; i < 1.0f; i += Time.deltaTime * speedVal) {
			colorT.a = Mathf.Lerp(start, end, i);
			GetComponent<GUITexture>().color = colorT;
			yield return null;
		}
	}
	
	IEnumerator waitTime(float waitTimeValue){
		print ("Inside waitTime GameTitle");
		yield return new WaitForSeconds (waitTimeValue);
		StartCoroutine (Fade(start04, end04, speed04));
	}
}
