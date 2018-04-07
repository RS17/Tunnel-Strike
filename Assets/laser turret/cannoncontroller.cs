using UnityEngine;
using System.Collections;

public class cannoncontroller : MonoBehaviour {
	
	//note that this is actually attached to  spotlight, not cannon
	
	public GameObject Laser;
	public GameObject spaceship;
	private float Newtime = 0;
	public float Leadmultiplier = 10;
	private float Oldspaceshippos = 0;
	public float Laservelocity = 15.0f;
	public float Fireinterval = 0.5f;
	public float Startdist = 3000.0f;

	// Use this for initialization
	void Start () {
		if (CrossSceneVars.Ismissile == 1){
			spaceship = GameObject.Find("Missile");
		}
		else{
			spaceship = GameObject.Find("spaceshipmod");
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 direction_to_player = (spaceship.transform.position - transform.position).normalized;
		if (CrossSceneVars.Gameover == 0){
			transform.LookAt(spaceship.transform.position);
			if((transform.position.z - spaceship.transform.position.z)<Startdist && (transform.position.z - spaceship.transform.position.z)>-1000){
				
				if ((Time.time - Newtime) > Fireinterval){
					float Newspaceshippos = spaceship.transform.position.z;
					float Leadfactor = Newspaceshippos-Oldspaceshippos; //Leads ship based on speed.  Note that fireinterval will effect calibration
					Oldspaceshippos = spaceship.transform.position.z;
					Vector3 Lasertarget = new Vector3(spaceship.transform.position.x, spaceship.transform.position.y, spaceship.transform.position.z + Leadfactor*Leadmultiplier);
					transform.LookAt(Lasertarget);
					//transform.rotation = Quaternion.SetLookRotation(direction_to_player, objTarget.transform.up);
					//Quaternion Laserorientation = new Quaternion (transform.rotation.x, transform.rotation.y -90, transform.rotation.z, 0);
					GameObject lasershot = (GameObject)Instantiate(Laser, transform.position, transform.rotation);// new Quaternion.Euler(transform.rotation.x, transform.rotation.y -90, transform.rotation.z, 0));
					lasershot.GetComponent<Rigidbody>().AddForce((Lasertarget-transform.position)*Laservelocity);
					lasershot.transform.Rotate(Vector3.left * 90);
					Newtime = Time.time;
					
				}
				
			}
		}
	
	}
}
