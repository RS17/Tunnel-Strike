using UnityEngine;
using System.Collections;

public class Magnetcontroller : MonoBehaviour {
	
	public int magsize = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Collider[] colliders = Physics.OverlapSphere(transform.position, magsize);
		foreach (Collider hit in colliders){
			if (hit.tag == "Coin"){
				hit.transform.LookAt(new Vector3(transform.position.x, transform.position.y, hit.transform.position.z));
				//Vector3 Dirtomagnet = new Vector3(1/(transform.position.x - hit.transform.position.x), 1/(transform.position.y - hit.transform.position.y), 1/(transform.position.z - hit.transform.position.z));
				float magdist = Vector3.Distance (hit.transform.position, transform.position);
				hit.GetComponent<Rigidbody>().AddRelativeForce (Vector3.forward*(1/magdist)*1000000);
				//Vector3 Dirtomagnet = new Vector3(1/(transform.position.x - hit.transform.position.x), 1/(transform.position.y - hit.transform.position.y), 1/(transform.position.z - hit.transform.position.z));
				//float magdist = Mathf.Abs(Dirtomagnet.x) + Mathf.Abs(Dirtomagnet.y) +Mathf.Abs(Dirtomagnet.z);			
				//hit.rigidbody.AddForce(Dirtomagnet*(magdist*3000));  //strange results, probably only works on initial hit	
			}
		}
	}
}
