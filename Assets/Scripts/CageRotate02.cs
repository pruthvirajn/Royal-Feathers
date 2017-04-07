using UnityEngine;
using System.Collections;

public class CageRotate02 : MonoBehaviour {

	//Cube rotation factor
	public float rotationSpeed = 10.5f;
	private static float angleToRotate;
	private static float angleBtw;
	//to keep track of cage rotation state for core blast effect - main game philosophy
	//0 ->  Violet|Green
	//1 -> Green|Red
	//2 -> Red|Cyan
	//3 -> Cyan|Violet
	//-1  -> Cyan|Violet
	//-2  -> Red|Cyan
	//-3  -> Green|Red
	public int cageState = 0;
	//origin - initial cube orientation
	private Quaternion origin;
	//to - target cube orientation
	private Quaternion to;
	//Include the cage blast prefab
	public GameObject cageBlastPrefab01;
	//Define the bird rotation
	private Quaternion birdRotation;
	//Bring in the bird baby 02
	public GameObject bird02;
	// Use this for initialization
	void Start () {
		//just initialize
		to = transform.rotation;
		angleToRotate = 0;
		//set bird rotation - facing the camera
		birdRotation = Quaternion.Euler (new Vector3 (0f, -90f, -30f));
		//store initial box transform - orientation
		origin = transform.rotation;
		//For cage blast prefab
		GameObject cageBlastClone02;
		//For Bird origin
		GameObject birdClone02;
		//When left hand is hover on the left rotate control, below event is raised
		GameObject leftBar = GameObject.Find("LeftBar");
		leftBar.GetComponent<GameLeftChangeTex>().changeARleft+= delegate(object sender) {
			//update the cage state variable
			cageState+= 1;
			if(cageState > 3){
				cageState= 0;
			}
			//update to rotate angel
			angleToRotate += 90f;
			print ("CageRotate::Inside changeARleft: after:: cageState: "+cageState);
		};

		//When right hand is hover on the left rotate control, below event is raised
		GameObject rightBar = GameObject.Find("RightBar");
		rightBar.GetComponent<GameRightChangeTex>().changeARright+= delegate(object sender) {
			//update the cage state variable
			cageState-= 1;
			if(cageState < -3){
				cageState= 0;
			}
			//update to rotate angel
			angleToRotate -= 90f;
			print ("CageRotate::Inside changeARright: after:: cageState: "+cageState);
		};
		
		//Level02 complete activities
		//Clone the blast baby!!
		GameObject blast02 = GameObject.Find ("CageHealthBars");
		blast02.GetComponent<FormulaBar02>().cageBlastMe02+= delegate(object sender) {
			print ("CageRotate::Inside blast02::Clone the blast baby!! ");
			//Blast the baby clone
			cageBlastClone02 = Instantiate(cageBlastPrefab01, transform.position, birdRotation) as GameObject;
			//Include the bird rotation facing to camera instead of cage
			birdClone02 = Instantiate(bird02, transform.position, birdRotation) as GameObject;
			//destroy the cage
			GameObject cage02 = GameObject.Find ("Cage");
			cage02.GetComponent<CageFadeInOut>().CageFadeOut();
		};
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			//update the cage state variable
			cageState+= 1;
			if(cageState > 3){
				cageState= 0;
			}
			//update to rotate angel
			angleToRotate += 90f;
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			//update the cage state variable
			cageState-= 1;
			if(cageState < -3){
				cageState= 0;
			}
			//update to rotate angel
			angleToRotate -= 90f;
		}
		print ("CageRotate::Inside Update: after:: cageState: "+cageState);
	}
	
	void FixedUpdate(){
		//include the target angle to rotate around y-axis
		to = Quaternion.AngleAxis (angleToRotate, Vector3.up);
		//preserve x - rotation to initial
		to.x = origin.x;
		//display the angleBtw
		angleBtw = Quaternion.Angle (to, transform.rotation);
		print ("CageRotate::Inside FixedUpdate: after:: angleBtw: "+angleBtw);
		//Do the slerp
		transform.rotation = Quaternion.Slerp(transform.rotation, to, Time.deltaTime * rotationSpeed);
	}

	void LeftCommanded(){
		//update the cage state variable
		cageState+= 1;
		if(cageState > 3){
			cageState= 0;
		}
		//update to rotate angel
		angleToRotate += 90f;
	}
	
	void RightCommanded(){
		//update the cage state variable
		cageState-= 1;
		if(cageState < -3){
			cageState= 0;
		}
		//update to rotate angel
		angleToRotate -= 90f;
	}
	
}

