using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet_collision : MonoBehaviour
{
	float lifetime = 50;
	int time =0;
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
