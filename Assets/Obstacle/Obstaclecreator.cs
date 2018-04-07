using UnityEngine;
using System.Collections;

public class Obstaclecreator : MonoBehaviour {
	
	public GameObject Obstacleprefab;
	public GameObject Laserturret;
	public GameObject Missileturret;
	public GameObject hcyl;
	public GameObject Coreexplosion;
	public float Lastspawndist=0.0f;
	public float Obstaclerate = 1000.0f;
	private Quaternion Turretrotationinit = new Quaternion(90.0f, 90.0f, 0, 0);
	private Quaternion Horizcolrotation = new Quaternion(90,90,0,0);
	public GameObject Core;
	public float blastspeed = 100;
	public float Obstacledist = 5000;
	// Use this for initialization
	void Start () {
	
	}	
	// Update is called once per frame
	void Update () {
		if (transform.position.z >= 80000){
			Obstaclerate = 150;
		}
		else if (transform.position.z >= 60000){
			Obstaclerate = 250;
		}
		else if (transform.position.z >= 40000){
			Obstaclerate = 350;
		}
		else if (transform.position.z >= 20000){
			Obstaclerate = 450;
		}
		else{
			Obstaclerate = 2000;
		}

			
		float currentdist = transform.position.z;
		if (((currentdist - Lastspawndist) > Obstaclerate) && (currentdist <190000.0f)){
			float Obstacletype = (Mathf.Abs(Random.Range(1,5)));//2nd range number is 1 higher than number of obstacles
			if(Obstacletype == 1){
				Vector3 Obstacleposition = new Vector3(Random.Range(-135,135), 30.0f, transform.position.z+Obstacledist);
				GameObject vcol = (GameObject)Instantiate(Obstacleprefab, Obstacleposition, Quaternion.identity);
			}
			if(Obstacletype == 2){
				float Turretposx = (Mathf.Abs(Random.Range(0,2))*300)-150;
				Vector3 Obstacleposition = new Vector3(Turretposx, 150.0f, transform.position.z+Obstacledist);
				Quaternion Turretrotation = Turretrotationinit;
				if(Turretposx > 0){
					Turretrotation.x = -90.0f;
				}
				GameObject Lturr = (GameObject)Instantiate(Laserturret, Obstacleposition, Turretrotation);
			}
			if(Obstacletype == 3){
				float Turretposx = (Mathf.Abs(Random.Range(0,2))*300)-150;
				Vector3 Obstacleposition = new Vector3(Turretposx, 150.0f, transform.position.z+Obstacledist);
				Quaternion Turretrotation = Turretrotationinit;
				GameObject Mturr = (GameObject)Instantiate(Missileturret, Obstacleposition, Turretrotation);
			}	
			if(Obstacletype == 4){
				Vector3 Obstacleposition = new Vector3(-120, Random.Range(15,285), transform.position.z+Obstacledist);
				GameObject Hcol  = (GameObject)Instantiate(hcyl, Obstacleposition, Horizcolrotation);
			}
				
			Lastspawndist = currentdist;//reset distance so will not spawn for another obstaclerate length.

		}
		if (currentdist > 90000.0f && CrossSceneVars.Coreexist ==0){
			//Vector3 Obstacleposition = new Vector3(0, 150.0f, 100000.0f);
			//GameObject core = (GameObject)Instantiate(Core, Obstacleposition, Quaternion.identity);
			CrossSceneVars.Coreexist = 1;
		}
		//if (CrossSceneVars.Coreexist ==2){
		//	Vector3 Obstacleposition = new Vector3(0, 150.0f, (100000 + Time.time*blastspeed));
			//GameObject core = (GameObject)Instantiate(Coreexplosion, Obstacleposition, Quaternion.identity);
		//}
	}
}
