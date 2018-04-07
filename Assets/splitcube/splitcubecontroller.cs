using UnityEngine;
using System.Collections;

public class splitcubecontroller : MonoBehaviour {
	// this should be a universal script
	// so if gets hit, should be replaced by next lower splitcube, which will be public object
	// then this can be attached to each subcube in the splitcube object - so a hit to a subcube
	// replaces that subcube with the lower splitcube, which will be of the same size as the subcube.
	public GameObject lowercube;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter (){
		Destroy(gameObject);
		GameObject splitcube = (GameObject)Instantiate(lowercube, transform.position, Quaternion.identity);
	}
}
