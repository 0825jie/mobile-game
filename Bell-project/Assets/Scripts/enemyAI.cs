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
	public float shootDis;

	float ShootingNeedTime = 0.5f;
	float LocateTime = 0;
<<<<<<< HEAD

=======
	float LocateNeedTime = 3;
	public int health;
>>>>>>> 2a5a6664baa3a960b365e4e4160931acb962248a
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
<<<<<<< HEAD
=======
		float dist = Vector3.Distance(player.position, transform.position);
		if (dist < shootDis) {
			LocateTime += ShootingNeedTime;
			if (LocateTime >= 10) {
				LocateTime = 0;

				shoot ();
			}
		}
>>>>>>> 2a5a6664baa3a960b365e4e4160931acb962248a

		nav.SetDestination (player.position);
		if (Vector3.Distance (player.position, transform.position) < 15) {
			Destroy (gameObject);
			game.player.health = game.player.health - 200;
		}
	}

<<<<<<< HEAD

=======
	void shoot ()
	{
		if (player != null) {
			Vector3 relativePos = player.position;
			GameObject proj = Instantiate (BulletB, transform.position, Quaternion.LookRotation (relativePos)) as GameObject; 
			Rigidbody rig = proj.GetComponent<Rigidbody> ();

			Vector3 bulletDirection = player.position - transform.position;
			rig.velocity= bulletDirection.normalized * 500;

		}
	}

>>>>>>> 2a5a6664baa3a960b365e4e4160931acb962248a
	public void OnTriggerEnter (Collider other) {
		if (other.transform.tag == "p_fire") {
			gameObject.SetActive (false);
		}
	}
}