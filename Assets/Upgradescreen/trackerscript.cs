using UnityEngine;
using System.Collections;

public class trackerscript : MonoBehaviour {


	public GameObject trackerdot;
	public GameObject tracker;
	public int Price = 0;
	public int Armorlevel = 0;
	public float Clicktime = 0;

	void OnMouseEnter (){
		GetComponent<Renderer>().material.color = Color.yellow;
		//print("mouseover detected");
	}
	void OnMouseExit (){
		GetComponent<Renderer>().material.color = Color.white;
	}
	void OnMouseDown (){
		if (Time.time - Clicktime > 1){
			if (CrossSceneVars.Missiletracker == 0){
				if (CrossSceneVars.Money >=Price){
					CrossSceneVars.Money = CrossSceneVars.Money - Price;
					UpgradeGUI.LastMessage = "Missile tracker purchased";
					CrossSceneVars.Missiletracker = 1;
				}
				else{
					UpgradeGUI.LastMessage = "Not enough money";
				}
			}
			else{
				UpgradeGUI.LastMessage = "Missile tracker already purchased.";
			}
			if (CrossSceneVars.Missiletracker == 1){
				tracker.active = true;
				gameObject.active = false;
			}
			Clicktime = Time.time;
		}
	}
}