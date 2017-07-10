using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStormingBullet : MonoBehaviour {

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

	// Use this for initialization
	void Start () {
		
	}

	void Explode()
	{
//		Collider[] colliders = Physics.OverlapSphere (transform.position, explosion);
//		foreach (Collider collider in colliders) 
//		{
//			if (collider.tag == "Player") 
//
//			{
//				//	Damage (colliders.gameObject);
//			}
//		}
//
	}

	void Damage(GameObject player)
	{
		
//		Enemy e = player.GetComponent<Enemy>();
//		e.TakeDamage (damage);
	}

//	private void OnCollisionEnter(Collision collison)
//	{	
//		if (collison.transform.tag == "Player") {
//			//Changeweap();
//			Damage (collison.gameObject);
//			Destroy (gameObject);
//
//		}
//
//		if (collison.transform.tag != "Player") {
//			Destroy (gameObject);
//		} 
//	}

	public void OnTriggerEnter(Collider collison) {
//		if (collison.transform.tag == "enemy-ice" ||
//			collison.transform.tag == "enemy-fire" ||
//			collison.transform.tag == "enemy-lighting"||
//			collison.transform.tag == "enemy-wind"  ) {
//			Debug.Log ("eeeeeeee");
//			GameObject hitParticleEffects = Instantiate (hitParticleEffect, collison.transform.position, collison.transform.rotation);
//
//
//		}
		if (collison.transform.tag == "Player") {
			Player p = collison.gameObject.GetComponent<Player> ();
			p.health -= p.health - 1000;
			Destroy (gameObject,2f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
