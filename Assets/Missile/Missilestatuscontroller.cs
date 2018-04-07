using UnityEngine;
using System.Collections;

public class Missilestatuscontroller : MonoBehaviour {

	public int Score=0;
	private Vector3 collisionforce;
	public GameObject MainCamera;
	public GameObject Rearcamera;
	public float life = 0;
	private Vector3 objectpos;
	//private int Gameover = 0;
	public float deathtime = 0;
	public float scenestart = 0;
	public float lifebar = 0.00f;
	public float divisor = 0;
	public GameObject Collisionsound;
	public Texture lifebartexture;
	public float distbar = 0.0f;
	public Texture distbartexture;
	public Texture white;
	public GameObject Spotlight;
	
	// Use this for initialization
	public void OnGUI() {

		GUI.Label(new Rect(20,60,140,20), System.String.Format("Distance: {0}", (int) transform.position.z));
		if (CrossSceneVars.Champmode == 1){
			GUI.Label(new Rect(20, 80, 200, 20), System.String.Format("Record: {0}", Optionsandstatus.Missilehighscore));
		}

	}
	
	void Start (){
		MainCamera = GameObject.Find("MainCamera");
		Rearcamera = GameObject.Find("Rearcamera");
		scenestart = 0;
		if (Optionsandstatus.Lighting == 2){
			Spotlight.active = true;
		}
		else{
			Spotlight.active=false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.R)){
			MainCamera.active = false;
			Rearcamera.active = true;
		}
		else{
			Rearcamera.active = false;
			MainCamera.active = true;
		}
		
	}
			
}
