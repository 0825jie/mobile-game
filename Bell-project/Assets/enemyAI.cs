using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour {

	Transform player;               // Reference to the player's position.
	public Games game;
	UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.


	void Awake ()
	{
		// Set up the references.
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		nav.SetDestination (player.position);
		float distance = Vector3.Distance (player.position, transform.position);
		if (distance < 10) {
			game.player1.health = game.player1.health-10;
			Debug.Log ("KKKKKKKKKKKKKKK");
		}
	}
}
