using UnityEngine;
using System.Collections;

public class FamiliarizeGestureCheck : MonoBehaviour {
	//To fade in or fade up, set start=0 and end =1
	private float startVal = 0f; //from
	private float endVal = 1f; //to
	private float speedVal = 2.5f; //t float
	public float waitTimer = 0.75f;
	//set initial normal texture
	public Texture2D normal;
	//to keep track of present glow texture
	private Texture2D glow;

	//setup the initial normal and corresponding glow textures to begin further
	public Texture2D ThumbsUpNormal;
	public Texture2D ThumbsUpGlow;
	public Texture2D ThumbsDownNormal;
	public Texture2D ThumbsDownGlow;
	public Texture2D Big5Normal;
	public Texture2D Big5Glow;
	public Texture2D FistNormal;
	public Texture2D FistGlow;
	public Texture2D SwipeLeftNormal;
	public Texture2D SwipeLeftGlow;
	public Texture2D SwipeRightNormal;
	public Texture2D SwipeRightGlow;
	public Texture2D WaveNormal;
	public Texture2D WaveGlow;

	private bool isThumbUp = false;
	private bool isThumbDown = false;
	private bool isBig5 = false;
	private bool isFist = false;
	private bool isSwipeLeft = false;
	private bool isSwipeRight = false;
	private bool isThumbRight = false;
	private bool isWave = false;

	// Use this for initialization
	void Start () {

	}

	void OnMouseDown() {
		print ("FamiliarizeGestureCheck: Inside OnMouseDown");
		//based on the existing normal texture, choose its corresponding glow texture and move to fade in for next

		switch(normal.ToString()){
			//During Comparision ToString appending (UnityEngine.Texture2D) to texture name, so append the same in case
			//statements too! :/
		case "ThumbsUp-Normal (UnityEngine.Texture2D)": 
			//assign the glow texture
			GetComponent<GUITexture>().texture = ThumbsUpGlow;
			glow = ThumbsUpGlow;
			//start the wait timer before switching to next gesture texture
			StartCoroutine (waitTime(waitTimer));
			break;
		case "ThumbsDown-Normal (UnityEngine.Texture2D)": 
			GetComponent<GUITexture>().texture = ThumbsDownGlow;
			glow = ThumbsDownGlow;
			StartCoroutine (waitTime(waitTimer));
			break;
		case "Big5-Normal (UnityEngine.Texture2D)": 
			GetComponent<GUITexture>().texture = Big5Glow;
			glow = Big5Glow;
			StartCoroutine (waitTime(waitTimer));
			break;
		case "Fist-Normal (UnityEngine.Texture2D)": 
			GetComponent<GUITexture>().texture = FistGlow;
			glow = FistGlow;
			StartCoroutine (waitTime(waitTimer));
			break;
		case "SwipeLeft-Normal (UnityEngine.Texture2D)": 
			GetComponent<GUITexture>().texture = SwipeLeftGlow;
			glow = SwipeLeftGlow;
			StartCoroutine (waitTime(waitTimer));
			break;
		case "SwipeRight-Normal (UnityEngine.Texture2D)": 
			GetComponent<GUITexture>().texture = SwipeRightGlow;
			glow = SwipeRightGlow;
			StartCoroutine (waitTime(waitTimer));
			break;
		case "Wave-Normal (UnityEngine.Texture2D)": 
			GetComponent<GUITexture>().texture = WaveGlow;
			glow = WaveGlow;
			StartCoroutine (waitTime(waitTimer));
			break;
		}
	}

	void OnThumbUp(){
		if (!isThumbUp) {
			isThumbUp = true;
			//assign the glow texture
			GetComponent<GUITexture>().texture = ThumbsUpGlow;
			glow = ThumbsUpGlow;
			//start the wait timer before switching to next gesture texture
			StartCoroutine (waitTime (waitTimer));
		}
	}

	void OnThumbDown(){
		if (!isThumbDown) {
						isThumbDown = true;
						GetComponent<GUITexture>().texture = ThumbsDownGlow;
						glow = ThumbsDownGlow;
						StartCoroutine (waitTime (waitTimer));
				}
	}

	void OnBig5(){
		if (!isBig5) {
						isBig5 = true;
						GetComponent<GUITexture>().texture = Big5Glow;
						glow = Big5Glow;
						StartCoroutine (waitTime (waitTimer));
				}
	}

	void OnFist(){
		if (!isFist) {
						isFist = true;
						GetComponent<GUITexture>().texture = FistGlow;
						glow = FistGlow;
						StartCoroutine (waitTime (waitTimer));
				}
	}

	void OnSwipeLeft(){
		if (!isSwipeLeft) {
			isSwipeLeft = true;
						GetComponent<GUITexture>().texture = SwipeLeftGlow;
						glow = SwipeLeftGlow;
						StartCoroutine (waitTime (waitTimer));
				}
	}

	void OnSwipeRight(){
		if (!isSwipeRight) {
						isSwipeRight = true;
						GetComponent<GUITexture>().texture = SwipeRightGlow;
						glow = SwipeRightGlow;
						StartCoroutine (waitTime (waitTimer));
				}
	}

	void OnWave(){
		if (!isWave) {
						isWave = true;
						GetComponent<GUITexture>().texture = WaveGlow;
						glow = WaveGlow;
						StartCoroutine (waitTime (waitTimer));
				}
	}

	IEnumerator Fade(float start, float end, float speed){
		print ("FamiliarizeGestureCheck: Inside Fade: start and end "+start+" "+end);
		Color colorT = GetComponent<GUITexture>().color;
		float speedVal = 1.0f / speed;
		for (float i = 0.0f; i < 1.0f; i += Time.deltaTime * speedVal) {
			colorT.a = Mathf.Lerp(start, end, i);
			print ("FamiliarizeGestureCheck: Inside Fade: colorT.a: "+colorT.a);
			GetComponent<GUITexture>().color = colorT;
			yield return null;
		}
	}

	IEnumerator waitTime(float waitTimeValue){
		print ("FamiliarizeGestureCheck: Inside waitTime");
		//yield stops execution and continues next frame from here when it gets return 'null' instead of instance
		yield return new WaitForSeconds (waitTimeValue);
		//since wave is the last texture dont try to load next gesture
		if (glow.ToString () != "Wave-Glow (UnityEngine.Texture2D)") {
						//assign new gesture texture and fade away immedialtely so as to fade in again slowly the same
						//switch checking for old normal 
						switch (normal.ToString ()) {
			case "ThumbsUp-Normal (UnityEngine.Texture2D)": 
								print ("FamiliarizeGestureCheck: Inside waitTime: Inside switch");
								GetComponent<GUITexture>().texture = ThumbsDownNormal;
								normal = ThumbsDownNormal;
								break;
			case "ThumbsDown-Normal (UnityEngine.Texture2D)": 
								GetComponent<GUITexture>().texture = Big5Normal;
								normal = Big5Normal;
								break;
			case "Big5-Normal (UnityEngine.Texture2D)": 
								GetComponent<GUITexture>().texture = FistNormal;
								normal = FistNormal;
								break;
			case "Fist-Normal (UnityEngine.Texture2D)": 
								GetComponent<GUITexture>().texture = SwipeLeftNormal;
								normal = SwipeLeftNormal;
								break;
			case "SwipeLeft-Normal (UnityEngine.Texture2D)": 
								GetComponent<GUITexture>().texture = SwipeRightNormal;
								normal = SwipeRightNormal;
								break;
			case "SwipeRight-Normal (UnityEngine.Texture2D)": 
								GetComponent<GUITexture>().texture = WaveNormal;
								normal = WaveNormal;
								break;
						}
						Color colorT = GetComponent<GUITexture>().color;
						colorT.a = 0.0f;
						GetComponent<GUITexture>().color = colorT;
						print ("FamiliarizeGestureCheck: Inside waitTime: colorT.a: "+colorT.a);
						StartCoroutine (Fade (startVal, endVal, speedVal));
			}
			else{
				Application.LoadLevel ("StorylineScene");
			}
	}

}
