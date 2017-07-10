using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStormAI : MonoBehaviour
{

	Transform player;

	Player playerself;
	// Reference to the player's position.
	UnityEngine.AI.NavMeshAgent nav;
	// Reference to the nav mesh agent.
	public Game game;

	public GameObject BulletB;
	public GameObject Storming;
	public Transform muzzle;
	public float shootDis;

	//	float ShootingNeedTime = 0.5f;
	//	float LocateTime = 0;

	public bool shoot1 = false;

	//	float LocateNeedTime = 3;
	float CountDown = 1f;
	public int health;
	private int flag = 0;

	public Animator  dongzuo;

	private Vector3 attackPosition;


	void Awake ()
	{
		// Set up the references.
		attackPosition = new Vector3(1,1,1);
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		playerself = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
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
		if (Vector3.Distance (player.position, transform.position) < 70 || flag == 1) {

			if (flag == 0) {
				gameObject.GetComponent<NavMeshAgent>().enabled = false;
				attackPosition = player.position;

				dongzuo.SetTrigger ("Attack");
			}
			//			transform.GetComponent<NavMeshAgent> ().Stop(true);

			flag = 1;
			CountDown -= Time.deltaTime;

			Debug.Log ("");
			if (CountDown < 0) {
				//dongzuo.SetTrigger ("Move");
				stormShoot ();
				gameObject.GetComponent<NavMeshAgent> ().enabled = true;
				flag = 0;
				CountDown = 1f;
			}

		}
	}

	public void stormShoot ()
	{
		GameObject storm = Instantiate (Storming, attackPosition, Quaternion.identity) as GameObject;	//Spawns the projectile at the muzzle.
		//		ProLighting lightScript = lighting.GetComponent<ProLighting>();	
		Destroy (storm, 2f);
		//		GameObject[] enermy1 = GameObject.FindGameObjectsWithTag ("enemy-ice");
		//
		//		GameObject[] enermy2 = GameObject.FindGameObjectsWithTag ("enemy-fire");
		//		GameObject[] enermy3 = GameObject.FindGameObjectsWithTag ("enemy-wind");
		//		GameObject[] enermy4 = GameObject.FindGameObjectsWithTag ("enemy-lighting");
		//
		//		GameObject[] enermy = new GameObject[enermy1.Length + enermy2.Length + enermy3.Length + enermy4.Length];
		//		enermy1.CopyTo (enermy, 0);
		//		enermy2.CopyTo (enermy, enermy1.Length);
		//		enermy3.CopyTo (enermy, enermy1.Length + enermy2.Length);
		//		enermy4.CopyTo (enermy, enermy1.Length + enermy2.Length + enermy3.Length);
		//
		//
		//
		//		foreach (GameObject eachEnermy in enermy) {
		//			if (Vector3.Distance (game.player.transform.position, eachEnermy.transform.position) < 40) {
		//				//				Destroy (eachEnermy);
		//				Enemy enemy = eachEnermy.GetComponent<Enemy> ();
		//				enemy.TakeDamage (50);
		//			}
		//		}
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