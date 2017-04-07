using UnityEngine;
using System.Collections;

public class FrameBallColor01Level02 : MonoBehaviour {

	public ParticleSystem ps01;
	private float speedVal01 = 2.0f;
	private Color fromCol01;
	private Color toCol01;
	// Use this for initialization
	void Start () {
		print ("FrameBallColor::Inside Start: before");
		ps01 = GetComponent<ParticleSystem> ();
		
		//get the instance of gameObject where PlasmaEmitter01 is attached - i.e. Plasma01
		GameObject plasma01 = GameObject.Find ("Plasma01");
		plasma01.GetComponent<PlasmaEmitter01Level02> ().changeMe01 += delegate(object sender, string colorPrefab01) {
			print ("FrameBallColor::Inside Start:: Delegate changeMe01");
			fromCol01 = ps01.startColor;
			StartCoroutine (changeEmitterColor01 (colorPrefab01));
		};
		print ("FrameBallColor::Inside Start: after");
	}
	//change the staff frameball color respect to next plasma ball
	IEnumerator changeEmitterColor01(string newColor01){
		print ("FrameBallColor::Inside changeEmitterColor:: before");
		switch(newColor01){
		case "Red" : toCol01 = Color.red;
			break;
		case "Green" : toCol01 = Color.green;
			break;
		case "Blue" : toCol01 = Color.cyan;
			break;
		case "Violet" : toCol01 = new Vector4(0.6f, 0.3f, 0.8f, 1f);
			break;
		}
		for (float i = 0.0f; i < 1.0f; i += Time.deltaTime * speedVal01) {
			print ("FrameBallColor::Inside changeEmitterColor:: Inside lerp loop");
			ps01.startColor = Color.Lerp (fromCol01, toCol01, Time.time/5);
			yield return null;
		}
		print ("FrameBallColor::Inside changeEmitterColor:: after");
	}
}
