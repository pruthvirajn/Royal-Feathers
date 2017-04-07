using UnityEngine;
using System.Collections;

public class CameraCheck : MonoBehaviour {
	//RealSense 3D camera initialization
	public string displayCamera = "Intel(R) RealSense(TM) 3D Camera (Front F200) RGB";
	//To keep notice of RealSense Camera connection status
	public bool isCameraConn = false;
	//RealSenseCamera check text
	public GUIText guitext01;
	// Use this for initialization
	float waitTime = 1.0f;
	void Start () {
		guitext01.text = "";
		WebCamTexture camtexture = new WebCamTexture ();
		//Get the list of devices available
		WebCamDevice[] devices = WebCamTexture.devices;
		//Check for RealSense Camera availability
		if (string.Compare (devices [0].name, "Intel(R) RealSense(TM) 3D Camera (Front F200) RGB") != 0) {
			StartCoroutine (guiTextDisplay (waitTime));
		} else {
			isCameraConn = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator guiTextDisplay(float waitTime){
		Debug.Log ("Camera not connected #################################");
		guitext01.text = "Intel(R) RealSense(TM) 3D Camera (Front F200) RGB is missing! Kindly check the connectivity and retry. Game is quitting...";
		yield return new WaitForSeconds (waitTime);
		//Application.Quit ();
	}
}
