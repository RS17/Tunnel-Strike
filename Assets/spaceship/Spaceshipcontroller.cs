using UnityEngine;
using System.Collections;

public class Spaceshipcontroller : MonoBehaviour {
	
	public float Pitchbase = 0.8f;
	public float Rollspeed = 5.0f;
	public float Pitchaccel = 0.2f;
	//will probably need yaw controller at some point
	public GameObject Thruster;
	public float Thrust = 100.0f;
	public float Lift = 0.03f;
	public float Maxrotation = 90f;
	private float Boost = 0.0f; 
	private float Pitchspeeddown = 0f;
	private float Pitchspeedup = 0f;
//	private float holdcountdown = 0f;
//	private float holdcountup = 0f;
	public float limitedx = 0.0000f;
	public float limitedy = 0.0000f;
	public float limitedz = 0.0000f;
	public GameObject Armordot;
	//public GameObject Guidancedot;
	public GameObject Gunsdot;
	public GameObject Ramdot;
	public GameObject Rocketdot;
	public GameObject Thrusterdot;
	public GameObject Trackerdot;
	public GameObject Unfuckerdot;
	public GameObject Spotlight;
	private Vector3 Origthrusterpos;
	public GameObject Thrustvectorer;
	private int VTenable = 0;
	public int Champmode=0;
	public int Upgradescreen = 0;
	
	
	
	//private float Oldrotationx = 0;
	//private float Oldrotationy = 0;
	
	
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);

	}
	void OnLevelWasLoaded(int level){
		if (level == 0){
			Destroy(gameObject);
		}
		if (level == 2){
			transform.position = new Vector3(0,0,0);
			GetComponent<Rigidbody>().isKinematic = true;
			GetComponent<Spaceshipstatuscontroller>().enabled = false;
			Upgradescreen = 1;
		}
		if (level == 3){
			transform.position = new Vector3(0, 100, 0);
			transform.eulerAngles = new Vector3(0,0,0);
			GetComponent<Rigidbody>().isKinematic = false;
			GetComponent<Spaceshipstatuscontroller>().enabled = true;
			GetComponent<Obstaclecreator>().enabled=true;
			GetComponent<tunnelcontroller>().enabled=true;
			//GetComponent<CapsuleCollider>().enabled=true;
			Armordot.active=false;
			//Guidancedot.active = false;
			Gunsdot.active = false;
			Ramdot.active = false;
			Rocketdot.active = false;
			Thrusterdot.active = false;
			Origthrusterpos = Thruster.transform.localPosition;
			VTenable = 1;
			GetComponent<Collider>().enabled = true;
			Unfuckerdot.active = false;
			Trackerdot.active = false;
			Upgradescreen = 0;
			
		}
		if (level == 4){
			VTenable = 1;
			Origthrusterpos = Thruster.transform.localPosition;
			CrossSceneVars.Vectoredthrust=1;
			CrossSceneVars.Armorlevel=10000;
		}
	}

	// Use this for initialization
	void Start () {
		if (Champmode ==1){
			VTenable = 1;
			CrossSceneVars.Vectoredthrust=1;
			Origthrusterpos = Thruster.transform.localPosition;
			CrossSceneVars.Armorlevel=10000;
		}
		if (Optionsandstatus.Lighting == 2){
			Spotlight.SetActive( true );
		}
		else{
			Spotlight.SetActive( false );
		}
		//	Thruster = GameObject.Find("Thruster");
		//rigidbody.centerOfMass = new Vector3 (Thruster.transform.position.x, Thruster.transform.position.y, Thruster.transform.position.z+10);
	}
	
	
	// Update is called once per frame
	void Update () {
		if (CrossSceneVars.Paused == 0){
	
			int VTOn=0;
			
		// set rigidbody center of mass to properly calibrate movement
			//rigidbody.centerOfMass = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
			
		// Player rotater
			//normal controls
			if (Optionsandstatus.Inverted == 0){
				if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
					Pitchspeeddown = Pitchbase+Pitchaccel;
					GetComponent<Rigidbody>().AddRelativeTorque(Pitchspeeddown,0,0);
					if (CrossSceneVars.Vectoredthrust==1 && VTenable == 1){
							VTOn = 1;
							Thruster.transform.localPosition = new Vector3(Origthrusterpos.x, Origthrusterpos.y+0.035f, Origthrusterpos.z);
					}
				}
				if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
					Pitchspeedup = Pitchbase+Pitchaccel;
					GetComponent<Rigidbody>().AddRelativeTorque(0-Pitchspeedup, 0, 0);
					if (CrossSceneVars.Vectoredthrust==1 && VTenable ==1){
						Thruster.transform.localPosition = new Vector3(Origthrusterpos.x, Origthrusterpos.y-0.035f, Origthrusterpos.z);
					}
				}
				else{
					if (VTenable == 1){
						if (VTOn ==0){
							if (CrossSceneVars.Vectoredthrust ==1){
								Thruster.transform.localPosition = new Vector3(Thruster.transform.localPosition.x, Origthrusterpos.y, Thruster.transform.localPosition.z);
							}
						}
					}
				}
			}
			// inverted controls
			if (Optionsandstatus.Inverted == 1){
				if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
					Pitchspeeddown = Pitchbase+Pitchaccel;//*holdcountdown;
					GetComponent<Rigidbody>().AddRelativeTorque(Pitchspeeddown,0,0);
					//holdcountdown = holdcountdown + 1.0f;
					if (CrossSceneVars.Vectoredthrust==1 && VTenable == 1){
							VTOn = 1;
							Thruster.transform.localPosition = new Vector3(Origthrusterpos.x, Origthrusterpos.y+0.035f, Origthrusterpos.z);
					}
				}
				if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
					Pitchspeedup = Pitchbase+Pitchaccel;//*holdcountup;
					GetComponent<Rigidbody>().AddRelativeTorque(0-Pitchspeedup, 0, 0);
					//holdcountup = holdcountup + 1;
					if (CrossSceneVars.Vectoredthrust==1 && VTenable ==1){
						Thruster.transform.localPosition = new Vector3(Origthrusterpos.x, Origthrusterpos.y-0.035f, Origthrusterpos.z);
					}
		
				}
				else{ // I think this resets position if not being used
					if (VTenable == 1){
						if (VTOn ==0){
							if (CrossSceneVars.Vectoredthrust ==1){
								Thruster.transform.localPosition = new Vector3(Thruster.transform.localPosition.x, Origthrusterpos.y, Thruster.transform.localPosition.z);
							}
						}
					}
				}
			}
			
			if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
				GetComponent<Rigidbody>().AddRelativeTorque(0, 0, Rollspeed);
			}if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
				GetComponent<Rigidbody>().AddRelativeTorque(0, 0, 0-Rollspeed);
			}
			//vectored thrust only - separate for l/r movement
			if (Input.GetKey(KeyCode.Q)){
				if (CrossSceneVars.Vectoredthrust==1 && VTenable ==1){
					VTOn=1;
					Thruster.transform.localPosition = new Vector3(Origthrusterpos.x+0.035f, Origthrusterpos.y, Origthrusterpos.z);
				}
			}
			if (Input.GetKey(KeyCode.E)){
			    if (CrossSceneVars.Vectoredthrust==1 && VTenable ==1){
					Thruster.transform.localPosition = new Vector3(Origthrusterpos.x-0.035f, Origthrusterpos.y, Origthrusterpos.z);
				}
			}
			else{
				if (VTenable ==1 && VTOn ==0){
					Thruster.transform.localPosition = new Vector3(Origthrusterpos.x, Thruster.transform.localPosition.y, Thruster.transform.localPosition.z);
				}
			}
			Thrustvectorer.transform.LookAt(Thruster.transform.position);
			
		// Backward movement preventer.  Must be less than 90 degress maxroation to work.
			//limitedy += Input.GetAxis("Horizontal");
			if(transform.rotation.eulerAngles.x < 180){
				limitedx = Mathf.Clamp(transform.rotation.eulerAngles.x, 0, 75);
			}
			else{
				limitedx = Mathf.Clamp(transform.rotation.eulerAngles.x, 275, 360);
			}
			if(transform.rotation.eulerAngles.y < 180){
				limitedy = Mathf.Clamp(transform.rotation.eulerAngles.y, 0, 75);
			}
			else{
				limitedy = Mathf.Clamp(transform.rotation.eulerAngles.y, 275, 360);
			}
			//if(transform.rotation.eulerAngles.z < 180){
			//	limitedz = Mathf.Clamp(transform.rotation.eulerAngles.z, 0, 80);
			//}
			//else{
			//	limitedz = Mathf.Clamp(transform.rotation.eulerAngles.z, 280, 360);
			//}
	
			if (Upgradescreen == 0){
				transform.eulerAngles = new Vector3(limitedx, limitedy, transform.rotation.eulerAngles.z);
			}
			
			//Below sorta works, but applying force sucks because leads to weird behavior and inexactness.
			//Maybe can also use spotlight like missile targeter and do that.  But first need to sense world rotation.
			//if(Input.GetKey(KeyCode.E)){
				//transform.position = new Vector3(0,0, -2000);
			//if((transform.rotation.eulerAngles.x > Maxrotation) && (transform.rotation.eulerAngles.x < 180)){
			//	rigidbody.AddRelativeTorque(Pitchbase*500,0,0);
			//	transform.rotation.eulerAngles.x = Oldrotationx;
			//}
			//if((transform.rotation.eulerAngles.x < 360-Maxrotation) && (transform.rotation.eulerAngles.x > 180)){
			//	rigidbody.AddRelativeTorque(0-Pitchbase*500,0,0);
			//	transform.rotation.eulerAngles.x = Oldrotationx;
	
			//}
			//if((transform.rotation.eulerAngles.y > Maxrotation) && (transform.rotation.eulerAngles.y < 180)){
			//	rigidbody.AddRelativeTorque(0,Pitchbase*500,0);
			//	transform.rotation.eulerAngles.y = Oldrotationy;
	
			//}
			//if((transform.rotation.eulerAngles.y < 360-Maxrotation) && (transform.rotation.eulerAngles.y > 180)){
			//	rigidbody.AddRelativeTorque(0,0-Pitchbase*500,0);
			//	transform.rotation.eulerAngles.y = Oldrotationy;
	
			//}
			//Oldrotationx = transform.rotation.eulerAngles.x;
			//Oldrotationy = transform.rotation.eulerAngles.y;
			
		// Thrust booster
			//if(Input.GetKey(KeyCode.LeftShift)){
			//	Boost = 1000;
			//}
			//else{
			//	Boost = 0;
			//}
				
		//Player forward movement
		//	transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+1.0f);
			Vector3 Away_from_thrusters = (transform.position - Thruster.transform.position).normalized; 
			GetComponent<Rigidbody>().AddForce(Away_from_thrusters*(Thrust+Boost));
			float Unispeed = GetComponent<Rigidbody>().velocity.magnitude;
			float Totallift = Lift*Unispeed;
			GetComponent<Rigidbody>().AddRelativeForce (0, 1*Totallift, 0);
		}
		

	}
	
}
