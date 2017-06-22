using UnityEngine;
using System.Collections;

public class SarcophagusTrigger : MonoBehaviour {


	public Animator Sarcophagus;
	private bool canOpen = true;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter() {
		if(canOpen){

			canOpen = false;
			this.GetComponent<AudioSource>().Play();
			Sarcophagus.SetBool("Open", true);
			Destroy(this.gameObject, 10f);
		}

	
	}
}
