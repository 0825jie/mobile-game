using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootAI : MonoBehaviour
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
	private float countTime;
	private int flag = 1;

	public Animator  dongzuo;
	void Awake ()
	{
		// Set up the references.
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
	}

	// Use this for initialization
	void Start ()
	{
		dongzuo.SetTrigger ("Move");
	}

	// Update is called once per frame
	void Update ()
	{
		nav.SetDestination (player.position);
		if (Vector3.Distance (player.position, transform.position) < shootdis && flag == 1) {
			dongzuo.SetTrigger ("Attack");
			shoot ();
			flag = 0;

		}
		if (flag == 0) {
			countTime -= Time.deltaTime;
			if (countTime <= 0.05f) {
				flag = 1;
				countTime = 1f;
			}
		}
//		LocateTime += ShootingNeedTime;
//		if (LocateTime >= 10) {
//			LocateTime = 0;
//
//			shoot ();
//		}


	}

	void shoot ()
	{
		if (player != null) {
			Vector3 relativePos = player.position;
			GameObject proj = Instantiate (BulletB, transform.position, Quaternion.LookRotation (relativePos)) as GameObject;  
			Rigidbody rig = proj.GetComponent<Rigidbody> ();

//			enemyShooting rig = proj.GetComponent<enemyShooting>();

//			proj.GetComponent<enemy_bullet_collision>().setDamage (damage);

			Vector3 bulletDirection = player.position - transform.position;  

//			if (bulletDirection.x == 0 && bulletDirection.y == 0 && bulletDirection.z == 0) {
//				return;
//			}
//			rig.rig.velocity = bulletDirection.normalized * 500;
//			Debug.Log (rig.rig.velocity);
//			bulletDirection = new Vector3(1,0,1);
			rig.velocity = bulletDirection * 10;
			Debug.Log (rig.velocity);
			Debug.Log ("aaaaaaaaaaaaaaaaaaaaaaaaaaaarig.velocity");
		}
	}

}
