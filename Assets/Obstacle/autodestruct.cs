using UnityEngine;
using System.Collections;

public class autodestruct : MonoBehaviour {
	private float Starttime;

	// Use this for initialization
	void Start () {
		Starttime = Time.time;
		
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - Starttime > 3){
			Destroy(gameObject);
		}
	
	}
}
