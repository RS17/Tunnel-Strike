using UnityEngine;
using System.Collections;

public class Optionsandstatus : MonoBehaviour {
	public static int Alreadyexist = 0;
	public static int Optionsscreenactive = 0;
	public static int Sound = 1;
	public static int Shiphighscore = 0;
	public static int Missilehighscore = 0;
	public static int Champmodeunlocked = 0;
	public static int Missileunlocked = 0;
	public static int Lighting = 3;
	public static int Maxquality = 3;
	public static int QualityControl = 1;
	public static int Inverted = 1;
	//public static int APIAvail = 0;
	
	void OnGUI() {
		if (Optionsscreenactive == 1){ //the only way to make overlapping controls is separate scripts
			GUI.depth = 0;
			GUI.TextArea(new Rect(275, 180, 200, 30), "OPTIONS:");
			GUI.depth = 1;
			//mute option
			if (Sound == 0){
				if (GUI.Button(new Rect(275, 120, 200, 30), "Sound is now off")){
					Sound = 1;
					PlayerPrefs.SetInt("Sound", 1);
				}
			}
			else if (Sound == 1){
				if (GUI.Button(new Rect(275, 210, 200, 30), "Sound is now on")){
					Sound = 0;
					PlayerPrefs.SetInt("Sound", 0);
				}
			}
			if (Inverted == 0){
				if (GUI.Button(new Rect(275, 350, 200, 30), "Inv. controls on (W down, S up)")){
					Inverted = 1;
					PlayerPrefs.SetInt("Inverted", 1);
				}
			}
			else if (Inverted == 1){
				if (GUI.Button(new Rect(275, 350, 200, 30), "Inv. controls off (W up, S down)")){
					Inverted = 0;
					PlayerPrefs.SetInt("Inverted", 0);
				}
			}
			// lighting option
			if (Lighting == 1){ 
				if (GUI.Button(new Rect(275, 240, 200, 30), "Low quality lighting")){
					Lighting = 2; //this uses ship-mounted/missile-mounted point light, no tunnel lights
					PlayerPrefs.SetInt("Lighting", 2);
				}
			}
			else if (Lighting == 2){ 
				if (GUI.Button(new Rect(275, 240, 200, 30), "Medium quality lighting")){
					Lighting = 3; //this uses tunnel point lights, not ship light
					PlayerPrefs.SetInt("Lighting", 3);
				}
			}
			else if (Lighting == 3 || Lighting == 0){
				if (GUI.Button(new Rect(275, 240, 200, 30), "High quality lighting")){
					Lighting = 4; // this uses tunnel spot lights, no ship light
					PlayerPrefs.SetInt("Lighting", 4);
				}
			}
			else if (Lighting == 4){
				if (GUI.Button(new Rect(275, 240, 200, 30), "Very High quality lighting")){
					Lighting = 1; //this uses vertexlit textures, no ship light
					PlayerPrefs.SetInt("Lighting", 1);
				}
			}
			if (GUI.Button(new Rect(275, 380, 200, 30), "Back to title screen")){
				Optionsscreenactive = 0;
			}
			// Options quality slider
			GUI.TextArea(new Rect(275, 270, 200, 30), "Default Quality Level");
			Maxquality = (int) GUI.HorizontalSlider (new Rect (275, 300, 200, 30), Maxquality, 1, 6);
			PlayerPrefs.SetInt("Maxquality", Maxquality);
			// Automatic quality control
			if (QualityControl == 0){
				if (GUI.Button(new Rect(275, 320, 200, 30), "Automatic quality control off")){
					QualityControl = 1;
					PlayerPrefs.SetInt("QualityControl", 1);
				}
			}
			else if (QualityControl == 1){
				if (GUI.Button(new Rect(275, 320, 200, 30), "Automatic quality control on")){
					QualityControl = 0;
					PlayerPrefs.SetInt("QualityControl", 0);
				}
			}
		}
	}
	void OnLevelWasLoaded (){
		Optionsscreenactive = 0;
	}
		
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
		if (PlayerPrefs.HasKey("Sound")){
			Sound = PlayerPrefs.GetInt("Sound");
		}
		if (PlayerPrefs.HasKey("Champmodeunlocked")){
			Champmodeunlocked = PlayerPrefs.GetInt("Champmodeunlocked");
		}
		if (PlayerPrefs.HasKey("Missileunlocked")){
			Missileunlocked =  PlayerPrefs.GetInt("Missileunlocked");
		}
		if (PlayerPrefs.HasKey("Shiphighscore")){
			Shiphighscore =  PlayerPrefs.GetInt("Shiphighscore");
		}
		if (PlayerPrefs.HasKey("Missilehighscore")){
			Missilehighscore = PlayerPrefs.GetInt("Missilehighscore");
		}
		if (PlayerPrefs.HasKey("Lighting")){
			Lighting = PlayerPrefs.GetInt("Lighting");
		}
		if (PlayerPrefs.HasKey("Maxquality")){
			Maxquality = PlayerPrefs.GetInt("Maxquality");
		}
		if (PlayerPrefs.HasKey("QualityControl")){
			QualityControl = PlayerPrefs.GetInt("QualityControl");
		}
		
		if (PlayerPrefs.HasKey("Inverted")){
			QualityControl = PlayerPrefs.GetInt("Inverted");
		}
		//if(Optionsandstatus.Alreadyexist == 1){
			//Destroy(gameObject);
		//}
		//else{
		//	Alreadyexist = 1;
		//}
		//DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
