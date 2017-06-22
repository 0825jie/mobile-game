using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet_collision : MonoBehaviour
{
<<<<<<< HEAD
	float lifetime = 50;
	int time =0;
=======

	float lifetime = 10;
	int time=0;
>>>>>>> 2a5a6664baa3a960b365e4e4160931acb962248a
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


	private void OnCollisionEnter (Collision collision)
	{ 
		if (collision.transform.tag != "e_bullet" && collision.transform.tag != "enemy") {

			gameObject.SetActive (false);
			Destroy (gameObject);
		}
	}
}
