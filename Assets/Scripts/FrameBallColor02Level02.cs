using UnityEngine;
using System.Collections;

public class FrameBallColor02Level02 : MonoBehaviour {

	public ParticleSystem ps02;
	private float speedVal02 = 2.0f;
	private Color fromCol02;
	private Color toCol02;
	// Use this for initialization
	void Start () {
		print ("FrameBallColor::Inside Start: before");
		ps02 = GetComponent<ParticleSystem> ();
		
		//get the instance of gameObject where PlasmaEmitter02 is attached - i.e. Plasma02
		GameObject plasma02 = GameObject.Find ("Plasma02");
		plasma02.GetComponent<PlasmaEmitter02Level02> ().changeMe02 += delegate(object sender, string colorPrefab02) {
			print ("FrameBallColor::Inside Start:: Delegate changeMe01");
			fromCol02 = ps02.startColor;
			StartCoroutine (changeEmitterColor02 (colorPrefab02));
		};
		print ("FrameBallColor::Inside Start: after");
	}
	
	IEnumerator changeEmitterColor02(string newColor02){
		print ("FrameBallColor::Inside changeEmitterColor:: before");
		switch(newColor02){
		case "Red" : toCol02 = Color.red;
			break;
		case "Green" : toCol02 = Color.green;
			break;
		case "Blue" : toCol02 = Color.cyan;
			break;
		case "Violet" : toCol02 = new Vector4(0.6f, 0.3f, 0.8f, 1f);
			break;
		}
		for (float i = 0.0f; i < 1.0f; i += Time.deltaTime * speedVal02) {
			print ("FrameBallColor::Inside changeEmitterColor:: Inside lerp loop");
			ps02.startColor = Color.Lerp (fromCol02, toCol02, Time.time/5);
			yield return null;
		}
		print ("FrameBallColor::Inside changeEmitterColor:: after");
	}
}
