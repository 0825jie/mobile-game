using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controls : MonoBehaviour 
{
	public VirtualJoystick joystick;

	[Header("Player  Controls")]
	public KeyCode p1MoveUp;
	public KeyCode p1MoveDown;
	public KeyCode p1MoveLeft;
	public KeyCode p1MoveRight;
	public KeyCode p1Shoot;

	public KeyCode p1State1;
	public KeyCode p1State2;
	public KeyCode p1State3;
	public KeyCode p1Super;

	public KeyCode p1State0;
	public KeyCode p1Recover;

	[Header("Components")]
	public Game game;

	void Update ()
	{

		//Quit Game
//		if(Input.GetKeyDown(KeyCode.Escape)){
//			game.ui.GoToMenu();
//		}

		//Player 1
		game.player.rig.velocity = Vector3.zero;
	
		if (Input.GetKeyDown (p1State1)) {
			
			game.player.moveSpeed = game.player.moveSpeed * (float)1.2;
		}
		if (Input.GetKeyDown (p1State2)) {
			game.player.moveSpeed = game.player.moveSpeed / (float)1.2;
		}
		if (Input.GetKeyDown (p1State3)) {
			game.player.moveSpeed = game.player.moveSpeed / (float)1.2;
		}
		if (Input.GetKeyDown (p1Recover)) {
			game.player.health = game.playerStartHealth;
			game.player.energy = game.playerStartEnergy;
		}
		if (Input.GetKeyDown (p1Super)) {
			game.player.superShoot();
		}

		if (game.player.canMove) {
//			int a = joystick.Test();
			//			Debug.Log (a);
			float posx = joystick.Horizontal();
			float posy = joystick.Vertical();
			//			int a = joystick.Test;
			//			Debug.Log ("heyheyhey");
			//			Debug.Log (posx);
			game.player.JoyMove(posx,posy);
		}


		if(game.player.canShoot && game.player.energy >= game.player.projectileConsume){
			if(Input.GetKeyDown(p1Shoot)){
				game.player.Shoot();
			}

		}
			
		if (game.player.rig.velocity.magnitude < 0.5 && game.player.energy < game.playerStartEnergy)
	    {

			game.player.energy = game.player.energy + game.player.energyRecoverSpeed / 10;
		}
		if (game.player.rig.velocity.magnitude < 0.5) {
			game.player.health = game.player.health - game.player.healthRecoverSpeed / 10;
		}
		if (game.player.health <= 5) {
			game.player.gameObject.SetActive (false);
		}
	}
}
