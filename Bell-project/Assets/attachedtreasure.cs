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
				hinttext.setText ( "Health+500");
              
                
				GameObject effect = Instantiate (hitEffect1, collision.transform.position + new Vector3(0,-2,0), collision.transform.rotation);
				effect.transform.parent = collision.gameObject.transform.Find("trojan").transform;
				Destroy (effect, 2f);

			} 

	



			else {
				hinttext.setText ("Energy+500");
              
                GameObject effect = Instantiate (hitEffect2, collision.transform.position + new Vector3(0,-2,0), collision.transform.rotation);
				effect.transform.parent = collision.gameObject.transform.Find("trojan").transform;
				Destroy (effect, 2f);
			}
			Destroy (gameObject);
		}
	}

}
