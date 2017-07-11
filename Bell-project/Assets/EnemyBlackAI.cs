using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlackAI : MonoBehaviour
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
	public int shootdis;
	public int damage = 500;
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
		
		if (Vector3.Distance (player.position, transform.position) > shootdis) {

			nav.SetDestination (player.position);
//			Destroy (gameObject);
//
//			Debug.Log(game.player.health);
//			game.player.health = game.player.health - 200;
		}
		LocateTime += ShootingNeedTime;
		if (LocateTime >= 10) {
			LocateTime = 0;

			shoot ();
		}


	}

	void shoot ()
	{
		if (player != null) {
			Vector3 relativePos = player.position;
			GameObject proj = Instantiate (BulletB, transform.position, Quaternion.LookRotation (relativePos)) as GameObject;  
			Rigidbody rig = proj.GetComponent<Rigidbody> ();
			proj.GetComponent<enemy_bullet_collision>().setDamage (damage);
			Vector3 bulletDirection = player.position - transform.position;  
			if (bulletDirection.x == 0 && bulletDirection.y == 0 && bulletDirection.z == 0) {
				return;
			}
			rig.velocity = bulletDirection.normalized * 500;
		}
	}

}
