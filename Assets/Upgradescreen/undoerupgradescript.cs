using UnityEngine;
using System.Collections;

public class undoerupgradescript : MonoBehaviour {

	
	public GameObject undoerdot;
	public GameObject Undoer;
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
			if (CrossSceneVars.Undoeractive == 0){ // this is going to cause problems becuase want to apply for Undoer too.
				if (CrossSceneVars.Money >= Price){
					CrossSceneVars.Money = CrossSceneVars.Money - Price;
					UpgradeGUI.LastMessage = "Reorientator purchased for $2500";
					CrossSceneVars.Undoer = 1;
					CrossSceneVars.Undoeractive = 1;
				}
				else{
					UpgradeGUI.LastMessage = "Not enough money.";
				}
			}
			else{
				UpgradeGUI.LastMessage = "Reorientator activated (already purchased)";
				CrossSceneVars.Undoeractive = 1;
				
			}
		if (CrossSceneVars.Undoeractive == 1){ 
		    Undoer.active = true;
			gameObject.active = false;
		}
	}
	//}
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3(0,0,0);
		transform.position = new Vector3(undoerdot.transform.position.x-1, undoerdot.transform.position.y-position, undoerdot.transform.position.z);
		//renderer.material.color = Color.white;
	}
	
}
