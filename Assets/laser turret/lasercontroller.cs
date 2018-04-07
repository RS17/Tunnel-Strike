using UnityEngine;
using System.Collections;

public class lasercontroller : MonoBehaviour {
	
	public GameObject Laserexplosion;
	public float Starttime;

	// Use this for initialization
	void Start () {
		Starttime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time-Starttime > .15){
			gameObject.GetComponent<Collider>().enabled = true;
		}
		if (Time.time-Starttime > 30){
			Destroy(gameObject);
		}
	}
	public void OnTriggerEnter(Collider collider){
		//if(collider.gameObject.name == "spaceship" || collider.gameObject.name == "Cylinder" || collider.gameObject.name == "spaceshipmod" || collider.gameObject.name == "Plane" || collider.gameObject.name == "Blanktunnelsection1(Clone)" ||collider.gameObject.name == "Blanktunnelsection(Clone)"){
			Destroy(gameObject);//must be above instantiate for this to work, otherwise error kills ontrigger
			Collider[] colliders = Physics.OverlapSphere (transform.position, 10.0f);
			foreach (Collider hit in colliders) {
				if (!hit){
					continue;
				}
				if (hit.gameObject.name == "spaceshipmod"){
					Spaceshipstatuscontroller.hitby = 1;
				}
				if (hit.GetComponent<Rigidbody>()){
					hit.GetComponent<Rigidbody>().AddExplosionForce(5000.0f, transform.position, 1000.0f);
				}
			}
			GameObject explosion = (GameObject)Instantiate(Laserexplosion, transform.position, Quaternion.identity);
			//explosion.Emit();
		//}
		
	}
}
