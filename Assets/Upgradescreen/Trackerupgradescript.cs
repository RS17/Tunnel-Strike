using UnityEngine;
using System.Collections;

public class Trackerupgradescript : MonoBehaviour {
	
	public GameObject trackerdot;
	public GameObject tracker;
	public string message;
	public float ypos;
	
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
		if (tracker.active == true){
			tracker.active = false;
		}
		else{
			tracker.active = true;
			UpgradeGUI.LastMessage = message;//"The missile tracker will make missiles in the tunnel show up as a dot on the front-facing view. As the missile gets closer, the dot will turn red.";
		}
	}
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3(0,0,0);
		transform.position = new Vector3(trackerdot.transform.position.x-1, trackerdot.transform.position.y+ypos, trackerdot.transform.position.z);
		//renderer.material.color = Color.white;
	}
	
}
