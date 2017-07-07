using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour {

	public float damage;
	//private GameObject;
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

	void OnTriggerStay(Collider col) {
		
		//Destroy (col.gameObject);
		if (col.transform.tag == "enemy-lighting"  || col.transform.tag == "enemy-fire" || col.transform.tag == "enemy-wind" || col.transform.tag == "enemy-far") {
			
			Damage (col.gameObject);

			//int temp = (int)(Time.deltaTime * 1 * 4);

		}

	}	
}
