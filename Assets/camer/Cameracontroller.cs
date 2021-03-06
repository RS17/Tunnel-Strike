using UnityEngine;
using System.Collections;

public class Cameracontroller : MonoBehaviour {
	
	
	public GameObject Spaceship; 
	public GameObject Missile;
	//public GameObject Thruster;
	//public GameObject Missileexhaust;
	public int WaitGui = 0;
	public int followmissile = 0;
	public int missilegone = 0; //not really used at present
	public Vector3 direction_to_spaceship = new Vector3(0,0,0);
	public static float followdist = 30;
	
	void OnLevelWasLoaded (int level) {
		if (level == 4){
			
			WaitGui = 1;
			
		}
	}
	
	void OnGUI () {
		if (WaitGui == 1){
			Pausecontroller.showGUI = 0;
			CrossSceneVars.Paused = 1;
			Time.timeScale = 0;
			GUI.TextArea(new Rect(270, 50, 300, 170), "Champion Mode:  \n \nChampion mode gives you almost all of the upgrades and infinite rocket fuel.  There is no core or endpoint so go as far as you can.  Make sure you are going fast enough to stay ahead of the exploding tunnel.");
			if (GUI.Button(new Rect(320, 230, 200, 30), "Play as Spaceship")){
				Destroy(Missile);
				WaitGui = 0;
				CrossSceneVars.Paused = 0;
				Time.timeScale = Pausecontroller.RegTimescale;
				Pausecontroller.showGUI = 1;
				CrossSceneVars.Ismissile = 0;
				followmissile = 0;
			}
			if (Optionsandstatus.Missileunlocked == 1){
				if (GUI.Button(new Rect(320, 270, 200, 30), "Play as Missile")){
					Destroy(Spaceship);
					CrossSceneVars.Missiletracker=0;
					WaitGui = 0;
					CrossSceneVars.Paused = 0;
					Time.timeScale = Pausecontroller.RegTimescale;
					followmissile = 1;
					CrossSceneVars.Ismissile = 1;
					Pausecontroller.showGUI = 1;
				}
			}
		}
	}
	
	// Use this for initialization
	void Start () {
		Spaceship = GameObject.Find("spaceshipmod");
		if (Optionsandstatus.Sound == 0){
			GetComponent<AudioListener>().enabled = false;
		}
		else{
			GetComponent<AudioListener>().enabled = true;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossSceneVars.Gameover != 1){
			if (Optionsandstatus.Missileunlocked == 0){
				Destroy(Missile);
			}
			if (followmissile == 1){
				direction_to_spaceship = (Missile.transform.position - transform.position).normalized;
				transform.position = new Vector3(Missile.transform.position.x, Missile.transform.position.y, (Missile.transform.position.z-60.0f));
			}
			else if(Spaceship != null){
				direction_to_spaceship = (Spaceship.transform.position - transform.position).normalized;
				transform.position = new Vector3(Spaceship.transform.position.x, Spaceship.transform.position.y, (Spaceship.transform.position.z-followdist));
			}
			//rigidbody.AddForce(direction_to_spaceship*10000);
		}
		//transform.position = new Vector3(transform.position.x, transform.position.y, (Spaceship.transform.position.z-30.0f));
		// TODO: have camera follow rotation of ship and still follow losely behind, but set limits on how far off it can get

	
	}
}
