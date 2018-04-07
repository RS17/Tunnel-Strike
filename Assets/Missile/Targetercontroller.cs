using UnityEngine;
using System.Collections;

public class Targetercontroller : MonoBehaviour {
	public GameObject Spaceship;

	// Use this for initialization
	void Start () {
		if (CrossSceneVars.Ismissile == 1){
			Spaceship = GameObject.Find("Missile");
		}
		else {
			Spaceship = GameObject.Find("spaceship");
		}

	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(Spaceship.transform.position);
	}
}
