using UnityEngine;
using System.Collections;

public class FormulaBar01 : MonoBehaviour {
	
		public GUIStyle progress_empty;
		public GUIStyle progress_full;
		
		public bool islevelComplete = false;
		//current progress
		private float barDisplay01 = 0f;
		private float barDisplay02 = 0f;
		private float barDisplay03 = 0f;
		private float barDisplay04 = 0f;
		//to count for game level complete - tracks number of plasma hits
		public int redCount = 0;
		public int greenCount = 0;
		public int cyanCount = 0;
		public int violetCount = 0;
		//Health bar bacgrnd and foreground bar textures
		public Texture2D emptyTex01;
		public Texture2D fullTex01;
		public Texture2D emptyTex02;
		public Texture2D fullTex02;
		public Texture2D emptyTex03;
		public Texture2D fullTex03;
		public Texture2D emptyTex04;
		public Texture2D fullTex04;
		//position coordinates to bring the health bars into mid of the screen
		Vector2 pos01 = new Vector2(Screen.width / 2 - 113, 40);
		Vector2 pos02 = new Vector2(Screen.width / 2 - 113, 60);
		Vector2 pos03 = new Vector2(Screen.width / 2 - 113, 80);
		Vector2 pos04 = new Vector2(Screen.width / 2 - 113, 100);
		//size for each health bar
		Vector2 size = new Vector2(225, 50);
		//track gameOver to avoid gameComplete display
		private bool isGameOver = false;
		public delegate void cageBlastEvent01(object sender);
		public event cageBlastEvent01 cageBlastMe01;

		void Start(){
			
			GameObject plasma01 = GameObject.Find("Plasma01");
			GameObject plasma02 = GameObject.Find("Plasma02");
			
			//get the instance of gameObject where PlasmaEmitter01 is attached - i.e. Plasma01
			GameObject plasma_01 = GameObject.Find ("Plasma01");
			//delegate event handling to fill in the health bars of each color
			plasma_01.GetComponent<PlasmaEmitter01>().healthBar01 += delegate(object sender, string color) {
				switch(color){
					//fill in 1 out of 5 units of health bar for onetime plasma hit on cage
				case "Red": barDisplay01 += 0.2f;
					redCount++;
				print ("FormulaBar::Inside Start :: healthBar01 : "+color+" barDisplay01: "+barDisplay01);
					break;
				case "Violet": barDisplay02 += 0.2f;
					print ("FormulaBar::Inside Start :: healthBar01 : "+color+" barDisplay01: "+barDisplay02);
					violetCount++;
					break;
					//Cyan = Blue
				case "Blue": barDisplay03 += 0.2f;
					print ("FormulaBar::Inside Start :: healthBar01 : "+color+" barDisplay01: "+barDisplay02);
					cyanCount++;
					break;
				case "Green": barDisplay04 += 0.2f;
					print ("FormulaBar::Inside Start :: healthBar01 : "+color+" barDisplay01: "+barDisplay02);
					greenCount++;
					break;
				}
				//if no of hits of all colors exceeds 4 than all health bars are complete and so does the game level
				if(redCount > 4 && greenCount > 4 && cyanCount > 4 && violetCount > 4 && !isGameOver){
					islevelComplete = true;
					//blast open cage in plasm01 hit
					cageBlastMe01(this);
					GameObject levelComp = GameObject.Find("GameComplete");
					levelComp.GetComponent<GameLevelTextFade>().displayLevelComplete();
				}
				//If both the staffs have been drained out of plasma, it indicates game over
				if(plasma01.GetComponent<PlasmaEmitter01>().isPlasmaDrained01 == true &&
				   plasma02.GetComponent<PlasmaEmitter02>().isPlasmaDrained02 == true &&
				   islevelComplete != true){
					isGameOver = true;
					GameObject gameover = GameObject.Find("GameOver");
					gameover.GetComponent<GameOver>().displayGameOver();
				}
			};
			
			//get the instance of gameObject where PlasmaEmitter02 is attached - i.e. Plasma02
			GameObject plasma_02 = GameObject.Find ("Plasma02");
			plasma_02.GetComponent<PlasmaEmitter02>().healthBar02 += delegate(object sender, string color) {
				switch(color){
				case "Red": barDisplay01 += 0.2f;
					print ("FormulaBar::Inside Start :: healthBar01 : "+color+" barDisplay01: "+barDisplay01);
					redCount++;
					break;
				case "Violet": barDisplay02 += 0.2f;
					print ("FormulaBar::Inside Start :: healthBar01 : "+color+" barDisplay01: "+barDisplay02);
					violetCount++;
					break;
					//Cyan = Blue
				case "Blue": barDisplay03 += 0.2f;
					print ("FormulaBar::Inside Start :: healthBar01 : "+color+" barDisplay01: "+barDisplay03);
					cyanCount++;
					break;
				case "Green": barDisplay04 += 0.2f;
					print ("FormulaBar::Inside Start :: healthBar01 : "+color+" barDisplay01: "+barDisplay04);
					greenCount++;
					break;
				}

				if(redCount > 4 && greenCount > 4 && cyanCount > 4 && violetCount > 4 && !isGameOver){
					islevelComplete = true;
					//blast open cage in plasm02 hit
					cageBlastMe01(this);
					GameObject levelComp = GameObject.Find("GameComplete");
					levelComp.GetComponent<GameLevelTextFade>().displayLevelComplete();
				}
				
				if(plasma01.GetComponent<PlasmaEmitter01>().isPlasmaDrained01 == true &&
				   plasma02.GetComponent<PlasmaEmitter02>().isPlasmaDrained02 == true &&
				   islevelComplete != true){
					isGameOver = true;
					GameObject gameover = GameObject.Find("GameOver");
					gameover.GetComponent<GameOver>().displayGameOver();
				}
			};
		}
		
		void OnGUI()
		{
			//First plasma health bar
			//draw the background:
			GUI.BeginGroup(new Rect(pos01.x, pos01.y, size.x, size.y), emptyTex01, progress_empty);
			GUI.Box(new Rect(pos01.x, pos01.y, size.x, size.y), fullTex01, progress_full);
			
			//draw the filled-in part:
			GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay01, size.y));
			
			GUI.Box(new Rect(0, 0, size.x, size.y), fullTex01, progress_full);
			
			GUI.EndGroup();
			GUI.EndGroup();
			
			//Second plasma health bar
			//draw the background:
			GUI.BeginGroup(new Rect(pos02.x, pos02.y, size.x, size.y), emptyTex02, progress_empty);
			GUI.Box(new Rect(pos02.x, pos02.y, size.x, size.y), fullTex02, progress_full);
			
			//draw the filled-in part:
			GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay02, size.y));
			
			GUI.Box(new Rect(0, 0, size.x, size.y), fullTex02, progress_full);
			
			GUI.EndGroup();
			GUI.EndGroup();
			
			//Third plasma health bar
			//draw the background:
			GUI.BeginGroup(new Rect(pos03.x, pos03.y, size.x, size.y), emptyTex03, progress_empty);
			GUI.Box(new Rect(pos03.x, pos03.y, size.x, size.y), fullTex03, progress_full);
			
			//draw the filled-in part:
			GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay03, size.y));
			
			GUI.Box(new Rect(0, 0, size.x, size.y), fullTex03, progress_full);
			
			GUI.EndGroup();
			GUI.EndGroup();
			
			////Fourth plasma health bar
			//draw the background:
			GUI.BeginGroup(new Rect(pos04.x, pos04.y, size.x, size.y), emptyTex04, progress_empty);
			GUI.Box(new Rect(pos04.x, pos04.y, size.x, size.y), fullTex04, progress_full);
			
			//draw the filled-in part:
			GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay04, size.y));
			
			GUI.Box(new Rect(0, 0, size.x, size.y), fullTex04, progress_full);
			
			GUI.EndGroup();
			GUI.EndGroup();
         }
}


