using UnityEngine;
using System.Collections;

public class mediumrocketupgradescript : MonoBehaviour {
	
	public GameObject rocketdot;
	public GameObject mrocket;
	public GameObject mrocketleft;
	public GameObject mrocketright;
	public GameObject srocket;
	public GameObject srocketleft;
	public GameObject srocketright;
	public GameObject lrocket;
	public GameObject lrocketleft;
	public GameObject lrocketright;
	public GameObject srocketup;
	public GameObject lrocketup;
	public int Price = 1000;

	void OnMouseEnter (){
		GetComponent<Renderer>().material.color = Color.yellow;
		//print("mouseover detected");
	}
	void OnMouseExit (){
		GetComponent<Renderer>().material.color = Color.white;
	}
	void OnMouseDown (){
		if (CrossSceneVars.Rocket2 == 0){ //if not already purchased
			if (CrossSceneVars.Money >= Price){
				CrossSceneVars.Money = CrossSceneVars.Money - Price;
				CrossSceneVars.Rocket2 = 1;
				UpgradeGUI.LastMessage = "Medium rocket purchased for $1000";
				CrossSceneVars.Rocket = 2;
			}
			else{
				UpgradeGUI.LastMessage = "Not enough money";
			}
		}
		else{
			UpgradeGUI.LastMessage = "Switched to medium rocket (already purchased)";
			CrossSceneVars.Rocket = 2;
		}
		if (CrossSceneVars.Rocket == 2){
		//remove other rockets, then add this one
			srocket.active = false;
			srocketleft.active=false;
			srocketright.active=false;
			lrocket.active = false;
			lrocketleft.active=false;
			lrocketright.active=false;
			mrocket.active = true;
			mrocketleft.active=true;
			mrocketright.active=true;
			srocketup.active = false;
			lrocketup.active = false;
			gameObject.active = false;
		}
		
	}
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3(0,0,0);
		//transform.position = new Vector3(rocketdot.transform.position.x-1, rocketdot.transform.position.y+2, rocketdot.transform.position.z);
		//renderer.material.color = Color.white;
	}
	
}
