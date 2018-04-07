using UnityEngine;
using System.Collections;

public class largerocketupgradescript : MonoBehaviour {
	
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
	public GameObject smallrocketup; 
	public GameObject medrocketup;
	public int Price = 5000;

	void OnMouseEnter (){
		GetComponent<Renderer>().material.color = Color.yellow;
		//print("mouseover detected");
	}
	void OnMouseExit (){
		GetComponent<Renderer>().material.color = Color.white;
	}
	void OnMouseDown (){
		if (CrossSceneVars.Rocket3 == 0){
			if (CrossSceneVars.Money >= Price){
				CrossSceneVars.Money = CrossSceneVars.Money - Price;
				UpgradeGUI.LastMessage = "Large rocket purchased for $4000";
				CrossSceneVars.Rocket3 = 1;
				CrossSceneVars.Rocket = 3;
			}
			else{
				UpgradeGUI.LastMessage = "Not enough money";
			}
		}
		else{
			UpgradeGUI.LastMessage = "Switched to large rocket (already purchased)";
			CrossSceneVars.Rocket = 3;
		}
		//will need to add removal of other objects
		if (CrossSceneVars.Rocket == 3){
			srocket.active = false;
			srocketleft.active=false;
			srocketright.active=false;
			mrocket.active = false;
			mrocketleft.active=false;
			mrocketright.active=false;
			lrocket.active = true;
			lrocketleft.active=true;
			lrocketright.active=true;
			smallrocketup.active = false;
			medrocketup.active = false;
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
