using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProExplode : MonoBehaviour 
{
	[Header("Stats")]
	public int damage=60;						//How much damage this projectile will deal on impact.

	[Header("Components / Objects")]
	public GameObject hitParticleEffect;	//The particle effect prefab that will spawn when the projectile hits something.
	public Rigidbody rig;					//The Rigidbody2D component of the projectile.
	private int bounces;					//The amount of times the projectile has bounced off a wall.



	public Transform target;
	public float explosion=2f;
	public float speed=70f;
	public GameObject impactEffect;
	public GameObject egg;

	//
	void Update()
	{




	}


	void Explode()
	{
		Collider[] colliders = Physics.OverlapSphere (transform.position, explosion);
		foreach (Collider collider in colliders) 
		{
			if (collider.tag == "enemy") 

			{
				//	Damage (colliders.gameObject);
			}
		}

	}


	void Damage(GameObject enemy)
	{
		Enemy e = enemy.GetComponent<Enemy>();
		e.TakeDamage (damage);
	}




	//
	//



	private void OnCollisionEnter(Collision collison)
	{	
		if (collison.transform.tag == "enemy" ||collison.transform.tag == "enemy"|| collison.transform.tag == "enemy-wind" || collison.transform.tag == "enemy-fire" ||collison.transform.tag == "enemy-boss"||collison.transform.tag == "enemy-fire" ||collison.transform.tag == "enemy-lighting") {
//			GameObject[] enermy = GameObject.FindGameObjectsWithTag("enemy");

//			foreach (GameObject eachEnermy in enermy) {
//				if (Vector3.Distance (collison.transform.position, eachEnermy.transform.position) < 40) {
//					//				Destroy (eachEnermy);
//					Enemy enemy = eachEnermy.GetComponentInParent<Enemy> ();
//					enemy.TakeDamage (50);
//				}
//			}
			Destroy (gameObject);
//			Damage (collison.gameObject);
			GameObject eggs = Instantiate (egg, collison.transform.position, collison.transform.rotation);
			Destroy (egg,3f);
		}
		//		if (collison.transform.tag != "Player") {
		//			Destroy (gameObject);
		//		} 
		//		if (collison.transform.tag == "enemy" && collison.transform.tag == "Terrain") {
		//			GameObject player1 = GameObject.Find ("Player1");
		//			Player player = player1.GetComponent<Player> ();
		//			player.shootState = 1;
		//
		//			Damage (collison.gameObject);
		//		}
		//


	}


	public void OnTriggerEnter(Collider other) {

		if (other.transform.tag == "enemy") {
			GameObject eggs = Instantiate (egg, other.transform.position, other.transform.rotation);
			GameObject[] enermy = GameObject.FindGameObjectsWithTag("enemy");

			foreach (GameObject eachEnermy in enermy) {
				if (Vector3.Distance (other.transform.position, eachEnermy.transform.position) < 40) {
					//				Destroy (eachEnermy);
					Enemy enemy = eachEnermy.GetComponent<Enemy> ();
					enemy.TakeDamage (50);
				}
			}

			//			Destroy (gameObject);
			Damage (other.gameObject);
		}

	}
}

