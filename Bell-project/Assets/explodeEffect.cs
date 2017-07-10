using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodeEffect : MonoBehaviour {

	public int damage=30;	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Damage(GameObject enemy)
	{
		Enemy e = enemy.GetComponent<Enemy>();
		e.TakeDamage (damage);
	}
	public void OnTriggerEnter(Collider collison) {
		if (collison.transform.tag == "enemy-ice" ||
			collison.transform.tag == "enemy-fire" ||
			collison.transform.tag == "enemy-lighting"||
			collison.transform.tag == "enemy-wind" || collison.transform.tag =="enemy" ) {

			Damage (collison.gameObject);
//			GameObject hitParticleEffects = Instantiate (hitParticleEffect, collison.transform.position, collison.transform.rotation);
//			Destroy (hitParticleEffects, 2f);

		}
		//		gameObject.SetActive (false);

	}
}
