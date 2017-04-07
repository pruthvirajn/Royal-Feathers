using UnityEngine;
using System.Collections;

public class StorylineARSystem : MonoBehaviour {
	//Put this script in place of ARDisplay in ARSystem for storyline scene
	//RealSense 3D camera initialization
	public string displayCamera = "Intel(R) RealSense(TM) 3D Camera (Front F200) RGB";
	//AR background using guitexture
	public GUITexture ARBackgroundTexture;
	//video rendering orientation parameters - initilizing to defaults for normal display
	public bool flipVertical;
	public bool flipHorizontal;
	private int flipx = -1;
	private int flipy = 1;
	
	// Use this for initialization
	void Start () {
		WebCamTexture camtexture = new WebCamTexture ();
		//Get the list of devices available
		WebCamDevice[] devices = WebCamTexture.devices;
		//conside the input orientation parameters - activate if necessary
		//flipx = flipHorizontal ? -1 : 1;
		//flipy = flipVertical ? -1 : 1;
		//flip logic of guitexture
		ARBackgroundTexture.transform.localScale = new Vector3 (flipx, flipy, 1);
		//If devices found
		if (devices.Length > 0) {
			print ("StorylineARSystem:: Inside Start:: device name: "+devices[0].name);
			//assign the first available device to camera texture - can include hard code camera name
			camtexture.deviceName = devices[0].name;
		}
		ARBackgroundTexture.texture = camtexture;
		ARBackgroundTexture.GetComponent<GUITexture>().enabled = true;
		camtexture.Play();
		//when hand wave to skip the story
		GameObject ardisplaystoryline = GameObject.Find ("StorylineDialog");
		ardisplaystoryline.GetComponent<StorylineDialog>().changeARstoryline+= delegate(object sender, string state) {
		switch(state){
		case "Start": camtexture.Play();
			break;
		case "Stop": camtexture.Stop();
			break;
		}
		};
	}
}
