using UnityEngine;
using System.Collections;

public class SpikesDeath : MonoBehaviour {

	public Animator FadeRed;
	public Transform Spawn;



	void OnTriggerEnter(Collider Col){

		if(Col.gameObject.tag == "Player"){

			StartCoroutine(PlayOneShot("Fade"));

			Col.transform.position = Spawn.transform.position;
		}
	}
	




	public IEnumerator PlayOneShot ( string paramName )
	{
		FadeRed.SetTrigger( paramName);
		yield return null;
		//yield return new WaitForSeconds(1f);
//		FadeRed.SetBool( paramName, false );

		
	}
}
