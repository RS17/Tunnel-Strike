using UnityEngine;
using System.Collections;

public class chainguncontroller : MonoBehaviour {
	
	//no longer used
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W)){
			transform.Rotate(0,0,1);
		}
		if (Input.GetKey(KeyCode.S)){
			transform.Rotate(0,0,-1);
		}
		if (Input.GetKey(KeyCode.A)){
			transform.Rotate(-1,0,0);
		}
		if (Input.GetKey(KeyCode.D)){
			transform.Rotate(1,0,0);
		}
		
	
	}
}
