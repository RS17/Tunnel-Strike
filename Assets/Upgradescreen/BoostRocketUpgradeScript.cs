using UnityEngine;
using System.Collections;

public class BoostRocketUpgradeScript : MonoBehaviour {
	
	public GameObject rocketdot;
	public GameObject LargeRocket;
	public GameObject MediumRocket;
	public GameObject SmallRocket;
	//public static int Money;
	
	void Start(){
		GetComponent<Renderer>().material.color = Color.green;
	}

	void OnMouseEnter (){
		GetComponent<Renderer>().material.color = Color.yellow;
		//print("mouseover detected");
	}
	void OnMouseExit (){
		GetComponent<Renderer>().material.color = Color.green;
	}
	void OnMouseDown (){
		if(LargeRocket.active == true){
			LargeRocket.active = false;
			MediumRocket.active = false;
			SmallRocket.active = false;
		}
		else{	
			LargeRocket.active = true;
			MediumRocket.active = true;
			SmallRocket.active = true;
			UpgradeGUI.LastMessage = "Boost rockets speed up your ship to get past laser turrets quickly and escape missiles.  Larger rockets have more power and more fuel.  Use boost rockets by pressing the space bar or Z.  Your ship comes with very small rockets.";
		}
		
		
		//render 3d text
	}
	// Update is called once per frame
	void Update () {
		//UpgradeGUI upgradegui = GetComponent<UpgradeGUI>();
		//upgradegui.Money = 5000;
		//UpgradeGUI upgradegui = GetComponent<UpgradeGUI>();
		transform.eulerAngles = new Vector3(0,0,0);
		transform.position = new Vector3(rocketdot.transform.position.x-1, rocketdot.transform.position.y+1, rocketdot.transform.position.z);
		//renderer.material.color = Color.white;
	}
}
