using UnityEngine;
using System.Collections;

public class AudioStartStop : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Audio start pause event delegated from AudioMenuChange
		GameObject audio01 = GameObject.Find("AudioItem");
		audio01.GetComponent<AudioMenuChangeTex>().audioItem01+= delegate(Object sender) {
			if(GetComponent<AudioSource>().isPlaying){
				GetComponent<AudioSource>().Pause();
			}
			else{
				GetComponent<AudioSource>().Play();
			}
		};
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
