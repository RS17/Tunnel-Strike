using UnityEngine;
using System.Collections;

public class Undoerscript : MonoBehaviour {
	public GameObject spaceship;
	public int Undos = 5;
	private int Changetime = 0;

	// Use this for initialization
	void OnGUI () {
		
		GUI.Label(new Rect(20,200,250,25), System.String.Format("Reorients Remaining: {0}", Undos));
	}
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Tab) && Undos >0 && Changetime >25 && CrossSceneVars.Upgrademode == 0){ 
			spaceship.transform.position = new Vector3(0, 100, spaceship.transform.position.z);
			spaceship.transform.eulerAngles = new Vector3(0,0,0);
			Undos--;
			Changetime = 0;
		}
		Changetime++;
	
	}
}
