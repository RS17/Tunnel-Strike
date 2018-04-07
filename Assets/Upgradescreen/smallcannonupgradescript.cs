using UnityEngine;
using System.Collections;

public class smallcannonupgradescript : MonoBehaviour {
	
	public GameObject rocketdot;
	public GameObject mcannonleft;
	public GameObject mcannonright;
	public GameObject scannonleft;
	public GameObject scannonright;
	public GameObject lcannonleft;
	public GameObject lcannonright;
	public GameObject mcannonup;
	public GameObject lcannonup;
	public int Price = 5000;

	void OnMouseEnter (){
		GetComponent<Renderer>().material.color = Color.yellow;
		//print("mouseover detected");
	}
	void OnMouseExit (){
		GetComponent<Renderer>().material.color = Color.white;
	}
	void OnMouseDown (){
		if (CrossSceneVars.Guns1 == 0){
			if (CrossSceneVars.Money >= Price){
				CrossSceneVars.Money = CrossSceneVars.Money - Price;
				UpgradeGUI.LastMessage = "Switched to small cannon";
				CrossSceneVars.Guns1 = 1;
				CrossSceneVars.Guns = 1;
			}
			else{
				UpgradeGUI.LastMessage = "Not enough money";
			}
		}
		else{
			UpgradeGUI.LastMessage = "Switched to small cannon";
			CrossSceneVars.Guns = 1;
		}
		if(CrossSceneVars.Guns == 1){
		//will need to add removal of other objects
			scannonleft.active=true;
			scannonright.active=true;
			mcannonleft.active=false;
			mcannonright.active=false;
			lcannonleft.active=false;
			lcannonright.active=false;
			mcannonup.active =false;
			lcannonup.active = false;
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
