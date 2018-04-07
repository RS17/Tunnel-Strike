using UnityEngine;
using System.Collections;

public class Magnetupgradescript : MonoBehaviour {


	public GameObject trackerdot;
	public GameObject magnet;
	public int Price = 0;
	public int Armorlevel = 0;

	void OnMouseEnter (){
		GetComponent<Renderer>().material.color = Color.yellow;
		//print("mouseover detected");
	}
	void OnMouseExit (){
		GetComponent<Renderer>().material.color = Color.white;
	}
	void OnMouseDown (){
		if (CrossSceneVars.CoinMagnet == 0){
			if (CrossSceneVars.Money >=Price){
				CrossSceneVars.Money = CrossSceneVars.Money - Price;
				UpgradeGUI.LastMessage = "Coin magnet purchased";
				CrossSceneVars.CoinMagnet = 1;
			}
			else{
				UpgradeGUI.LastMessage = "Not enough money";
			}
		}
		else{
			UpgradeGUI.LastMessage = "Magnet already purchased.";
		}
		if (CrossSceneVars.CoinMagnet == 1){
			magnet.active = true;
			gameObject.active = false;
		}
	}
}