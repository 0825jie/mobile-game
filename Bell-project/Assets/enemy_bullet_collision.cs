using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet_collision : MonoBehaviour
{


	float lifetime = 10;
	int time=0;
	public int damage = 200;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		time += 1;
		if (time >= lifetime) {
			Destroy (gameObject);
		}
	}

	public bool setDamage(int d){
		this.damage = d;
		return true;
	}

	private void OnCollisionEnter (Collision collision)
	{ 
		if (collision.transform.tag != "e_bullet" && collision.transform.tag != "enemy") {

			gameObject.SetActive (false);
			Destroy (gameObject);
		}
		if(collision.transform.tag == "Player"){		
			Player e = collision.gameObject.GetComponent<Player>();
			e.TakeDamage (damage);
		}
	}
	private void OnTriggerEnter (Collider collision) {
		if (collision.transform.tag == "player") {
			Player e = collision.gameObject.GetComponent<Player>();
			e.health = e.health - 3000;

			gameObject.SetActive (false);
			Destroy (gameObject);
		}
	}

}
