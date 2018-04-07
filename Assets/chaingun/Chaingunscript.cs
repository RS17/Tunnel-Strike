using UnityEngine;
using System.Collections;

public class Chaingunscript : MonoBehaviour {
	public int Rotationrate = 10000; //should be in rounds per minute
	public float prevtime = 0;
	public static int fired;
	public int Maxrotation = 1000;  //4200 is GAU avenger
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space) && shootercontroller.RoundsPerMinute < Maxrotation){
			GetComponent<Rigidbody>().AddRelativeTorque(0, Rotationrate/10, 0);
			//transform.Rotate(0, Rotationrate*((Time.time-prevtime)/360)*360, 0); //idea is one 1000 1/6th rotations every minute
		} 
	}
	
}
