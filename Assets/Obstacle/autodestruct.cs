using UnityEngine;
using System.Collections;

public class autodestruct : MonoBehaviour {
	public int lifespan = 3;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, lifespan);
		
	
	}
	
	// Update is called once per frame
	void Update () {

	}
}
