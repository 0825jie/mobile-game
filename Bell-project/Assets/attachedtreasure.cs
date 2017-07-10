using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attachedtreasure : MonoBehaviour {

	public GameObject hitEffect1;
	public GameObject hitEffect2;
	public Player game;
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
				GameObject effect = Instantiate (hitEffect1, collision.transform.position, collision.transform.rotation);
				Destroy (effect, 3f);

			} 

	



			else {
				hinttext.setText (hinttext.getCount ().ToString () + "  Energy");
				GameObject effect = Instantiate (hitEffect2, collision.transform.position, collision.transform.rotation);
				Destroy (effect, 3f);
			}
			Destroy (gameObject);
		}
	}

}
