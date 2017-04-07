using UnityEngine;
using System.Collections;

public class CageRotate01 : MonoBehaviour {

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
	//Bring in the bird baby 01
	public GameObject bird01;
	//Define the bird rotation
	private Quaternion birdRotation;
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
		GameObject cageBlastClone01;
		//For Bird origin
		GameObject birdClone01;

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
		
		//Level01 Complete activities
		//Clone the blast baby!!
		GameObject blast01 = GameObject.Find ("CageHealthBars");
		blast01.GetComponent<FormulaBar01>().cageBlastMe01+= delegate(object sender) {
			print ("CageRotate::Inside blast01::Clone the blast baby!! ");
			//Blast the baby clone
			cageBlastClone01 = Instantiate(cageBlastPrefab01, transform.position, birdRotation) as GameObject;
			//Include the bird rotation facing to camera instead of cage
			birdClone01 = Instantiate(bird01, transform.position, birdRotation) as GameObject;
			//destroy the cage
			GameObject cage01 = GameObject.Find ("Cage");
			cage01.GetComponent<CageFadeInOut>().CageFadeOut();
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

