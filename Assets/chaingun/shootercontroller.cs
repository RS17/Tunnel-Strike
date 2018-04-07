using UnityEngine;
using System.Collections;

public class shootercontroller : MonoBehaviour {
	public GameObject Muzzleflash;
	public GameObject Bullet;
	public GameObject exitpoint;
	public int Velocity;
	public static float RoundsPerMinute = 0;
	public float lasttime = 0;
	public float RPM;
	public int gunfired = 0;
	

	// Use this for initialization
	void Start () {
	
	} 
	
	// Update is called once per frame
	void Update () {
	//	if (Time.time - lasttime >= 1){
		//	RoundsPerMinute = 0;
		//	lasttime = Time.time;
//		}
		
		RoundsPerMinute =  60/(Time.time-lasttime);
		RPM = RoundsPerMinute;
	}
	void OnTriggerEnter(){
		if (Input.GetKey(KeyCode.Space)){
			lasttime = Time.time;
			Vector3 Exitpoint = exitpoint.transform.position;
			GameObject flash = (GameObject)Instantiate(Muzzleflash, Exitpoint, transform.rotation);
			GameObject bullet = (GameObject)Instantiate(Bullet, Exitpoint, transform.rotation);
			bullet.GetComponent<Rigidbody>().AddRelativeForce(0,Velocity,0);
			gunfired = 1;
		}
	}
}
