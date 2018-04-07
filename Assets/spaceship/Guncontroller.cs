using UnityEngine;
using System.Collections;

public class Guncontroller : MonoBehaviour {

	public GameObject Plasmashot;
	public GameObject spaceship;
	private float Newtime = 0;
	public float Plasmavelocity = 15.0f;
	public float Fireinterval = 0.5f;
	private Vector3 Plasmaforce;
	
	// Use this for initialization
	void Start () {
		//spaceship = GameObject.Find("spaceship");
		Plasmaforce = new Vector3(0,0,Plasmavelocity);
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 direction_to_player = (spaceship.transform.position - transform.position).normalized;

		if(Input.GetKey(KeyCode.Space)){
			if ((Time.time - Newtime) > Fireinterval){
				//string Plasmaname = ("pshot");
				//Quaternion Laserorientation = new Quaternion (transform.rotation.x, transform.rotation.y, transform.rotation.z, 0);
				GameObject plasmashot = (GameObject)Instantiate(Plasmashot, transform.position, Quaternion.identity);
				//Plasmashot.name = Plasmaname;
				//problem below is that adding force on global coordinates, want to use local (gun) coordinates
				//plasmashot.rigidbody.AddRelativeForce(0, 0, spaceship.rigidbody.velocity.z+Plasmaforce.z);
				plasmashot.GetComponent<Rigidbody>().AddForce(-transform.up*Plasmaforce.z + spaceship.GetComponent<Rigidbody>().velocity);
				Newtime = Time.time;
				
			}
			
		}
	
	}
}

