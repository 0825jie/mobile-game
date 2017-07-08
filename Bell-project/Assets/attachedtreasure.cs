using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attachedtreasure : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0,1,0);

	}
	private void OnCollisionEnter(Collision collision) {
		if (collision.transform.tag == "Player") {
		Destroy (gameObject);
			GameObject hints = GameObject.FindGameObjectWithTag ("hint");
			Hintcontrol hinttext = hints.GetComponent<Hintcontrol> ();
			if (gameObject.tag == "box1") {
				hinttext.setText (hinttext.getCount ().ToString () + "  Health");
			} else {
				hinttext.setText (hinttext.getCount ().ToString () + "  Energy");
			}
			Destroy (gameObject);
		}
	}

}
