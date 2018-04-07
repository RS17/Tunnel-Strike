using UnityEngine;
using System.Collections;

public class Spaceshipstatuscontroller : MonoBehaviour {
	public int Score=0;
	private float Zdelta = 5;
	private float Oldtransform = -1;
//	private float Winlose = 0;
	private float Oldtime = 0;
	private Vector3 collisionforce;
	public GameObject MainCamera;
	public GameObject Rearcamera;
	public GameObject Closefixed;
	public GameObject Farfixed;
	public GameObject Cockpit;
	public float life = 0;
	private Vector3 objectpos;
	//private int Gameover = 0;
	public GameObject Missileexplosion;
	public GameObject Spaceshipmesh;
	public GameObject Thruster;
	public float deathtime = 0;
	public float scenestart = 0;
	public float lifebar = 0.00f;
	public float divisor = 0;
	public GameObject Collisionsound;
	public Texture lifebartexture;
	public float distbar = 0.0f;
	public Texture distbartexture;
	public Texture white;
	public int currlevel;
	public int stuckcount = 0;
	//public int rundisttest = 0;
	public static int hitby = 0; //will call this from scripts of lasers and missiles that do the actual hitting
	
	void OnLevelWasLoaded(int level){
		currlevel = level;
	}

	// Use this for initialization
	void OnGUI() {
		
		if (currlevel == 3 || currlevel == 1){
			GUI.Label(new Rect(20,20,100,20), System.String.Format("Money: {0}", CrossSceneVars.Money));
			//if(Winlose == 1){
			//	GUI.Label(new Rect(20,40,100,20), System.String.Format("YOU WIN!!!"));
			//}
			//if(Winlose == 2){
			//	GUI.Label(new Rect(20,40,100,20), System.String.Format("YOU LOSE!!!"));
			//}
			//GUI.Label(new Rect(20,60,140,20), System.String.Format("currentdist: {0}", (int) transform.position.z));
			//GUI.Box(new Rect(20, 120, 140, 20), ""); // background to lifebar
			GUI.backgroundColor = Color.green;
			//GUI.color = new Color(0 , 1.0f, 0);
			lifebar = (life/CrossSceneVars.Armorlevel)*140; //all vars here have to be floats or problems will occur.
			divisor = CrossSceneVars.Armorlevel;
			GUI.Label(new Rect(20, 100, 140, 20), System.String.Format("Armor:"));
			GUI.DrawTexture(new Rect(20, 120, lifebar, 20), lifebartexture, ScaleMode.ScaleAndCrop, true, 0);
			distbar = (1-(transform.position.z/200000))*140;
			GUI.Label(new Rect(20, 50, 140, 20), System.String.Format("Distance:"));		
			GUI.DrawTexture(new Rect(20, 70, distbar, 20), distbartexture, ScaleMode.ScaleAndCrop, true, 0);
			GUI.DrawTexture(new Rect(85, 75, 10, 10), white, ScaleMode.ScaleAndCrop, true, 0);
			if (CrossSceneVars.Winnerisyou == 1){
				Application.ExternalCall("kongregate.stats.submit","EscapedTunnel",1);
				if (CrossSceneVars.Coreexist == 2){
					GUI.TextArea(new Rect(200, 100, 400, 200), "Congratulations, you have escaped!  You have now unlocked the missile in Champion's Mode!  \n \n FIN.");
					Optionsandstatus.Missileunlocked = 1;
					PlayerPrefs.SetInt("Missileunlocked", 1);
					if (GUI.Button(new Rect(200, 350, 140, 30), "Go to title screen")){
						Application.LoadLevel(0);
					}
				}
				if (CrossSceneVars.Coreexist ==1){
					GUI.TextArea(new Rect(200, 100, 400, 200), "You have somehow managed to escape, despite sucking enough to miss the core.  You have unlocked nothing.  Go back and try again.");
					if (GUI.Button(new Rect(200, 350, 140, 30), "Blow up")){
						CrossSceneVars.Gameover = 1;
						CrossSceneVars.deathtime = Time.time;
						CrossSceneVars.Finaldist = (int) transform.position.z;
						CrossSceneVars.Winnerisyou = 0;
						Destroy(gameObject);
						
						GameObject explosion = (GameObject)Instantiate(Missileexplosion, transform.position, Quaternion.identity);
					}
				}
			}
			if (CrossSceneVars.Champmode == 1){
				GUI.Label(new Rect(20, 50, 200, 20), System.String.Format("Record: {0}", Optionsandstatus.Shiphighscore));
			}
		}
		if (currlevel == 4){
			GUI.Label(new Rect(20, 100, 140, 20), System.String.Format("Armor:"));
			GUI.DrawTexture(new Rect(20, 120, lifebar, 20), lifebartexture, ScaleMode.ScaleAndCrop, true, 0);
			GUI.Label(new Rect(20,60,140,20), System.String.Format("Distance: {0}", (int) transform.position.z));
			if (CrossSceneVars.Champmode == 1){
				GUI.Label(new Rect(20, 80, 200, 20), System.String.Format("Record: {0}", Optionsandstatus.Shiphighscore));
			}
			lifebar = (life/CrossSceneVars.Armorlevel)*140; //all vars here have to be floats or problems will occur.
		}

	}
	
	void Start (){
		MainCamera = GameObject.Find("MainCamera");
		Rearcamera = GameObject.Find("Rearcamera");
		//Closefixed = GameObject.Find("Closefixed");
		//Farfixed = GameObject.Find("Farfixed");
		//Cockpit = GameObject.Find("Cockpit");
		
		life = CrossSceneVars.Armorlevel;
		scenestart = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//Score++;
		if (CrossSceneVars.Developmode ==1 && Input.GetKey(KeyCode.KeypadPlus)){
			life = life + 10000;
		}
		if (CrossSceneVars.Developmode == 1 && Input.GetKey(KeyCode.KeypadMinus)){
			life = life-100;
		}
	
		//if ((Time.time-Oldtime) > 1.0f){
		//	Oldtime = Time.time;
		//	Zdelta = transform.position.z - Oldtransform;
		//	Oldtransform = transform.position.z;
		//
	//	}
		if(Time.time-scenestart > 10.0f){
			//if (Winlose == 0){//is winlose still used?
			if(transform.position.z > 200000.0f && CrossSceneVars.Champmode == 0){
				CrossSceneVars.Winnerisyou = 1;
			}
			//NOTE: Below is old script for getting stuck that caused problems, along with above "Oldtime" script.  Getting stuck was rare enough that this was determined to be unnecessary because it was causing problems.
			//if(Mathf.Abs(Zdelta) <=1){
			//	if( stuckcount > 10){
			//		transform.position = new Vector3(0, 150.0f, transform.position.z);
			//		stuckcount = 0;
			//	}
			//	stuckcount++;
			//}
			//else{
			//	stuckcount = 0;
			//}
			// position corrector
			if(transform.position.x >=200||transform.position.x<=-200||transform.position.y>=310||transform.position.y<=-10){
				transform.position = new Vector3(0, 150.0f, transform.position.z);
			}
		//	}
		}
		if(Input.GetKey(KeyCode.R)){
		//	MainCamera.active = false;
			Rearcamera.active = true;
		}
		else{
			Rearcamera.active = false;
		//	MainCamera.active = true;
		}
		if (Input.GetKey(KeyCode.Alpha1)){
			MainCamera.active = true;
			Cameracontroller.followdist = 30.0f;
			Rearcamera.active = false;
			Closefixed.active = false;
			Farfixed.active = false;
			Cockpit.active = false;
		}
		if (Input.GetKey(KeyCode.Alpha2)){
			MainCamera.active = true;
			Cameracontroller.followdist = 15.0f;
			Rearcamera.active = false;
			Closefixed.active = false;
			Farfixed.active = false;
			Cockpit.active = false;
		}
			if (Input.GetKey(KeyCode.Alpha3)){
			MainCamera.active = false;
			Rearcamera.active = false;
			Closefixed.active = true;
			Farfixed.active = false;
			Cockpit.active = false;
		}
			if (Input.GetKey(KeyCode.Alpha4)){
			MainCamera.active = false;
			Rearcamera.active = false;
			Closefixed.active = false;
			Farfixed.active = true;
			Cockpit.active = false;
		}	if (Input.GetKey(KeyCode.Alpha5)){
			MainCamera.active = false;
			Rearcamera.active = false;
			Closefixed.active = false;
			Farfixed.active = false;
			Cockpit.active = true;
		}
		
			
			
		//if (Gameover == 1){
		//	if ((Time.time - deathtime) > 5){
		//		Application.LoadLevel(2);
		//	}
		//}
		if (hitby == 1){ //ie just got hit by a laser
			life = life-40;
			hitby = 0;
		}
		if (hitby == 2){//ie just got hit by a missile
			life = life-400;
			hitby = 0;
		}
		
	}
	//should probably get meshes together and change to "oncollisionenter" in the future
	void OnCollisionEnter(Collision other){
		//life=life-10;
		if (other.gameObject.tag == "Player"){
			return;
		}
		if (other.gameObject.tag == "Solid"){
			objectpos = GetComponent<Collider>().gameObject.transform.position;
			collisionforce = GetComponent<Rigidbody>().GetRelativePointVelocity(objectpos);
			life = life-(int) (collisionforce.magnitude*.0002);
			ContactPoint contact = other.contacts[0];
			GetComponent<Rigidbody>().AddExplosionForce(500, contact.point, 100);
			GameObject collision = (GameObject)Instantiate(Collisionsound, contact.point, Quaternion.identity);

		}
		// below wasn't working, so replaced with public static "hitby" variable in void update
		//if (other.gameObject.tag == "Laser"){
		//	life = life - 40;
		//}
		//if (other.gameObject.tag == "Missile"){
		//	life = life - 200;
		//}
		if (life <1){
			MainCamera.active = true;
			MainCamera.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z-30);
			Rearcamera.active = false;
			Closefixed.active = false;
			Farfixed.active = false;
			Cockpit.active = false;
			CrossSceneVars.deathtime = Time.time;
			CrossSceneVars.Finaldist = (int) transform.position.z;
			Destroy(gameObject);
			CrossSceneVars.Gameover = 1;
			CrossSceneVars.bonus = (int) (CrossSceneVars.Finaldist*(transform.position.z/4000000));// is used above in money adder in crossscenevars
			CrossSceneVars.lastdist = (int) CrossSceneVars.Finaldist; // is used in money adder
			
			GameObject explosion = (GameObject)Instantiate(Missileexplosion, transform.position, Quaternion.identity);
			//explosion.Emit();
			
			//Spaceshipmesh.active = false;
			//Thruster.active = false;
			//rigidbody.isKinematic = true;
			
			//do not put anything under here, will not get executed.
		}
			
	}

		
}
