using UnityEngine;
using System.Collections;

public class Rearcameracontroller : MonoBehaviour {
	
	public GameObject Spaceship; 
	public GameObject Missile;
	public int followmissile = 0;
	public Vector3 direction_to_spaceship = new Vector3(0,0,0);

	// Use this for initialization
	void Start () {

		Spaceship = GameObject.Find("spaceshipmod");


	
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossSceneVars.Ismissile == 1){
			followmissile = 1;
		}
		if (CrossSceneVars.Gameover == 0){
			if (followmissile == 1){
				direction_to_spaceship = (Missile.transform.position - transform.position).normalized;
				transform.position = new Vector3(Missile.transform.position.x, Missile.transform.position.y, (Missile.transform.position.z+60.0f));
			}
			else{
				direction_to_spaceship = (Spaceship.transform.position - transform.position).normalized;
				transform.position = new Vector3(Spaceship.transform.position.x, Spaceship.transform.position.y, (Spaceship.transform.position.z+30.0f));
			}
			GetComponent<Rigidbody>().AddForce(direction_to_spaceship*10000);
		}
	// TODO: have camera follow rotation of ship and still follow losely behind, but set limits on how far off it can get
	
	}
}
