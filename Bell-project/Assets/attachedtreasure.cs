using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attachedtreasure : MonoBehaviour {

	public GameObject healthIcon;
	private GameObject g1;

	// Use this for initialization
	void Start () {
		g1 = Instantiate (healthIcon, transform.position + new Vector3(0,10,0), transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0,1,0);

	}
	private void OnCollisionEnter(Collision collision) {
		if (collision.transform.tag == "Player") {
			g1.SetActive (false);
		}
	}

}
