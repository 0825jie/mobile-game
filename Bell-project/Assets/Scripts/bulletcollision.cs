﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletcollision : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	private void OnCollisionEnter(Collision collision)
	{


		if (collision.transform.tag == "enemy") {
			Destroy (collision.gameObject);
			gameObject.SetActive (false);
			game.player.moveSpeed = game.player.moveSpeed * (float)1.2;

		} else if (collision.transform.tag != "Player"){
			gameObject.SetActive (false);
		}
	}
}
