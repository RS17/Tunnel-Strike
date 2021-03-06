using UnityEngine;
using System.Collections;

public class UpgradeGUI : MonoBehaviour {
	public GameObject spaceship;
	public GameObject spaceshipmesh;
	public GameObject CrossSceneVarHolder;
	public GameObject srocket;
	public GameObject srocketleft;
	public GameObject srocketright;
	public GameObject mrocketleft;
	public GameObject mrocketright;
	public GameObject mrocket;
	public GameObject lrocket;
	public GameObject lrocketleft;
	public GameObject lrocketright;
	public Material steelarmor;
	public Material alumarmor;
	public Material titanarmor;
	public GameObject scannonleft;
	public GameObject scannonright;
	public GameObject mcannonleft;
	public GameObject mcannonright;
	public GameObject lcannonleft;
	public GameObject lcannonright;
	public GameObject VectoredThrust;
	public GameObject VectoredThrustMesh;
	public GameObject Magnet;
	public GameObject Undoer;
	public GameObject Tracker;
	public int Boost;
	public static string LastMessage = "You cannot purchase any items yet.  Use W,A,S,D,Q,E to rotate ship.";

	void Awake(){
		LastMessage = "Purchase items here. Use W,A,S,D,Q,E to rotate ship.";
	}
	
	void OnGUI () {

		GUI.TextArea(new Rect(1,1,100,50),System.String.Format("Money:{0}", CrossSceneVars.Money));
		GUI.TextArea(new Rect(1,55,220,150),System.String.Format(LastMessage));
		if(GUI.Button(new Rect(220,410,200,100), "READY!")){
			LastMessage = "Purchase items here. Use W,A,S,D,Q,E to rotate ship.";
			Application.LoadLevel(3);
		}
		if (GUI.Button(new Rect(400, 1, 200, 50), "Title screen (lose progress)")){
			Application.LoadLevel(0);
		}
	
	}
	void Start(){
		//below is kinda hackish, basically saying if nothing is permanent (i.e. no csvholder) then make a csv holder
		if (GameObject.FindGameObjectWithTag("Permanent")){
			//Instantiate(CrossSceneVarHolder, new Vector3(0,0,0), Quaternion.identity);
		}

		else{
			Instantiate(CrossSceneVarHolder, new Vector3(0,0,0), Quaternion.identity);
		}
		//add anything that's already been added

		srocket.active = CrossSceneVars.Rocket == 1;
		srocketleft.active=CrossSceneVars.Rocket == 1;
		srocketright.active=CrossSceneVars.Rocket == 1;

		mrocket.active = CrossSceneVars.Rocket == 2;
		mrocketleft.active=CrossSceneVars.Rocket == 2;
		mrocketright.active=CrossSceneVars.Rocket == 2;
	
		lrocket.active = CrossSceneVars.Rocket == 3;
		lrocketleft.active=CrossSceneVars.Rocket == 3;
		lrocketright.active=CrossSceneVars.Rocket == 3;
		if (CrossSceneVars.Armor == 1){
			spaceshipmesh.GetComponent<Renderer>().material = steelarmor;
		}
		if (CrossSceneVars.Armor == 2){
			spaceshipmesh.GetComponent<Renderer>().material = alumarmor;
		}
		if (CrossSceneVars.Armor == 3){
			spaceshipmesh.GetComponent<Renderer>().material = titanarmor;
		}

		scannonleft.active=CrossSceneVars.Guns == 1;
		scannonright.active=CrossSceneVars.Guns == 1;

		mcannonleft.active=CrossSceneVars.Guns == 2;
		mcannonright.active=CrossSceneVars.Guns == 2;
	
		lcannonleft.active=CrossSceneVars.Guns == 3;
		lcannonright.active=CrossSceneVars.Guns == 3;
		if (CrossSceneVars.Vectoredthrustactive == 1){
			VectoredThrust.active = true;
		}
		if (CrossSceneVars.Undoeractive == 1){
			Undoer.active = true;
		}
		if (CrossSceneVars.CoinMagnet == 1){
			Magnet.active = true;
		}
		if (CrossSceneVars.Missiletracker == 1){
			Tracker.active = true;
		}
			
	}
	void Update(){
		if (Input.GetKey(KeyCode.A)){
			spaceship.transform.Rotate((Vector3.forward * Time.deltaTime * 100));
			//spaceship.transform.eulerAngles = new Vector3(spaceship.transform.rotation.eulerAngles.x, spaceship.transform.rotation.eulerAngles.y+2.0f, spaceship.transform.rotation.eulerAngles.z);
		}
		if (Input.GetKey(KeyCode.D)){
			spaceship.transform.Rotate((Vector3.back * Time.deltaTime * 100));
			//new Vector3(spaceship.transform.rotation.eulerAngles.x, spaceship.transform.rotation.eulerAngles.y-0.001f, spaceship.transform.rotation.eulerAngles.z));
		}
		if (Input.GetKey(KeyCode.W)){
			spaceship.transform.Rotate((Vector3.right * Time.deltaTime * 100));
			//spaceship.transform.eulerAngles = new Vector3(spaceship.transform.rotation.eulerAngles.x+2.0f, spaceship.transform.rotation.eulerAngles.y, spaceship.transform.rotation.eulerAngles.z);
		}
		if (Input.GetKey(KeyCode.S)){
			spaceship.transform.Rotate((Vector3.left * Time.deltaTime * 100));
			//spaceship.transform.eulerAngles = new Vector3(spaceship.transform.rotation.eulerAngles.x-2.0f, spaceship.transform.rotation.eulerAngles.y, spaceship.transform.rotation.eulerAngles.z);
		}
		if (Input.GetKey(KeyCode.Q)){
			spaceship.transform.Rotate((Vector3.down * Time.deltaTime * 100));
			//spaceship.transform.eulerAngles = new Vector3(spaceship.transform.rotation.eulerAngles.x-2.0f, spaceship.transform.rotation.eulerAngles.y, spaceship.transform.rotation.eulerAngles.z);
		}
		if (Input.GetKey(KeyCode.E)){
			spaceship.transform.Rotate((Vector3.up * Time.deltaTime * 100));
			//spaceship.transform.eulerAngles = new Vector3(spaceship.transform.rotation.eulerAngles.x-2.0f, spaceship.transform.rotation.eulerAngles.y, spaceship.transform.rotation.eulerAngles.z);
		}
		if (CrossSceneVars.Developmode == 1 && Input.GetKey(KeyCode.KeypadPlus)){
			CrossSceneVars.Money = CrossSceneVars.Money + 100000;
		}
	}
}
