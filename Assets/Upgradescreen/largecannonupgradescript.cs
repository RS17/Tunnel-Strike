using UnityEngine;
using System.Collections;

public class largecannonupgradescript : MonoBehaviour {
	
	public GameObject rocketdot;
	public GameObject mcannonleft;
	public GameObject mcannonright;
	public GameObject scannonleft;
	public GameObject scannonright;
	public GameObject lcannonleft;
	public GameObject lcannonright;
	public GameObject smallcannonup;
	public GameObject medcannonup;
	public int Price = 5000;
	

	void OnMouseEnter (){
		GetComponent<Renderer>().material.color = Color.yellow;
		//print("mouseover detected");
	}
	void OnMouseExit (){
		GetComponent<Renderer>().material.color = Color.white;
	}
	void OnMouseDown (){
		if (CrossSceneVars.Guns3 == 0){
			if (CrossSceneVars.Money >= Price){
				CrossSceneVars.Money = CrossSceneVars.Money - Price;
				UpgradeGUI.LastMessage = "Large cannon purchased for $6000";
				CrossSceneVars.Guns = 3;
				CrossSceneVars.Guns3 = 1;
			}
			else{
				UpgradeGUI.LastMessage = "Not enough money";
			}
		}
		else{
			UpgradeGUI.LastMessage = "Switched to large cannon (already purchased)";
			CrossSceneVars.Guns = 3;
		}
		if (CrossSceneVars.Guns == 3){
			scannonleft.active=false;
			scannonright.active=false;
			mcannonleft.active=false;
			mcannonright.active=false;
			lcannonleft.active=true;
			lcannonright.active=true;
			smallcannonup.active = false;
			medcannonup.active = false;
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
