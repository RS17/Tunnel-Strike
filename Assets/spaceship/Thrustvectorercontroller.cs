using UnityEngine;
using System.Collections;

public class Thrustvectorercontroller : MonoBehaviour {
	public GameObject Thruster;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(Thruster.transform.position);//Thruster.transform.position);
		//make sure VTenable and crossscenevars set properly
	
	}
}
