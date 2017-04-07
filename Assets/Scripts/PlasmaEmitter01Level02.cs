using UnityEngine;
using System.Collections;

public class PlasmaEmitter01Level02 : MonoBehaviour {

	public float speed = 1.8f;
	//Initial wait time before plasma fire starts
	public float initialWaitTime = 3.0f;
	//Include four plasma color prefabs 
	public GameObject PlasmaRed;
	public GameObject PlasmaGreen;
	public GameObject PlasmaBlue;
	public GameObject PlasmaViolet;
	//Include four core blast prefabs 
	public GameObject CoreRed;
	public GameObject CoreGreen;
	public GameObject CoreCyan;
	public GameObject CoreViolet;
	private GameObject theNextOne;
	//to keep track of if any coroutine is running
	private bool coroutineRunnning = false;
	//to keep instance of prefabs
	private GameObject clone;
	private int plasmaCount01 = -1;
	private int storeCageState01 = 0;
	//sequence of prefabs strings
	private string[] nextPlasma = { "Red","Green","Violet","Red","Green",
									"Red","Blue","Violet","Green","Green",
									"Red","Green","Blue","Red","Violet",
									"Violet","Red","Violet","Blue","Green"};
	//total plasma count from above array
	private int totalPlasmaCount01 = 20;
	//sequence of time intervals between each plasma fire
	private float[] nextWaitTime = {1f, 2f, 1f, 3f, 1f,
		1f, 2f, 3f, 2f, 1f,
		1f, 2f, 3f, 2f, 1f,
		1f, 2f, 1f, 2f, 1f};
	
	public bool isPlasmaDrained01 = false;
	//for staff color change event
	public delegate void changeMeColorEventHandler01(object sender, string colorPrefab01);
	public event changeMeColorEventHandler01 changeMe01;
	
	//for health bar update event for four plasmas
	public delegate void updatePlasmaHealthBar01(object sender, string color);
	public event updatePlasmaHealthBar01 healthBar01;
	
	//make the plasma shoot audio file ready
	public AudioSource plasmaSFXSource01;
	//make the cage plasma clash audio file ready
	public AudioSource cageSFXSource01;
	// Use this for initialization
	void Start () {
		print ("LightBall::Inside start before");
		//reinitialize the plasma for restart enable from beginning
		plasmaCount01 = -1;
		if(!coroutineRunnning){
			StartCoroutine (waitInterval (initialWaitTime));
		}
		print ("LightBall::Inside start after");
	}
	
	IEnumerator waitInterval(float waitTime){
		print ("LightBall::Inside watInterval: before ");
		coroutineRunnning = true;
		yield return new WaitForSeconds (waitTime);
		coroutineRunnning = false;
		if (!coroutineRunnning) {
			//move the plasma ball towards the cage
			StartCoroutine (moveIt ());
		}
		print ("LightBall::Inside waitInterval: after");
	}
	
	IEnumerator moveIt(){
		coroutineRunnning = true;
		float speedVal = 1.0f / speed;
		//Box023 is the middle of the cage by dummy window piece obj model
		GameObject cage = GameObject.Find ("Box023");
		//core blast target obj model of cage - based on color gem
		GameObject redGem = GameObject.Find ("Group012");
		GameObject greenGem = GameObject.Find ("Group004");
		GameObject cyanGem = GameObject.Find ("Group018");
		GameObject violetGem = GameObject.Find ("Group005");
		//create plasma sequence
		print ("LightBall::Inside moveIt ::nextPlasma [plasmaCount01 + 1] "+nextPlasma [plasmaCount01 + 1]);
		//get the next plasma ball based on 0-15 count of plasmaCount01
		switch (nextPlasma [plasmaCount01 + 1]) {
		case "Red": theNextOne = PlasmaRed;
			//call the delegate in FrameBallColor to change staff color
			changeMe01(this, "Red");
			break;
		case "Blue": theNextOne = PlasmaBlue;
			changeMe01(this, "Blue");
			break;
		case "Green": theNextOne = PlasmaGreen;
			changeMe01(this, "Green");
			break;
		case "Violet": theNextOne = PlasmaViolet;
			changeMe01(this, "Violet");
			break;
		}
		print ("LightBall::Inside moveIt before loop");
		yield return new WaitForSeconds (1.5f);
		//create plasma ball instance: new one theNextOne
		clone = Instantiate (theNextOne, transform.position, transform.rotation) as GameObject;
		//play the plasma shoot audio
		plasmaSFXSource01.PlayOneShot (plasmaSFXSource01.clip, 1.0f);
		//wait few seconds when prefab instance is created at staff
		yield return new WaitForSeconds (0.5f);
		//lerp the fade in loop controlled by speed value
		for (float i = 0.0f; i < 2.5f; i += Time.deltaTime * speedVal) {
			clone.transform.position = Vector3.MoveTowards (clone.transform.position, cage.transform.position, speed * Time.deltaTime);
			print ("LightBall::Inside movIt :: inside loop: i : "+i);
			print ("LightBall::Inside nextPlasmaShoot 01 :: inside loop: plasmaCount01 : "+plasmaCount01);
			//return yield null
			yield return null;
		}
		//destroy the plasma ball first
		Destroy (clone);
		//to access behaviour variable, get the gameobj of that behaviour association
		GameObject cage01 = GameObject.Find ("Cage");
		//store in local variable, the cage state
		storeCageState01 = cage01.GetComponent<CageRotate02> ().cageState;
		print ("LightBall::Inside movIt :: storeCageState01 : "+storeCageState01);
		switch (nextPlasma [plasmaCount01 + 1]) {
			//refer cageRotate script for cage state identification 
		case "Red": 
			if(storeCageState01 == 2 || storeCageState01 == -2){
				clone = Instantiate (CoreRed, redGem.transform.position, transform.rotation) as GameObject;
				cageSFXSource01.PlayOneShot(cageSFXSource01.clip, 1.0f);
				healthBar01(this, "Red");
				//wait for sometime for blast to expire
				yield return new WaitForSeconds (0.5f);
				//destroy once the prefab instance of core blast now
				Destroy (clone);
			}
			break;
		case "Blue": 
			//Blue = Cyan
			if(storeCageState01 == 3 || storeCageState01 == -1){
				clone = Instantiate (CoreCyan, cyanGem.transform.position, transform.rotation) as GameObject;
				cageSFXSource01.PlayOneShot(cageSFXSource01.clip, 1.0f);
				healthBar01(this, "Blue");
				yield return new WaitForSeconds (0.5f);
				Destroy (clone);
			}
			break;
		case "Green": 
			if(storeCageState01 == -3 || storeCageState01 == 1){
				clone = Instantiate (CoreGreen, greenGem.transform.position, transform.rotation) as GameObject;
				cageSFXSource01.PlayOneShot(cageSFXSource01.clip, 1.0f);
				healthBar01(this, "Green");
				yield return new WaitForSeconds (0.5f);
				Destroy (clone);
			}
			break;
		case "Violet": 
			if(storeCageState01 == 0){
				clone = Instantiate (CoreViolet, violetGem.transform.position, transform.rotation) as GameObject;
				cageSFXSource01.PlayOneShot(cageSFXSource01.clip, 1.0f);
				healthBar01(this, "Violet");
				yield return new WaitForSeconds (0.5f);
				Destroy (clone);
			}
			break;
		}
		
		coroutineRunnning = false;
		GameObject level = GameObject.Find ("CageHealthBars");
		if(plasmaCount01 >= 18){
			isPlasmaDrained01 = true;
			GameObject gameover = GameObject.Find("GameOver");
			gameover.GetComponent<GameOver>().displayGameOver();
		}
		if (!coroutineRunnning) {
			if (plasmaCount01 < totalPlasmaCount01 && level.GetComponent<FormulaBar02>().islevelComplete == false) {
				print ("LightBall::Inside nextPlasmaShoot :: inside loop: plasmaCount01 : "+plasmaCount01);
				plasmaCount01++;
				//start the time interval between prefab fires
				StartCoroutine(waitInterval(nextWaitTime[plasmaCount01]));
			}
			
		}
	}
}
