using UnityEngine;
using System.Collections;

public class Plasmacontroller : MonoBehaviour {

	public GameObject Plasmaexplosion;
	public float force;
	public float radius;
	// note - if plasma has mass, will collide with spaceship and cause steering issues.  Use layer collisions and physics settings to avoid.
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//public void OnTriggerEnter(Collider collider){
	public void OnCollisionEnter(Collision collision){	
		//ParticleEmitter explosion = (ParticleEmitter)Instantiate(Plasmaexplosion, transform.position, Quaternion.identity);
		//	explosion.Emit();
		//if(collision.gameObject.tag != "Player"){ //|| collider.gameObject.name == "Cylinder" || collider.gameObject.name == "Missile_turret" || collider.gameObject.name == "Plane" || collider.gameObject.name == "Blanktunnelsection(Clone)"){
			Destroy(gameObject);//must be above instantiate for this to work, otherwise error kills ontrigger
			Collider[] collider1 = Physics.OverlapSphere (transform.position, 10.0f);
			foreach (Collider hit in collider1) {
				if (!hit){
					continue;
				}
				if(hit.GetComponent<Rigidbody>() != null){
					if (hit.GetComponent<Rigidbody>().tag == "Player"){
						continue;
					}

					if (hit.GetComponent<Rigidbody>()){
						hit.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius);
					}
				}
				GameObject explosion = (GameObject)Instantiate(Plasmaexplosion, transform.position, Quaternion.identity);
				//explosion.Emit();
			}
	//	}
		
	}
}
