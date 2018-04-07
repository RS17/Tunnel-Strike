using UnityEngine;
using System.Collections;

public class titanarmorupgradescript : MonoBehaviour {
	
	public GameObject rocketdot;
	public GameObject spaceship;
	public Material titanarmor;
	public int Price = 0;
	public int Armorlevel = 0;
	public GameObject steelarmorup;
	public GameObject alumarmorup;
	

	void OnMouseEnter (){
		GetComponent<Renderer>().material.color = Color.yellow;
		//print("mouseover detected");
	}
	void OnMouseExit (){
		GetComponent<Renderer>().material.color = Color.white;
	}
	void OnMouseDown (){
		if (CrossSceneVars.Armor3 == 0){
			if (CrossSceneVars.Money >= Price){
				CrossSceneVars.Money = CrossSceneVars.Money - Price;
				UpgradeGUI.LastMessage = "Titanium armor purchased";
				CrossSceneVars.Armor3 = 1;
				CrossSceneVars.Armor = 3;
			}
			else{
				UpgradeGUI.LastMessage = "Not enough money";
			}
		}
		else{
			UpgradeGUI.LastMessage = "Switched to titanium armor (already purchased)";
			CrossSceneVars.Armor = 3;
		}
		if (CrossSceneVars.Armor == 3){
			CrossSceneVars.Armorlevel = Armorlevel;
			spaceship.GetComponent<Renderer>().material = titanarmor;
			steelarmorup.active = false;
			alumarmorup.active=false;
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
