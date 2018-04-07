using UnityEngine;
using System.Collections;

public class Vectoredthrustupgradescript : MonoBehaviour {
	
	//this is also used for the unfucker which was really lazy and was probably a bad idea in hindsight.  So Thrustvectorer also is unfucker.
	
	public GameObject thrusterdot;
	public GameObject Thrustvectorer;
	public GameObject Surfcurve;
	public int Price;
	public float position = 1.5f;
	public int type = 1;
 
	void OnMouseEnter (){
		GetComponent<Renderer>().material.color = Color.yellow;
		//print("mouseover detected");
	}
	void OnMouseExit (){
		GetComponent<Renderer>().material.color = Color.white;
	}
	void OnMouseDown (){
			//if (type == 1){
			if (CrossSceneVars.Vectoredthrust == 0){ // this is going to cause problems becuase want to apply for Unfucker too.
				if (CrossSceneVars.Money >= Price){
					CrossSceneVars.Money = CrossSceneVars.Money - Price;
					if (type == 1){
						CrossSceneVars.Vectoredthrust = 1;
						UpgradeGUI.LastMessage = "Vectored thrust purchased for $8000";
						CrossSceneVars.Vectoredthrustactive = 1;
					}
				}
				else{
					UpgradeGUI.LastMessage = "Not enough money.";
				}
			}
			else{
				UpgradeGUI.LastMessage = "Switched to vectored thrust (already purchased)";
				CrossSceneVars.Vectoredthrustactive = 1;
				
			}
		if (CrossSceneVars.Vectoredthrustactive == 1){
			
			Thrustvectorer.active = true;
			//Surfcurve.active = true;
			CrossSceneVars.Vectoredthrustactive = 1;
			gameObject.active=false;
		}	
	}
	//}
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3(0,0,0);
		transform.position = new Vector3(thrusterdot.transform.position.x-1, thrusterdot.transform.position.y-position, thrusterdot.transform.position.z);
		//renderer.material.color = Color.white;
	}
	
}
