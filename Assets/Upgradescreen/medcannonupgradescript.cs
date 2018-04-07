using UnityEngine;
using System.Collections;

public class medcannonupgradescript : MonoBehaviour {
	
	public GameObject gunsdot;
	public GameObject mcannonleft;
	public GameObject mcannonright;
	public GameObject scannonleft;
	public GameObject scannonright;
	public GameObject lcannonleft;
	public GameObject lcannonright;
	public GameObject lcannonup;
	public GameObject scannonup;
	public int Price = 5000;

	void OnMouseEnter (){
		GetComponent<Renderer>().material.color = Color.yellow;
		//print("mouseover detected");
	}
	void OnMouseExit (){
		GetComponent<Renderer>().material.color = Color.white;
	}
	void OnMouseDown (){
		if (CrossSceneVars.Guns2 == 0){
			if (CrossSceneVars.Money >= Price){
				CrossSceneVars.Money = CrossSceneVars.Money - Price;
				UpgradeGUI.LastMessage = "Medium cannon purchased for $1500";
				CrossSceneVars.Guns2 = 1;
				CrossSceneVars.Guns = 2;
			}
			else{
				UpgradeGUI.LastMessage = "Not enough money";
			}
		}
		else{
			UpgradeGUI.LastMessage = "Switched to large cannon (already purchased)";
			CrossSceneVars.Guns = 2;
		}
		if (CrossSceneVars.Guns == 2){
			scannonleft.active=false;
			scannonright.active=false;
			mcannonleft.active=true;
			mcannonright.active=true;
			lcannonleft.active=false;
			lcannonright.active=false;
			scannonup.active = false;
			lcannonup.active=false;
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
