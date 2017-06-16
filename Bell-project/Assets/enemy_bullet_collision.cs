using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet_collision : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}


	private void OnCollisionEnter (Collision collision)
	{ 
		        
		if (collision.transform.tag != "e_bullet" && collision.transform.tag != "enemy") {
			gameObject.SetActive (false);
			Destroy (gameObject);
		}
	}
}
