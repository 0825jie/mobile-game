﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProNormal : MonoBehaviour 
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
	public Player playerone;
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


	void Changeweap()
	{
		playerone.bulletType="cold";
	
	}

	//
	//



	private void OnCollisionEnter(Collision collison)
	{	
		if (collison.transform.tag == "enemy-fire") {
	        //Changeweap();
            Damage (collison.gameObject);
			Destroy (gameObject);
		
		}
		if (collison.transform.tag == "enemy-ice") 
		{
			Damage (collison.gameObject);
			Destroy (gameObject);
		}


		if (collison.transform.tag == "enemy-lighting") 
		{
			Damage (collison.gameObject);
			Destroy (gameObject);
		}

		if (collison.transform.tag == "enemy-wind") 
		{
			Damage (collison.gameObject);
			Destroy (gameObject);
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


	public void OnTriggerEnter(Collision collision) {

		gameObject.SetActive (false);

	}
		
}
