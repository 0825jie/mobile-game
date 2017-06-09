using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_b : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {

		if (other.transform.tag == "player") {
			Destroy(other.gameObject);
			gameObject.SetActive(false);
		}
		if (other.transform.tag == "zidanqiang") {
			gameObject.SetActive (false);
		}
	}
}
