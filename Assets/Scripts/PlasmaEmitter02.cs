using UnityEngine;
using System.Collections;

public class PlasmaEmitter02 : MonoBehaviour {
	public float speed = 1.8f;
	public float initialWaitTime = 5f;
	public GameObject PlasmaRed;
	public GameObject PlasmaGreen;
	public GameObject PlasmaBlue;
	public GameObject PlasmaViolet;
	public GameObject CoreRed;
	public GameObject CoreGreen;
	public GameObject CoreCyan;
	public GameObject CoreViolet;
	private GameObject theNextOne;
	
	private bool coroutineRunnning = false;
	private GameObject clone;
	private int plasmaCount02 = -1;
	private int storeCageState02 = 0;
	//Number of plasma balls to shoot from staff
	private string[] nextPlasma = { "Green","Red","Blue","Violet","Blue",
		"Green","Blue","Red","Violet","Blue",
		"Green","Blue","Red","Violet","Blue",
		"Violet","Red","Blue","Violet","Green"};
	//total plasma count from above array
	private int totalPlasmaCount02 = 20;
	//interval between each plasma shot from staff
	private float[] nextWaitTime = {1f, 3f, 1f, 2f, 1f,
		1f, 2f, 1f, 3f, 1f,
		1f, 2f, 1f, 3f, 1f,
		1f, 3f, 1f, 2f, 1f};

	public delegate void changeMeColorEventHandler02(object sender, string colorPrefab02);
	public event changeMeColorEventHandler02 changeMe02;

	//for health bar update event for four plasmas
	public delegate void updatePlasmaHealthBar02(object sender, string color);
	public event updatePlasmaHealthBar02 healthBar02;

	public bool isPlasmaDrained02 = false;

	//make the plasma shoot audio file ready
	public AudioSource plasmaSFXSource02;
	//make the cage plasma clash audio file ready
	public AudioSource cageSFXSource02;
	//Pause the plasma emitter when pasue gesture is detected
	static bool PausePlasma02 = false;
	// Use this for initialization
	void Start () {
		print ("LightBall::Inside start before");
		//reinitialize the plasma for restart enable from beginning
		plasmaCount02 = -1;
		if(!coroutineRunnning){
			StartCoroutine (waitInterval (initialWaitTime));
		}
		print ("LightBall::Inside start after");

//		//determine pause game status
//		GameObject pauseLevel02 = GameObject.Find ("PauseMenu");
//		pauseLevel02.GetComponent<PauseMenu>().pausePlamaEm01+= delegate(object sender, bool isPause) {
//			//toggle the pause action
//			if(isPause){
//				PausePlasma02 = true;
//			}
//			else{
//				PausePlasma02 = false;
//			}
//		};
	}
	
	IEnumerator waitInterval(float waitTime){
		print ("LightBall::Inside watInterval: before ");
		coroutineRunnning = true;
		yield return new WaitForSeconds (waitTime);
		coroutineRunnning = false;
		if (!coroutineRunnning) {
			StartCoroutine (moveIt ());
		}
		print ("LightBall::Inside waitInterval: after");
	}

	IEnumerator moveIt(){
		coroutineRunnning = true;
		float speedVal = 1.0f / speed;
		GameObject cage = GameObject.Find ("Box023");
		//core blast target obj model of cage - based on color gem
		GameObject redGem = GameObject.Find ("Group012");
		GameObject greenGem = GameObject.Find ("Group004");
		GameObject cyanGem = GameObject.Find ("Group018");
		GameObject violetGem = GameObject.Find ("Group005");
		//create plasma sequence
		print ("LightBall::Inside moveIt ::nextPlasma [plasmaCount02 + 1] "+nextPlasma [plasmaCount02 + 1]);
		switch (nextPlasma [plasmaCount02 + 1]) {
		case "Red": theNextOne = PlasmaRed;
			changeMe02(this, "Red");
			break;
		case "Blue": theNextOne = PlasmaBlue;
			changeMe02(this, "Blue");
			break;
		case "Green": theNextOne = PlasmaGreen;
			changeMe02(this, "Green");
			break;
		case "Violet": theNextOne = PlasmaViolet;
			changeMe02(this, "Violet");
			break;
		}
		print ("LightBall::Inside moveIt before loop");
		yield return new WaitForSeconds (1.5f);

		clone = Instantiate (theNextOne, transform.position, transform.rotation) as GameObject;
		plasmaSFXSource02.PlayOneShot (plasmaSFXSource02.clip, 1.0f);
		yield return new WaitForSeconds (0.5f);
		//lerp the fade in loop controlled by speed value
		for (float i = 0.0f; i < 2.5f; i += Time.deltaTime * speedVal) {
			clone.transform.position = Vector3.MoveTowards (clone.transform.position, cage.transform.position, speed * Time.deltaTime);
			print ("LightBall::Inside movIt :: inside loop: i : "+i);
			//return yield null
			yield return null;
		}
		//destroy the plasma ball first
		Destroy (clone);
		GameObject cage02 = GameObject.Find ("Cage");
		storeCageState02 = cage02.GetComponent<CageRotate01> ().cageState;
		switch (nextPlasma [plasmaCount02 + 1]) {
			//refer cageRotate script for cage state identification 
		case "Red": 
			if(storeCageState02 == 1 || storeCageState02 == -3){
				clone = Instantiate (CoreRed, redGem.transform.position, transform.rotation) as GameObject;
				cageSFXSource02.PlayOneShot(cageSFXSource02.clip, 1.0f);
				healthBar02(this, "Red");
				//wait for sometime for blast to expire
				yield return new WaitForSeconds (0.5f);
				//destroy once the prefab instance of core blast now
				Destroy (clone);
			}
			break;
		case "Blue": 
			//Blue = Cyan
			if(storeCageState02 == 2 || storeCageState02 == -2){
				clone = Instantiate (CoreCyan, cyanGem.transform.position, transform.rotation) as GameObject;
				cageSFXSource02.PlayOneShot(cageSFXSource02.clip, 1.0f);
				healthBar02(this, "Blue");
				yield return new WaitForSeconds (0.5f);
				Destroy (clone);
			}
			break;
		case "Green": 
			if(storeCageState02 == 0){
				clone = Instantiate (CoreGreen, greenGem.transform.position, transform.rotation) as GameObject;
				cageSFXSource02.PlayOneShot(cageSFXSource02.clip, 1.0f);
				healthBar02(this, "Green");
				yield return new WaitForSeconds (0.5f);
				Destroy (clone);
			}
			break;
		case "Violet": 
			if(storeCageState02 == -1 || storeCageState02 == 3){
				clone = Instantiate (CoreViolet, violetGem.transform.position, transform.rotation) as GameObject;
				cageSFXSource02.PlayOneShot(cageSFXSource02.clip, 1.0f);
				healthBar02(this, "Violet");
				yield return new WaitForSeconds (0.5f);
				Destroy (clone);
			}
			break;
		}
		
		coroutineRunnning = false;
		GameObject level = GameObject.Find ("CageHealthBars");
		print ("LightBall::Inside nextPlasmaShoot 02:: inside loop: plasmaCount02 : "+plasmaCount02);
		if(plasmaCount02 >= 18){
			isPlasmaDrained02 = true;
			GameObject gameover = GameObject.Find("GameOver");
			gameover.GetComponent<GameOver>().displayGameOver();
		}
		if (!coroutineRunnning) {
			if (plasmaCount02 < totalPlasmaCount02 && level.GetComponent<FormulaBar01>().islevelComplete == false) {
				print ("LightBall::Inside nextPlasmaShoot :: inside loop: plasmaCount02 : "+plasmaCount02);
				plasmaCount02++;
				StartCoroutine(waitInterval(nextWaitTime[plasmaCount02]));
			}

		}

	}
}
