using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour 
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


	//
//		void Hittarget()
//		{
//			GameObject effectins = (GameObject)Instantiate (impactEffect, transform.position, transform.rotation);
//		    Destroy (effectins, 5f);
//			if (explosion > 0f) {
//			
//				Explode ();
//			} else
//		{
//			
//				Damage (target);
//			}
//
//			Destroy (gameObject);
//
//		}

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












	//Called when the projectile's CircleCollider2D component enters a another collider or trigger. 
	//The "col" parameter is the collider that it enters.
//	void OnCollisionEnter2D (Collision2D col)
//	{
//		bounces++;
//
//		if(col.gameObject.tag == "Tank"){						//Is the object we hit a tank?
//			Tank tank = col.gameObject.GetComponent<Tank>();	//Get the tank's Tank.cs component.
//
//			if(!game.canDamageOwnTank){							//Can we not damage our own tank?
//				if(tank.id != tankId){							//Is the tank we hit not the one that shot this projectile?
//					tank.Damage(damage);						//Call the damage function on that tank to damage it.
//				}
//			}else{
//				tank.Damage(damage);
//			}
//		}
//
//		if(bounces >= game.maxProjectileBounces || col.gameObject.tag == "Tank"){
//			//Particle Effect
//			GameObject hitEffect = Instantiate(hitParticleEffect, transform.position, Quaternion.identity) as GameObject;	//Spawn the hit particle effect at the position of impact.
//			Destroy(hitEffect, 1.0f);	//Destroy that effect after 1 second.
//
//			Destroy(gameObject);		//Destroy the projectile.
//		}
//	}
	private void OnCollisionEnter(Collision collison)
	{	
		if (collison.transform.tag != "Player") {
			Destroy (gameObject);


		} 
		if (collison.transform.tag == "enemy") {
			GameObject player1 = GameObject.Find ("Player1");
			Player player = player1.GetComponent<Player> ();
			player.shootState = 1;

			Damage (collison.gameObject);
		}



	}


	public void OnTriggerEnter(Collision collision) {
		
		gameObject.SetActive (false);



	}











}
