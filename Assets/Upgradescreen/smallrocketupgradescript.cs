using UnityEngine;
using System.Collections;

public class smallrocketupgradescript : MonoBehaviour {
	
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
	public GameObject mrocketup;
	public GameObject lrocketup;
	public int Price = 200;

	void OnMouseEnter (){
		GetComponent<Renderer>().material.color = Color.yellow;
		//print("mouseover detected");
	}
	void OnMouseExit (){
		GetComponent<Renderer>().material.color = Color.white;
	}
	void OnMouseDown (){
		if (CrossSceneVars.Rocket1 == 0){
			if (CrossSceneVars.Money >= Price){
				CrossSceneVars.Money = CrossSceneVars.Money - Price;
				CrossSceneVars.Rocket1 = 1;
				UpgradeGUI.LastMessage = "Small rocket purchased for $200";
				CrossSceneVars.Rocket = 1;
			}
			else{
				UpgradeGUI.LastMessage = "Not enough money";
			}
		}
		else{
			UpgradeGUI.LastMessage = "Switched to small rocket (already purchased)";
			CrossSceneVars.Rocket = 1;
		}
		//will need to add removal of other objects
		if (CrossSceneVars.Rocket ==1){
			mrocket.active = false;
			mrocketleft.active=false;
			mrocketright.active=false;
			lrocket.active = false;
			lrocketleft.active=false;
			lrocketright.active=false;
			srocket.active = true;
			srocketleft.active=true;
			srocketright.active=true;
			mrocketup.active=false;
			lrocketup.active=false;
			gameObject.active=false;
		}
		
	}
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3(0,0,0);
		//transform.position = new Vector3(rocketdot.transform.position.x-1, rocketdot.transform.position.y+2, rocketdot.transform.position.z);
		//renderer.material.color = Color.white;
	}
	
}
