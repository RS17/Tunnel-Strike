using UnityEngine;
using System.Collections;

public class smallrocketcontroller : MonoBehaviour {
	private float Boost;
	public float Boostlevel = 1000;
	public GameObject spaceship;
	public float Fuel;
	public GameObject Lexhaust;
	public GameObject Rexhaust;
	public GameObject LLight;
	public GameObject RLight;
	public Texture fueltexture;
	public float fuelbar =0;
	public float Startfuel =0;
	public int currlevel;
	
	void OnLevelWasLoaded(int level){
		currlevel = level;
		if (level == 3){
			Fuel = Startfuel;
		}
	}
	
	void OnGUI () {
		if (currlevel > 2){
			fuelbar = 140*(Fuel/Startfuel);
			GUI.Label(new Rect(20, 150, 140, 20), System.String.Format("Rocket Fuel:"));		
			GUI.DrawTexture(new Rect(20, 170, fuelbar, 20), fueltexture, ScaleMode.ScaleAndCrop, true, 0);
		}
	}
	// Use this for initialization
	
	void Start () {
		Startfuel = Fuel;
	
	}
	
	// Update is called once per frame
	void Update () {
		if((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Z)) && Fuel >0 && CrossSceneVars.Paused == 0){
				Boost = Boostlevel;
				Fuel--;
				Lexhaust.active = true;
				Rexhaust.active = true;
				LLight.active = true;
				RLight.active = true;
				
		}
		else{
			Boost = 0;
			Lexhaust.active = false;
			Rexhaust.active = false;
			LLight.active = false;
			RLight.active = false;
		}
		spaceship.GetComponent<Rigidbody>().AddRelativeForce(0, 0, Boost);
		
	}
}
