using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProLighting : MonoBehaviour 
{
	[Header("Stats")]
	public int damage=30;						//How much damage this projectile will deal on impact.

	[Header("Components / Objects")]
	public GameObject hitParticleEffect;	//The particle effect prefab that will spawn when the projectile hits something.
	public Rigidbody rig;					//The Rigidbody2D component of the projectile.
	private int bounces;					//The amount of times the projectile has bounced off a wall.



	public Transform target;
	public float explosion=2f;
	public float speed=70f;
	public GameObject impactEffect;

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
		if (collison.transform.tag == "enemy") {
			Destroy (gameObject);
			Damage (collison.gameObject);
		}
		if (collison.transform.tag != "Player") {
			Destroy (gameObject);
		} 
		//		if (collison.transform.tag == "enemy" && collison.transform.tag == "Terrain") {
		//			GameObject player1 = GameObject.Find ("Player1");
		//			Player player = player1.GetComponent<Player> ();
		//			player.shootState = 1;
		//
		//			Damage (collison.gameObject);
		//		}
		//


	}


	public void OnTriggerEnter(Collider collison) {
		if (collison.transform.tag == "enemy") {
			Debug.Log ("eeeeeeee");
			GameObject hitParticleEffects = Instantiate (hitParticleEffect, collison.transform.position, collison.transform.rotation);


		}
//		gameObject.SetActive (false);

	}











}
