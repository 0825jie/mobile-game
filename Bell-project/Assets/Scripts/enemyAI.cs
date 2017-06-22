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

	float ShootingNeedTime = 0.5f;
	float LocateTime = 0;

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

		nav.SetDestination (player.position);
		if (Vector3.Distance (player.position, transform.position) < 15) {
			Destroy (gameObject);
			game.player.health = game.player.health - 200;
		}



	}


	public void OnTriggerEnter (Collider other) {
		if (other.transform.tag == "p_fire") {
			gameObject.SetActive (false);
		}
	}

}

		
