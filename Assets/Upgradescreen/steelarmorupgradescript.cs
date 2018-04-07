using UnityEngine;
using System.Collections;

public class steelarmorupgradescript : MonoBehaviour {
	
	public GameObject rocketdot;
	public GameObject spaceship;
	public Material steelarmor;
	public int Price = 0;
	public int Armorlevel = 0;
	public GameObject alumarmorup;
	public GameObject titanarmorup;

	void OnMouseEnter (){
		GetComponent<Renderer>().material.color = Color.yellow;
		//print("mouseover detected");
	}
	void OnMouseExit (){
		GetComponent<Renderer>().material.color = Color.white;
	}
	void OnMouseDown (){
		if (CrossSceneVars.Armor1 == 0){
			if (CrossSceneVars.Money >=Price){
				CrossSceneVars.Money = CrossSceneVars.Money - Price;
				UpgradeGUI.LastMessage = "Steel armor purchased";
				CrossSceneVars.Armor = 1;
				CrossSceneVars.Armor1 = 1;
			}
			else{
				UpgradeGUI.LastMessage = "Not enough money";
			}
		}
		else{
			UpgradeGUI.LastMessage = "Switched to steel armor (already purchased)";
			CrossSceneVars.Armor = 1;
		}
		if (CrossSceneVars.Armor == 1){
			CrossSceneVars.Armorlevel = Armorlevel;
			spaceship.GetComponent<Renderer>().material = steelarmor;
			alumarmorup.active=false;
			titanarmorup.active=false;
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
