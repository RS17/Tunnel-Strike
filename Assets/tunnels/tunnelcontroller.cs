using UnityEngine;
using System.Collections;

public class tunnelcontroller : MonoBehaviour {
	public GameObject Blanktunnelsection;
	private float Tunnelbuildz = 0.0f;
	public float Builddistance = 10000.0f;
	private Vector3 Tunnelbuildlocation;
	public GameObject Bronzecoin;
	public GameObject Silvercoin;
	public GameObject Goldcoin;
	public float Coindistance = 10.0f;
	public float BCoinmakez = 0;
	public float SCoinmakez = 0;
	public float GCoinmakez = 0;
	public float Distsincelastopp = 0;
		

	// Use this for initialization
	void Start () {
		Vector3 Tunnelbuildlocation = new Vector3(0.0f, 0.0f, 30.0f);
		if (Optionsandstatus.Lighting == 1){                             //this must be put in start for performance reasons - probably should not bother with including in pause options
			Blanktunnelsection = (GameObject)Resources.Load("Blanktunnelsection1"); //must be placed in Assets/Resources folder!!!
		}
		if (Optionsandstatus.Lighting == 2){                             //this must be put in start for performance reasons - probably should not bother with including in pause options
			Blanktunnelsection = (GameObject)Resources.Load("Blanktunnelsection2"); //must be placed in Assets/Resources folder!!!
		}
		if (Optionsandstatus.Lighting == 3){                             //this must be put in start for performance reasons - probably should not bother with including in pause options
			Blanktunnelsection = (GameObject)Resources.Load("Blanktunnelsection3"); //must be placed in Assets/Resources folder!!!
		}
		if (Optionsandstatus.Lighting == 4){                             //this must be put in start for performance reasons - probably should not bother with including in pause options
			Blanktunnelsection = (GameObject)Resources.Load("Blanktunnelsection4"); //must be placed in Assets/Resources folder!!!
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossSceneVars.Paused == 0){
			if((Tunnelbuildz-transform.position.z < Builddistance) && ((transform.position.z < 190000)||CrossSceneVars.Champmode ==1)){
				GameObject Tunnelsection = (GameObject)Instantiate(Blanktunnelsection, Tunnelbuildlocation, Quaternion.identity);
				Tunnelbuildz = Tunnelbuildz + 300.0f;
				Tunnelbuildlocation = new Vector3(0.0f, 0.0f, Tunnelbuildz);
			}
			// coin creator
			if (CrossSceneVars.Champmode == 0 && transform.position.z - Distsincelastopp > Coindistance){
				if(/*(BCoinmakez-transform.position.z < Coindistance)&& */(transform.position.z < 190000) && (Random.Range(1,100)<2)){
					GameObject Coin = (GameObject)Instantiate(Bronzecoin, new Vector3(Random.Range(-130,130),Random.Range(15, 285),transform.position.z+10000), Quaternion.identity);
					//BCoinmakez = BCoinmakez+Coindistance;
				}
				if(/*(SCoinmakez-transform.position.z < Coindistance) && */(transform.position.z < 190000) && (Random.Range(1,500 - transform.position.z/10000)<2)){
					GameObject Coin = (GameObject)Instantiate(Silvercoin, new Vector3(Random.Range(-130,130),Random.Range(15, 285),transform.position.z+10000), Quaternion.identity);
					//SCoinmakez = SCoinmakez+Coindistance;
				}
				if(/*(GCoinmakez-transform.position.z < Coindistance) && */(transform.position.z < 190000) && (Random.Range(1,1000-(transform.position.z/10000))<2)){
					GameObject Coin = (GameObject)Instantiate(Goldcoin, new Vector3(Random.Range(-130,130),Random.Range(15, 285),transform.position.z+10000), Quaternion.identity);
					//GCoinmakez = GCoinmakez+Coindistance;
				}
				Distsincelastopp = transform.position.z;
				
				
			}
		}
				
	}
}
