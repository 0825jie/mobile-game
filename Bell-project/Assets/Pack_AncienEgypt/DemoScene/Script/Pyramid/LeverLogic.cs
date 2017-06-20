using UnityEngine;
using System.Collections;

public class LeverLogic : MonoBehaviour {

	public Animator StatueAnimatorToEnable;
	public Animator LeverAnimator;
	public Transform Player;
	private float Distance = 3;
	public GameObject PopUp;

	private bool canActivate = false;
	private bool finish = false;

	void OnBecameVisible(){

		if(!finish)
			canActivate= true;
	}

	void OnBecameInvisible(){


		canActivate = false;
		Hide();
	}

	void LateUpdate(){
		if(canActivate && Input.GetKeyUp(KeyCode.E)){
			Activate();
		}

	}
	void OnTriggerStay(){

		if((Vector3.Distance(Player.position,this.transform.position) < Distance) && canActivate && !finish){
			Show();
		}
		else{
			Hide();
		}
	}

	void Activate(){
		canActivate = false;
		if(!canActivate){
			finish = true;
			canActivate = false;
			LeverAnimator.SetTrigger("ActivateLever");
			StatueAnimatorToEnable.SetTrigger("ActivateStatue");

			this.GetComponent<AudioSource>().Play();
			Hide ();
		}
	}

	void OnTriggerExit(){
		Hide();
	}


	void Show(){
		PopUp.GetComponent<Renderer>().enabled =true;
	}

	void Hide(){
		PopUp.GetComponent<Renderer>().enabled =false;
		// hide
	}

}