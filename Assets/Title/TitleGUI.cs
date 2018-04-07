using UnityEngine;
using System.Collections;

public class TitleGUI : MonoBehaviour {
	public GameObject Optionsandstatusholder;
	public int Qlevel;
	public int Opscreenon;

	
	// OnGUI is called once per frame
	void OnGUI () {
		if(GUI.Button(new Rect(65,410,200,30), "START")){
			Application.LoadLevel(1);
		}
		if(GUI.Button(new Rect(275,410,200,30), "OPTIONS")){
			if (Opscreenon == 0){
				Optionsandstatus.Optionsscreenactive = 1;
				Opscreenon = 1;
			}
			else{
				Optionsandstatus.Optionsscreenactive = 0;
				Opscreenon = 0;
			}
		}
		if (CrossSceneVars.Developmode ==1 || Optionsandstatus.Champmodeunlocked == 1){
			if(GUI.Button(new Rect(485,410,200,30), "CHAMPION MODE")){
				Application.LoadLevel(4);
			}
		}
		else{
			GUI.Box(new Rect(485,410,200,30), "CHAMPION MODE (LOCKED)");
			GUI.Label(new Rect(515, 440, 200, 30), "Blow up core to unlock");
		}
		
	
	}
	void Start () {
		Qlevel = Optionsandstatus.Maxquality;
		if (Qlevel == 1){
			QualitySettings.currentLevel = QualityLevel.Fastest;
		}
		if (Qlevel == 2){
			QualitySettings.currentLevel = QualityLevel.Fast;
		}
		if (Qlevel == 3){
			QualitySettings.currentLevel = QualityLevel.Simple;
		}
		if (Qlevel == 4){
			QualitySettings.currentLevel = QualityLevel.Good;
		}
		if (Qlevel == 5){
			QualitySettings.currentLevel = QualityLevel.Beautiful;
		}
		if (Qlevel == 6){
			QualitySettings.currentLevel = QualityLevel.Fantastic;
		}
		if (GameObject.FindGameObjectWithTag("OAS")){
			//Instantiate(CrossSceneVarHolder, new Vector3(0,0,0), Quaternion.identity);
		}

		else{
			Instantiate(Optionsandstatusholder, new Vector3(0,0,0), Quaternion.identity);
		}
	}
}
