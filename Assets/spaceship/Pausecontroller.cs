using UnityEngine;
using System.Collections;

public class Pausecontroller : MonoBehaviour {
	public static float RegTimescale;
	public static int showGUI = 1;
	public int Dontpause = 1;
	public GameObject Missileexplosion;
	public GameObject MainCamera;

	public float Changetime;


	// Use this for initialization
	void OnLevelWasLoaded (int level) {
		MainCamera = GameObject.Find("MainCamera");
		if (level == 3){
			Dontpause = 0;
		}
		if (level == 2){
			Dontpause = 1;
		}
		if (level == 4){
			Dontpause = 0;
		}
	}
	
	void Start () {
		RegTimescale = Time.timeScale;
	}
	void OnGUI (){
		if (CrossSceneVars.Paused == 1 && showGUI == 1 && Dontpause == 0){
			GUI.Box(new Rect(200, 100, 400, 300), "PAUSED \n \n CONTROLS: \n W,A,S,D - Control spacecraft \n Q,E - Strafe L/R (requires thrust vectoring) \n SHIFT. Z - Fire rockets \n SPACE - Fire guns \n TAB - Reorient ship (requires reorientator) \n 1-5 Cycle camera views \n \n Press P to resume");
			if (GUI.Button(new Rect(175, 410, 140, 30), "Blow up")){
				Time.timeScale = RegTimescale;
				CrossSceneVars.Paused = 0;
				Changetime = 0;
				CrossSceneVars.Gameover = 1;
				CrossSceneVars.deathtime = Time.time;
				CrossSceneVars.Finaldist = (int) transform.position.z;
				Destroy(gameObject);
					
				GameObject explosion = (GameObject)Instantiate(Missileexplosion, transform.position, Quaternion.identity);
			}
			if (Optionsandstatus.Sound == 0){
				if (GUI.Button(new Rect(325, 410, 140, 30), "Sound is now off")){
					Optionsandstatus.Sound = 1;
					PlayerPrefs.SetInt("Sound", 1);
					MainCamera.GetComponent<AudioListener>().enabled = true;
				}
			}
			else if (Optionsandstatus.Sound == 1){
				if (GUI.Button(new Rect(325, 410, 140, 30), "Sound is now on")){
					Optionsandstatus.Sound = 0;
					PlayerPrefs.SetInt("Sound", 0);
					MainCamera.GetComponent<AudioListener>().enabled = false;
				}
			}
			if (GUI.Button(new Rect(475, 410, 140, 30), "Resume")){
				Time.timeScale = RegTimescale;
				CrossSceneVars.Paused = 0;
				Changetime = 0;
			}
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if(CrossSceneVars.Paused == 1 && Changetime > 25){
			if (Input.GetKey(KeyCode.P)){
				Time.timeScale = RegTimescale;
				CrossSceneVars.Paused = 0;
				Changetime = 0;
				
				//Ingameinstructions.active = false;
			}
		}
		else if ((Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.Escape)) && Changetime > 25 && Dontpause == 0){
			Time.timeScale = 0;
			CrossSceneVars.Paused = 1;
			Changetime = 0;
			//Ingameinstructions.active = true;
		}
		Changetime++;
	
	}
}
