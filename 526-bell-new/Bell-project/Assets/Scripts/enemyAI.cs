using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{

	Transform player;
	// Reference to the player's position.
	UnityEngine.AI.NavMeshAgent nav;
	// Reference to the nav mesh agent.
	public Game game;

	public GameObject BulletB;

	float ShootingTime = 0.5f;
	float ShootingNeedTime = 0.5f;
	float LocateTime = 0;
	float LocateNeedTime = 3;

	void Awake ()
	{
		// Set up the references.
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
	}

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{

		LocateTime += ShootingNeedTime;
		if (LocateTime >= 10) {
			LocateTime = 0;

			shoot ();
		}

		nav.SetDestination (player.position);
		if (Vector3.Distance (player.position, transform.position) < 15) {
		}



	}

	void shoot ()
	{
		if (player != null) {
			Vector3 relativePos = player.position;
			//GameObject bullet = (GameObject)Instantiate(BulletB,transform.position, new Quaternion(0, 0, 0, 0));
			GameObject proj = Instantiate (BulletB, transform.position, Quaternion.LookRotation (relativePos)) as GameObject;    
			Projectile projScript = proj.GetComponent<Projectile> ();
			Vector3 bulletDirection = player.position - transform.position;    

			projScript.rig.velocity = bulletDirection.normalized * 100;

			Debug.Log ("enermyshoot");
			Debug.Log (projScript.rig.velocity);
		}
	}
	public void OnTriggerEnter (Collider other) {
		if (other.transform.tag == "p_fire") {
			gameObject.SetActive (false);
		}
	}

}

		
