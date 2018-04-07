using UnityEngine;
using System.Collections;

public class Collidercontroller : MonoBehaviour {
	public int life = 1000;
	private Vector3 objectpos;
	private Vector3 collisionforce;
	public GameObject Missileexplosion;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnCollisionEnter(Collision collision){
		life=life-10;
		if (GetComponent<Collider>().gameObject.tag == "Player"){
			return;
		}
		if (GetComponent<Collider>().gameObject.tag == "Solid"){
			objectpos = GetComponent<Collider>().gameObject.transform.position;
			collisionforce = GetComponent<Rigidbody>().GetRelativePointVelocity(objectpos);
			life = life-(int) (collisionforce.magnitude*.0001);
		}
		if (GetComponent<Collider>().gameObject.tag == "Laser"){
			life = life - 10;
		}
		if (GetComponent<Collider>().gameObject.tag == "Missile"){
			life = life - 100;
		}
		if (life <1){
			//Gameover = 1;
			//player explosion no longer works after Unity upgrade...
			//ParticleEmitter explosion = (ParticleEmitter)Instantiate(Missileexplosion, transform.position, Quaternion.identity);
			//explosion.Emit();
			//Spaceshipmesh.active = false;
		}
	}
}
