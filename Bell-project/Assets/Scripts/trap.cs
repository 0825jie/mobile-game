using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour {

	public float damage;
	public int playerHealthDamage;
	public int playerHealthRecover;
	public int playerEnergyRecover;

	public GameObject lighting;
	public GameObject fire;
	public GameObject ice;
	public GameObject wind;

	//private GameObject;
	// Use this for initialization
	void Start () {
		lighting.SetActive(false);
		fire.SetActive(false);
		ice.SetActive(false);
		wind.SetActive(false);
		InvokeRepeating("lightingT", 0, 60);
		InvokeRepeating("lightingF", 15, 60);
		InvokeRepeating("fireT", 15, 60);
		InvokeRepeating("fireF", 30, 60);
		InvokeRepeating("iceT", 30, 60);
		InvokeRepeating("iceF", 45, 60);
		InvokeRepeating("windT", 45, 60);
		InvokeRepeating("windF", 60, 60);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Damage(GameObject enemy)
	{
		Enemy e = enemy.GetComponent<Enemy>();
		e.TakeDamage (damage);
	}

	void play(GameObject player){
		Player p = player.GetComponent<Player>(); // 1 fire, 2 wind, 3 ice, 4 light

		p.health = p.health - playerHealthDamage;

		if (p.shootState == 1 && gameObject.tag == "trap-fire") {
			p.health = p.health + playerHealthRecover;
			p.energy = p.energy + playerEnergyRecover;

		}
		if (p.shootState == 2 && gameObject.tag == "trap-wind") {
			p.health = p.health + playerHealthRecover;
			p.energy = p.energy + playerEnergyRecover;
		}
		if (p.shootState == 3 && gameObject.tag == "trap-ice") {
			p.health = p.health + playerHealthRecover;
			p.energy = p.energy + playerEnergyRecover;
		}
		if (p.shootState == 4 && gameObject.tag == "trap-lighting") {
			p.health = p.health + playerHealthRecover;
			p.energy = p.energy + playerEnergyRecover;
		}
	}

	void OnTriggerStay(Collider col) {
		
		//Destroy (col.gameObject);
		if (col.transform.tag == "enemy-lighting"  || col.transform.tag == "enemy-fire" || col.transform.tag == "enemy-wind" || col.transform.tag == "enemy-ice") {
			
			Damage (col.gameObject);

			//int temp = (int)(Time.deltaTime * 1 * 4);

		}

		if (col.transform.tag == "Player") {
			play (col.gameObject);
		}

	}
	void lightingT(){
		//GameObject lighting = GameObject.FindWithTag("trap-lighting");
		lighting.SetActive(true);
	}

	void lightingF(){
		lighting.SetActive(false);
	}
	void fireT(){
		fire.SetActive(true);
	}

	void fireF(){
		fire.SetActive(false);
	}
	void iceT(){
		ice.SetActive(true);
	}

	void iceF(){
		ice.SetActive(false);
	}
	void windT(){
		wind.SetActive(true);
	}

	void windF(){
		wind.SetActive(false);
	}
}
