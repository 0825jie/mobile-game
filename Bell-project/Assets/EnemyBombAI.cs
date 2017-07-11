using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBombAI : MonoBehaviour
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

	public bool shoot1 = false;

	float LocateNeedTime = 3;
	float CountDown = 1f;
	public int health;
	private int flag = 0;

	public GameObject Booming;
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
	void Update()
	{
//		if (shoot1) { 
//			float dist = Vector3.Distance(player.position, transform.position);
//			if (dist < shootDis) {
//				LocateTime += ShootingNeedTime;
//				if (LocateTime >= 10) {
//					LocateTime = 0;
//
//					shoot();
//				}
//			}
//		}
	

		nav.SetDestination (player.position);
		if (Vector3.Distance (player.position, transform.position) < 35 || flag == 1) {
			if (flag == 0) {
				gameObject.GetComponent<NavMeshAgent>().enabled = false;
				dongzuo.SetTrigger ("Take Damge");

			}
//			transform.GetComponent<NavMeshAgent> ().Stop(true);
			flag = 1;
			CountDown -= Time.deltaTime;
			Debug.Log (CountDown);
			if (CountDown < 0) {
				boomShoot ();
				Destroy (gameObject);
//				if(Vector3.Distance (player.position, transform.position) <45) {
//					game.player.health = game.player.health - 1000;
//				}
			}

		}
	}


	public void boomShoot ()
	{
		GameObject booming = Instantiate (Booming, transform.position, Quaternion.identity) as GameObject;	//Spawns the projectile at the muzzle.
		//		ProLighting lightScript = lighting.GetComponent<ProLighting>();	
		Destroy (booming, 2f);

	}

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


	public void OnTriggerEnter (Collider other) {
		if (other.transform.tag == "p_fire") {
			gameObject.SetActive (false);
		}
	}
}