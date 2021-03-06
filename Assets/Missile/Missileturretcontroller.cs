using UnityEngine;
using System.Collections;

public class Missileturretcontroller : MonoBehaviour {
	public GameObject Missile;
	public GameObject spaceship;
	private float Newtime;
	public float Fireinterval = 20.0f;
	private Vector3 Missilepos = new Vector3 (0, 0, 0);

	
		

	// Use this for initialization
	void Start () {
		Newtime = Time.time;
		if (CrossSceneVars.Ismissile == 1){
			spaceship = GameObject.Find("Missile");
		}
		else {
			spaceship = GameObject.Find("spaceshipmod");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossSceneVars.missilecount <5 && CrossSceneVars.Gameover == 0){
			float spaceshipdist = spaceship.transform.position.z - transform.position.z;
			if(spaceshipdist > 300 && spaceshipdist < 4000){
				if ((Time.time - Newtime) > Fireinterval){
					CrossSceneVars.missilecount++;
					if(transform.position.x<0){
						Missilepos = new Vector3(transform.position.x+50.0f, transform.position.y, transform.position.z);
					}
					else{
						Missilepos = new Vector3(transform.position.x-50.0f, transform.position.y, transform.position.z);
					}
					GameObject turretmissile = (GameObject)Instantiate(Missile, Missilepos, Quaternion.identity);
					Newtime = Time.time;
				}
			}
		}
	}
}
