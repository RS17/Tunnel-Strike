using UnityEngine;
using System.Collections;

public class Missilecontroller : MonoBehaviour {

	
	public float Pitchspeed = 18f;
	
	public GameObject Exhaust;
	public float Thrust = 10000.0f;
	public float Lift = 1;
	public float Forcelimit = 10;
	public string Control = "Automatic";
	public GameObject Spaceship;
	public GameObject Maincamera;
	public GameObject Targeter;
	public GameObject Missileexplosion;
	public float Lighteffect = 0;
	private float Starttime = 0;
	public Texture Missiletracker;
	public float Xpos;
	public float Ypos;
	public float Spaceshipdistance = 0;
	public float Colorshift = 0;
	public float fuel = 100;


	

	// Use this for initialization
	void Start () {
		Starttime = Time.time;
		Maincamera = GameObject.Find("MainCamera");
		Spaceship = GameObject.Find("spaceshipmod");

		
	}
	
	void OnGUI () { //missile tracker for spaceship GUI
		if (CrossSceneVars.Missiletracker == 1 && CrossSceneVars.Ismissile == 0 && CrossSceneVars.Gameover == 0){
			Ypos = Screen.height/2-(((transform.position.y-Spaceship.transform.position.y)/150)*Screen.height);
			Xpos = Screen.width/2+(((transform.position.x-Spaceship.transform.position.x)/150)*Screen.width);
			if (Xpos > Screen.width-10){
					Xpos = Screen.width-10;
			}
			if (Xpos < 10){
				Xpos = 10;
			}
			if (Ypos <10){
				Ypos = 10;
			}
			if (Ypos >Screen.height-10){
				Ypos = Screen.height-10;
			}
			//if(Xpos>Ypos && Ypos<Screen.height/2){
			//	Ypos = 0;
			//}
			//else if (Xpos>Ypos){
			//	Ypos = Screen.height;
			//}
			//else if (Xpos>Screen.width/2){
			//	Xpos = Screen.width;
			//}
			//else {
			//	Xpos = 0;
			//}
			Spaceshipdistance = Vector3.Distance(Spaceship.transform.position, transform.position);
			if (Spaceshipdistance > 1000){
				Spaceshipdistance = 1000;
			}
			Colorshift = 1-(Mathf.Pow(1000-Spaceshipdistance,2)/1000000); //should go to 0 as missile gets closer (more distance = bigger colorshift)
			//if (Colorshift>1){
			//	Colorshift = 1;
			//}
			GUI.color = new Color(1, Colorshift, Colorshift, 1);
			Rect MTRect = new Rect(Xpos-10,Ypos-10, 20,20);
			GUI.DrawTexture(MTRect, Missiletracker);
			//missile tracker distance number: it works, but I don't think it's helpful because you can't read it during game
			//GUI.Label(new Rect(Xpos, Ypos+30, 40, 20), System.String.Format("{0}", Spaceshipdistance));
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossSceneVars.Paused == 0){
		
	// Missile rotater
			if(Control == "Manual"){
				if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
					//rigidbody.AddRelativeTorque(0, 0, Pitchspeed);
					GetComponent<Rigidbody>().AddRelativeTorque(0, 0-Pitchspeed, 0);
				}
				if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
					GetComponent<Rigidbody>().AddRelativeTorque(0-Pitchspeed, 0, 0);
				}if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
					//rigidbody.AddRelativeTorque(0, 0, 0-Pitchspeed);
					GetComponent<Rigidbody>().AddRelativeTorque(0, Pitchspeed, 0);
				}if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
					GetComponent<Rigidbody>().AddRelativeTorque(Pitchspeed, 0, 0);
				}
			}
			else{
				//line below rotates missile to match targeter rotation.  Subtracted angles are to calibrate because starting angles in transform are screwy.
				Vector3 Rotationdelta = new Vector3(Targeter.transform.rotation.x-transform.rotation.x, Targeter.transform.rotation.y-transform.rotation.y, Targeter.transform.rotation.z-transform.rotation.z);
				if(Rotationdelta.x > Forcelimit){
					Rotationdelta.x = Forcelimit;
				}
				else{
					if(Mathf.Abs(Rotationdelta.x) > Forcelimit){
						Rotationdelta.x = 0-Forcelimit;
					}
				}
				if(Rotationdelta.y > Forcelimit){
					Rotationdelta.y = Forcelimit;
				}
				else{
					if(Mathf.Abs(Rotationdelta.y) > Forcelimit){
						Rotationdelta.y = 0-Forcelimit;
					}
				}
				if(Rotationdelta.z > Forcelimit){
					Rotationdelta.z = Forcelimit;
				}
				else{
					if(Mathf.Abs(Rotationdelta.z) > Forcelimit){
						Rotationdelta.z = 0-Forcelimit;
					}
				}
				GetComponent<Rigidbody>().AddTorque(Rotationdelta*Pitchspeed);
				//float targetx = Spaceship.transform.position.x-transform.position.x;
				//float targety = Spaceship.transform.position.y-transform.position.y;
				//if(transform.rotation.y < 100){
				//	if(targety<0){
				//		rigidbody.AddRelativeTorque(0, 0, Pitchspeed);
				//	}
				//}
				//if(transform.rotation.x > -10){
				//	if(targetx>0){
				//		rigidbody.AddRelativeTorque(0-Pitchspeed, 0, 0);
				//	}
				//}
				//if(transform.rotation.y > 80){
				//	if(targety>0){
				//		rigidbody.AddRelativeTorque(0, 0, 0-Pitchspeed);
				//	}
				//}
				//if(transform.rotation.x < 10){
				//		if(targetx<0){
				//		rigidbody.AddRelativeTorque(Pitchspeed, 0, 0);
				//	}
				//}
			}
		
		//Missile forward movement
		//	transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+1.0f);
			Vector3 Away_from_exhaust = (transform.position - Exhaust.transform.position).normalized; 
			GetComponent<Rigidbody>().AddForce(Away_from_exhaust*Thrust);
			if(Time.time - Starttime > fuel){
				Thrust = 0;
			}
		}
		
	}
	//Exploder
	public void OnTriggerEnter(Collider collider){
		if(collider.gameObject.name == "spaceship" || collider.gameObject.name == "Cylinder" || collider.gameObject.name == "spaceship" || collider.gameObject.name == "spaceshipmod" || collider.gameObject.tag == "Laser" || collider.gameObject.tag == "Missile" || collider.gameObject.name == "Plane" || collider.gameObject.tag == "Solid"){
			CrossSceneVars.missilecount--;
			if (CrossSceneVars.Ismissile == 1 && gameObject.tag == "Player"){  //this causes gameover anytime missile explodes during champ mode
				CrossSceneVars.Gameover = 1;
				CrossSceneVars.Finaldist = (int) transform.position.z;
			}
			Destroy(gameObject);//must be above instantiate for this to work, otherwise error kills ontrigger
			Collider[] colliders = Physics.OverlapSphere (transform.position, 10.0f);
			foreach (Collider hit in colliders) {
				if (!hit){
					continue;
				}
				if (hit.gameObject.name == "spaceshipmod"){
					Spaceshipstatuscontroller.hitby = 2;
				}

				if (hit.GetComponent<Rigidbody>()){
					hit.GetComponent<Rigidbody>().AddExplosionForce(50000.0f, transform.position, 10000.0f);
				}
			}
			GameObject explosion = (GameObject)Instantiate(Missileexplosion, transform.position, Quaternion.identity);
			//explosion.Emit();
		}
	}
}
