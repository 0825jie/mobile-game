using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadGameOver : MonoBehaviour {

	// Reference to the player's health.
	public Game game;
	// Reference to the animator component.




	void Update ()
	{
		// If the player has run out of health...
		if(game.player.health <= 0)
		{
			ModeSelect ();

		}



	}

	public void  ModeSelect(){
		StartCoroutine("Wait");

	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene (2);

	}



}
