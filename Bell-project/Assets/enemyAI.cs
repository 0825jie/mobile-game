using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour {

	Transform player;               // Reference to the player's position.
	UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.

	int time;
	public int frequent = 100;			//The direction that the tank is facing. Used for movement direction.
	public Vector3 bulletDirection;
	public GameObject bullet;
	public Games game;



	void Awake ()
	{
		// Set up the references.
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
		time = 0;
	}

	// Use this for initialization
	void Start () {
		
		bulletDirection = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {


		nav.SetDestination (player.position);
		time += 100;
		if (time >= 1000) {
			time = 0;  
			GameObject proj = Instantiate (bullet, gameObject.transform.position, gameObject.transform.rotation);
		
			proj.GetComponent<Rigidbody> ().velocity = transform.TransformDirection (Vector3.forward * 500);

			if (Vector3.Distance (player.position, transform.position) < 10) {
				game.player1.health = game.player1.health - 10;

			}
		}
	}


}

		
