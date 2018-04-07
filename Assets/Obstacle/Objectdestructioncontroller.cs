using UnityEngine;
using System.Collections;

public class Objectdestructioncontroller : MonoBehaviour {
	public int life = 0;
	private Vector3 objectpos;
	private Vector3 collisionforce;
	public int Exptype = 0;
	public GameObject Coreexplosion;
	public GameObject Coreexplosion2;
	public GameObject Objectsplosion;
	public float deathtime;

	// Use this for initialization
	void Start () {
		//Coreexplosion2 = GameObject.Find("Coreexplosion");
		//Objectsplosion = GameObject.Find("MissileExplosion");

	}
	
	// Update is called once per frame
	void Update () {
		if (Optionsandstatus.Champmodeunlocked == 0 && Time.time-deathtime >1 && Exptype == 1 && CrossSceneVars.Coreexist==2){
				Optionsandstatus.Champmodeunlocked = 1;
				PlayerPrefs.SetInt("Champmodeunlocked", 1);
				Application.ExternalCall("kongregate.stats.submit","CoreDestroyed",1);
				Pausecontroller.showGUI = 0;
				CrossSceneVars.Paused = 1;
				Time.timeScale = 0;
				CrossSceneVars.ShowcoreGUI = 1;
				Destroy(gameObject);
			}
	
	}
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player"){
			objectpos = GetComponent<Collider>().gameObject.transform.position;
			collisionforce = GetComponent<Rigidbody>().GetRelativePointVelocity(objectpos);
			life = life-(int) (collisionforce.magnitude*.0001);
		}
		if (other.gameObject.tag == "Solid"){
			objectpos = GetComponent<Collider>().gameObject.transform.position;
			collisionforce = GetComponent<Rigidbody>().GetRelativePointVelocity(objectpos);
			life = life-(int) (collisionforce.magnitude*.0001);
		}
		if (other.gameObject.tag == "Laser"){
			life = life - 10;
		}
		if (other.gameObject.tag == "Missile"){
			life = life - 100;
		}
		if (other.gameObject.tag == "Bigplasma"){
			life = life-30;
		}
		if (other.gameObject.tag == "Medplasma"){
			life=life-15;
		}
		if (other.gameObject.tag == "Smallplasma"){
			life=life-5;
		}
		if (life <1){
			if (Exptype == 1){// && CrossSceneVars.Coreexist == 1){ //ie its the core and it ain't blown up yet
				deathtime = Time.time;
				
				Coreexplosion.active = true;
				CrossSceneVars.Coretime = Time.time;
				if (CrossSceneVars.Coreexist == 1){
					GameObject coreexp = (GameObject)Instantiate(Coreexplosion2, transform.position, Quaternion.identity);
				}
				CrossSceneVars.Coreexist = 2;
				gameObject.GetComponent<Renderer>().enabled = false;
				gameObject.GetComponent<Collider>().enabled = false;
			}
			else{
			// Instantiate particles or cloud here
				Destroy(gameObject);
				GameObject Objexp = (GameObject)Instantiate(Objectsplosion, transform.position, Quaternion.identity);
			}


		}
	}
}
