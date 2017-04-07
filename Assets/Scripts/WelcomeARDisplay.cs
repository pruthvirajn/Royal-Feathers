using UnityEngine;
using System.Collections;

public class WelcomeARDisplay : MonoBehaviour {
	//RealSense 3D camera initialization
	public string displayCamera = "Intel(R) RealSense(TM) 3D Camera (Front F200) RGB";
	//To keep notice of RealSense Camera connection status
	public bool isCameraConn = false;
	//AR background using guitexture
	public GUITexture ARBackgroundTexture;
	//RealSenseCamera check text
	public GUIText guitext01;
	//video rendering orientation parameters - initilizing to defaults for normal display
	public bool flipVertical;
	public bool flipHorizontal;
	private int flipx = -1;
	private int flipy = 1;
	float waitTime = 8.0f;
	// Use this for initialization
	void Start () {
		guitext01.text = "";
		WebCamTexture camtexture = new WebCamTexture ();
		//Get the list of devices available
		WebCamDevice[] devices = WebCamTexture.devices;
		//Check for RealSense Camera availability
		if (string.Compare (devices [0].name, "Intel(R) RealSense(TM) 3D Camera (Front F200) RGB") != 0) {
			Debug.Log ("Camera not connected #################################");
				StartCoroutine (guiTextDisplay (waitTime));
		} else {
			Debug.Log ("#################################");
				isCameraConn = true;
		}
		//conside the input orientation parameters - activate if necessary
		//flipx = flipHorizontal ? -1 : 1;
		//flipy = flipVertical ? -1 : 1;
		//flip logic of guitexture
		ARBackgroundTexture.transform.localScale = new Vector3 (flipx, flipy, 1);
		//If devices found
		if (devices.Length > 0) {
			print ("ARDisplay:: Inside Start:: device name: "+devices[0].name);
			//assign the first available device to camera texture - can include hard code camera name
			camtexture.deviceName = devices[0].name;
		}
		ARBackgroundTexture.texture = camtexture;
		ARBackgroundTexture.GetComponent<GUITexture>().enabled = true;
		camtexture.Play();
		//Use scene gameobject name and particular script class name
		//when 'About' chosen stop AR
		GameObject ardisplay01 = GameObject.Find ("MenuAbout");
		ardisplay01.GetComponent<MainMenuAboutChangeTex>().changeAR01+= delegate(object sender, string state) {
			switch(state){
			case "Start": camtexture.Play();
				break;
			case "Stop": camtexture.Stop();
				break;
			}
		};
		//when chosen 'Play' stop AR
		GameObject ardisplay02 = GameObject.Find ("MenuPlay");
		ardisplay02.GetComponent<MainMenuPlayChangeTex>().changeAR02+= delegate(object sender, string state) {
			switch(state){
			case "Start": camtexture.Play();
				break;
			case "Stop": camtexture.Stop();
				break;
			}
		};
		//when dialog fades in, call AR display
		GameObject ardisplay03 = GameObject.Find ("MainMenu");
		ardisplay03.GetComponent<MainMenuWait>().changeAR03+= delegate(object sender, string state) {
			switch(state){
			case "Start": camtexture.Play();
				break;
			case "Stop": camtexture.Stop();
				break;
			}
		};
		//when chosen 'quit', stop ar display and quit the application
		GameObject ardisplay04 = GameObject.Find ("MenuQuit");
		ardisplay04.GetComponent<MainMenuQuitChangeTex>().changeAR04+= delegate(object sender, string state) {
			switch(state){
			case "Start": camtexture.Play();
				break;
			case "Stop": camtexture.Stop();
				break;
			}
		};
	}

	IEnumerator guiTextDisplay(float waitTime){
		Debug.Log ("Camera not connected #################################");
		guitext01.text = "Intel(R) RealSense(TM) 3D Camera (Front F200) RGB is missing! Kindly check the connectivity and retry. Game is quitting...";
		yield return new WaitForSeconds (waitTime);
		//Application.Quit ();
	}
	// Update is called once per frame
	void Update () {
	
	}
	
}
