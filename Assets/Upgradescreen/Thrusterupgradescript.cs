using UnityEngine;
using System.Collections;

public class Thrusterupgradescript : MonoBehaviour {
	
	public GameObject thrusterdot;
	public GameObject VectoredThrust;
	public float position = 1;
	public string message;

	void Start(){
		GetComponent<Renderer>().material.color = Color.green;
	}

	void OnMouseEnter (){
		GetComponent<Renderer>().material.color = Color.yellow;
		//print("mouseover detected");
	}
	void OnMouseExit (){
		GetComponent<Renderer>().material.color = Color.green;
	}
	void OnMouseDown (){
		if(VectoredThrust.active == true){
			VectoredThrust.active = false;
		}
		else{	
			VectoredThrust.active = true;
			UpgradeGUI.LastMessage = message;//"Thrust vectoring makes your ship much easier to control.  It will automatically push your ship upward or downward when you use W and S, or you can use Q and E to strafe left or right.";
		}
		
		
	}
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3(0,0,0);
		transform.position = new Vector3(thrusterdot.transform.position.x-1, thrusterdot.transform.position.y-position, thrusterdot.transform.position.z);
		//renderer.material.color = Color.white;
	}
}
