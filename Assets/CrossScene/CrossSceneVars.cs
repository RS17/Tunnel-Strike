using UnityEngine;
using System.Collections;

public class CrossSceneVars : MonoBehaviour {
	
	public static int Money = 0;
	public static int Rocket = 1;
	public static int Rocket1 = 1;
	public static int Rocket2 = 0;
	public static int Rocket3 = 0;
	public static int Vectoredthrust = 0;
	public static int Vectoredthrustactive = 0;
	public static int Guns = 1;
	public static int Guns1 = 1;
	public static int Guns2 = 0;
	public static int Guns3 = 0;
	public static int Armor1 = 1;
	public static int Armor2 = 0;
	public static int Armor3 = 0;
	public static int Armor = 1;
	public static float Armorlevel = 500; //should equal steelarmor
	public static int Gameover = 0;
	public static float deathtime = 0;
	public static int Coreexist = 0; // 0 = no core, 1 = core exists, 2 = core destroyed
	public static float Coretime = 0;
	public static int Finaldist = 0;
	public static int missilecount = 0;
	public static int Paused = 0;
	public static int Winnerisyou = 0;
	public static int Missiletracker = 0;
	public static int CoinMagnet = 0;
	public GameObject spaceship;
	public static int Champmode = 0;
	public static int Highscore = 0;
	public static int Undoer = 0;
	public static int Undoeractive = 0;
	public static int Ismissile = 0;
	public static int Developmode = 0;
	public static int ShowcoreGUI = 0;
	public static string message = "no message";
	public int Showendmessage = 0;
	public int Okclicked = 0;
	public int framerate = 60;
	public static int bonus = 0;
	public static int lastdist = 0;
	public int finaldistmoney = 0;
	public static int Upgrademode = 0;
	
	void Awake() {
	
		DontDestroyOnLoad(transform.gameObject);
		Application.targetFrameRate = 60;

	}
	// add anything that needs to be reset after death to upgradegui
	void OnLevelWasLoaded(int level){
		if (level == 0){ //sets defaults at title screen
			Money = 0;
			Rocket = 1;
			Rocket1 = 1;
			Rocket2 = 0;
			Rocket3 = 0;
			Vectoredthrust = 0;
			Vectoredthrustactive = 0;
			Guns = 1;
			Guns1 = 1;
			Guns2 = 0;
			Guns3 = 0;
			Armor1 = 1;
			Armor2 = 0;
			Armor3 = 0;
			Armor = 1;
			Armorlevel = 500; //should equal steelarmor
			Gameover = 0;
			deathtime = 0;
			Coreexist = 0;
			Coretime = 0;
			Finaldist = 0;
			missilecount = 0;
			Paused = 0;
			Winnerisyou = 0;
			Destroy(gameObject);
			Missiletracker = 0;
			CoinMagnet = 0;
			Champmode = 0;
			Undoer = 0;
			Undoeractive = 0;
			Ismissile = 0;
			ShowcoreGUI = 0;
			message = "no message";
			Showendmessage = 0;
			Okclicked = 0;
			framerate = 60;
			Upgrademode = 0;
		}
		if (level == 2){
			Upgrademode = 1;
		}
		if (level == 3){
			Champmode = 0;
			Coreexist = 1;
			Upgrademode = 0;
		}
		if (level == 4){
			Debug.Log("In Champ Mode");
			Armorlevel = 10000;
			Missiletracker = 1;
			Coreexist = 2;
			Champmode = 1;
			Upgrademode = 0;
		}
			
	}

	// Use this for initialization
	
	void Start () {
		spaceship = GameObject.Find("spaceshipmod");
	
	}
	
	void OnGUI (){
	//	if (Gameover == 1 && Champmode == 0){
		//	GUI.Label(new Rect(100,100,180,20), System.String.Format("Distance: {0}", Finaldist));
		//	GUI.Label(new Rect(100,130,180,20), System.String.Format("Money: {0}", Money));
			//GUI.Label(new Rect(100,150,180,20), System.String.Format(message));
	//	}
		if (Gameover == 1 && Champmode == 1){
			GUI.TextArea(new Rect(200, 100, 200, 100), System.String.Format("Final Distance: {0}", Finaldist));
			if (Ismissile == 0){
				if (Finaldist > Optionsandstatus.Shiphighscore){
					PlayerPrefs.SetInt("Shiphighscore", Finaldist);
					Optionsandstatus.Shiphighscore = Finaldist;
					GUI.TextArea(new Rect(200, 130, 200, 100), "You set a a new distance record!");
				}
			}
			if (Ismissile == 1){
				if (Finaldist > Optionsandstatus.Missilehighscore){
					PlayerPrefs.SetInt("Missilehighscore", Finaldist);
					Optionsandstatus.Missilehighscore = Finaldist;
					GUI.TextArea(new Rect(200, 130, 200, 100), "You set a a new distance record!");
				}
			}
			if (GUI.Button(new Rect(250, 310, 140, 30), "Go to title screen")){
				
				if (Ismissile == 1){
					Application.ExternalCall("kongregate.stats.submit","Missilehighscore",Finaldist);
				}
				if (Ismissile == 0){
					Application.ExternalCall("kongregate.stats.submit","Shiphighscore",Finaldist);
				}
				Application.LoadLevel(0);
			}	
		}
		if (Developmode == 1){
			GUI.Label(new Rect(300, 20, 200, 25), "Developer Mode");
		}
		if (ShowcoreGUI ==1){
			GUI.TextArea(new Rect(200, 100, 400, 200), "Congratulations, you have destroyed the core! As a token of gratitude for saving the universe, Champion's Mode (accessible at title screen) has been unlocked!  This development fills your heart with joyous emotions.  However, all is not finished - now you must escape the tunnel, which will be exploding behind you.  If you can do this, you will unlock a special bonus for Champions Mode!");
			if (GUI.Button(new Rect(200, 350, 140, 30), "Continue")){
				ShowcoreGUI = 0;
				Paused = 0;
				Time.timeScale = Pausecontroller.RegTimescale;
				Pausecontroller.showGUI = 1;
			}
		}
		if (Gameover == 2){
			GUI.TextArea(new Rect(200, 100, 200, 200), System.String.Format("Total distance: {0}", lastdist));
			GUI.Label(new Rect(202,130, 140, 30), System.String.Format("Distance bonus: ${0}", finaldistmoney));
			GUI.Label(new Rect(202, 160, 400, 30), System.String.Format("Endurance bonus: ${0}", bonus));
			GUI.Label(new Rect(202, 190, 400, 30), System.String.Format("Total bonus earned: ${0}", finaldistmoney+bonus));
			GUI.Label(new Rect(202, 220, 400, 30), System.String.Format("New balance: ${0}", Money));
			if (GUI.Button(new Rect(200, 350, 140, 30), "Go to upgrade screen")){
				Gameover = 3;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		//if normal mode
		if (Gameover == 1 && Champmode == 0){
				finaldistmoney = Finaldist/40;
				Money = Money+bonus+finaldistmoney;
				Gameover =2;
		}
		if (Gameover == 3 && Champmode == 0){
			Application.LoadLevel(2);
			Destroy(spaceship);
			Gameover = 0;
		}
		// if champ mode:
		if (Gameover == 1 && Champmode == 1){
			Highscore = (int) Finaldist;//will probably make highscore go on an options and stats script later 
			Destroy(spaceship);
			
			if (Okclicked == 1){
				Gameover = 0;
				Application.LoadLevel(0);
			}
		}
		if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.B) && Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.KeypadEnter)){
			Developmode = 1;
			
		}
	}
}
