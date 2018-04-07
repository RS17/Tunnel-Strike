using UnityEngine;
using System.Collections;

public class alumarmorupgradescript : MonoBehaviour {
	
	public GameObject rocketdot;
	public GameObject spaceship;
	public Material alumarmor;
	public int Price = 0;
	public int Armorlevel = 0;
	public GameObject steelupgrade;
	public GameObject titanupgrade;
	
	void Start (){

	}
		

	void OnMouseEnter (){
		GetComponent<Renderer>().material.color = Color.yellow;
		//print("mouseover detected");
	}
	void OnMouseExit (){
		GetComponent<Renderer>().material.color = Color.white;
	}
	void OnMouseDown (){
		if (CrossSceneVars.Armor2 == 0){
			if (CrossSceneVars.Money >= Price){
				CrossSceneVars.Money = CrossSceneVars.Money - Price;
				UpgradeGUI.LastMessage = "Aluminum armor purchased";
				CrossSceneVars.Armor = 2;
				CrossSceneVars.Armor2 = 1;
			}
			else{
				UpgradeGUI.LastMessage = "Not enough money";
			}
		}
		else{
			UpgradeGUI.LastMessage = "Switched to aluminum armor (already purchased)";
			CrossSceneVars.Armor = 2;
		}		
		if (CrossSceneVars.Armor == 2){
			CrossSceneVars.Armorlevel = Armorlevel;
			spaceship.GetComponent<Renderer>().material = alumarmor;
			steelupgrade.active = false;
			titanupgrade.active = false;
			gameObject.active =  false;
		}
	}
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3(0,0,0);
		//transform.position = new Vector3(rocketdot.transform.position.x-1, rocketdot.transform.position.y+2, rocketdot.transform.position.z);
		//renderer.material.color = Color.white;
	}
	
}
