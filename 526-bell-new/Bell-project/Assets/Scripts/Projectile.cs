using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour 
{
	[Header("Stats")]
	public int tankId;						//The tank which shot this projectile.
	public int damage;						//How much damage this projectile will deal on impact.

	[Header("Components / Objects")]
	public GameObject hitParticleEffect;	//The particle effect prefab that will spawn when the projectile hits something.
	public Rigidbody rig;					//The Rigidbody2D component of the projectile.
	public GameObject player;
	private int bounces;					//The amount of times the projectile has bounced off a wall.

	private Transform target;

	public float explosion=0f;
	public float speed=70f;
	public GameObject impactEffect;
	public void seek(Transform _target)
	{
		target = _target;
	
	
	}

	void Update()
	{
		

		Vector3 dir = target.position - transform.position;
		float distancethisFrame = speed * Time.deltaTime;
		if (dir.magnitude <= distancethisFrame) {
			Hittarget ();
			return;
		
		}
		transform.Translate(dir.normalized*distancethisFrame,Space.World);
		transform.LookAt(target);
	}



	void Hittarget()
	{
		GameObject effectins = (GameObject)Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (effectins, 6f);
		if (explosion > 0f) {
		
			Explode ();
		} else {
		
			Damage (target);
		}
	
		Destroy (gameObject);
	
	}

	void Explode()
	{
		Collider[] colliders = Physics.OverlapSphere (transform.position, explosion);
		foreach (Collider collider in colliders) 
		{
			if (collider.tag == "enemy") 
			
			{
				Damage (collider.transform);
			}
		}
	
	}


	void Damage(Transform enemy)
	{
	
	
	
	}

	void onDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, explosion);
	
	
	}
















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
		if (collison.transform.tag == "enemy") {
		
			Destroy (collison.gameObject);
		} else if (collison.transform.tag != "Player") {
			//gameObject.SetActive (false);
		}

	}


	public void OnTriggerEnter(Collision collision) {
		Debug.Log ("aaaaaaa");
		gameObject.SetActive (false);
	}











}
