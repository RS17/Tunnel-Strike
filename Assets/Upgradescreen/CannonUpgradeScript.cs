using UnityEngine;
using System.Collections;

public class CannonUpgradeScript : MonoBehaviour {
	
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
			UpgradeGUI.LastMessage = "Plasma cannons can destroy most objects in the tunnel, or simply push them out of the way.  Larger cannons have a higher rate of fire and shoot plasma that is faster and more destructive.  Your ship comes with small plasma cannons.";
		}
		
		
		//render 3d text
	}
	// Update is called once per frame
	void Update () {
		//UpgradeGUI upgradegui = GetComponent<UpgradeGUI>();
		//upgradegui.Money = 5000;
		//UpgradeGUI upgradegui = GetComponent<UpgradeGUI>();
		transform.eulerAngles = new Vector3(0,0,0);
		transform.position = new Vector3(rocketdot.transform.position.x-1, rocketdot.transform.position.y-.2f, rocketdot.transform.position.z);
		//renderer.material.color = Color.white;
	}
}
