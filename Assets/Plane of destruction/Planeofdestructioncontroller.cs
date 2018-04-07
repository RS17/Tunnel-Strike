using UnityEngine;
using System.Collections;

public class Planeofdestructioncontroller : MonoBehaviour {
	public GameObject Spaceship;
	private Vector3 forward = new Vector3(0,0,1000);
	public float constforce = 5000;
	
	

	// Use this for initialization
	void Start () {
		Spaceship = GameObject.Find("spaceship");
	
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossSceneVars.Paused ==0 && CrossSceneVars.Gameover == 0){
			if ((CrossSceneVars.Coreexist ==2 && (Time.time - CrossSceneVars.Coretime) > 5) || CrossSceneVars.Champmode == 1){
				GetComponent<Rigidbody>().AddForce(0, 0, constforce);
				Collider[] colliders = Physics.OverlapSphere (transform.position, 500.0f);
				
				float Zdistancetospaceship = Spaceship.transform.position.z - transform.position.z;
				if (Spaceship.transform.position.z <110000){
					if(Zdistancetospaceship > 10000){
						GetComponent<Rigidbody>().AddForce(0, 0, 10000);
						//Spaceship.transform.position = new Vector3(0, -1000, 0);
					}
					if(Zdistancetospaceship > 20000){
						GetComponent<Rigidbody>().AddForce(0, 0, 30000);
						//Spaceship.transform.position = new Vector3(0, -1000, 0);
					}
				}
	
				foreach (Collider hit in colliders) {
					if (!hit){
						continue;
					}
	
					if (hit.GetComponent<Rigidbody>()){
						hit.GetComponent<Rigidbody>().AddExplosionForce(10000, transform.position, 10000.0f);
					}
				}
				
			}
			else{
				//CharacterController controller = GetComponent<CharacterController>();
				//Vector3 direction_to_spaceship = (Spaceship.transform.position - transform.position).normalized;
				//rigidbody.AddForce(direction_to_spaceship*1000);
				//transform.position = new Vector3(0,100,Spaceship.transform.position.z-10000);
				float Zdistancetospaceship = Spaceship.transform.position.z - transform.position.z;
				if(Zdistancetospaceship > 3000){
					GetComponent<Rigidbody>().AddForce(0, 0, 5000);
					//Spaceship.transform.position = new Vector3(0, -1000, 0);
				}
				if(Zdistancetospaceship > 10000){
					GetComponent<Rigidbody>().AddForce(0, 0, 10000);
					//Spaceship.transform.position = new Vector3(0, -1000, 0);
				}
				if(Zdistancetospaceship > 20000){
					GetComponent<Rigidbody>().AddForce(0, 0, 30000);
					//Spaceship.transform.position = new Vector3(0, -1000, 0);
				}
			}
		}

			
	}
	public void OnTriggerEnter(Collider collider){
		Destroy(collider.gameObject);
	}
}
