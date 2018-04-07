using UnityEngine;
using System.Collections;

public class coincontroller : MonoBehaviour {
	
	public int coinvalue;
	public GameObject grabeffect;
	public float rotaterate = 20;
	public int flash = 0;
	public Texture Green;
	private float Starttime = 100000000;
	public int grabbed = 0;
		
	void OnGUI(){
		if (flash == 1){
			//GUI.Label(new Rect(20,20,100,20), Green);
			GUI.DrawTexture(new Rect(20,20,100,20), Green, ScaleMode.ScaleAndCrop, true, 0);
		}
	}
	
	void Start () {
		Green = (Texture)Resources.Load("Green");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.left * Time.deltaTime * rotaterate);
		if (Time.time - Starttime > .2){
			Destroy(gameObject);
		}
	}
	public void OnTriggerEnter(Collider collider){
		//if (collider.gameObject.tag == "Player"){
		if (grabbed == 0){
			CrossSceneVars.Money = CrossSceneVars.Money+coinvalue;
			Instantiate(grabeffect, transform.position, Quaternion.identity);
			flash = 1;
			Starttime = Time.time;
			grabbed = 1;
		}
			
		//}

	}
	
}
