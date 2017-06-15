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


	[Header("Components")]
	public Game game;

	void Update ()
	{
		Debug.Log("Tian");
		//Quit Game
//		if(Input.GetKeyDown(KeyCode.Escape)){
//			game.ui.GoToMenu();
//		}

		//Player 1
		game.player.rig.velocity = Vector3.zero;


		//		if(game.player1Tank.canMove){
		//			if (Input.GetKey (p1TurnRight) && Input.GetKey (p1MoveForward)) {
		//				game.player1Tank.Move(2);
		//			}
		//			else if (Input.GetKey (p1TurnRight) && Input.GetKey (p1MoveBackwards)) {
		//				game.player1Tank.Move(4);
		//
		//			}
		//			else if (Input.GetKey (p1TurnLeft) && Input.GetKey (p1MoveBackwards)) {
		//				game.player1Tank.Move(6);
		//
		//			}
		//			else if (Input.GetKey (p1TurnLeft) && Input.GetKey (p1MoveForward)) {
		//				game.player1Tank.Move(8);
		//
		//			}
		//			else if(Input.GetKey(p1MoveForward)){
		//				game.player1Tank.Move(1);
		//			}
		//			else if(Input.GetKey(p1MoveBackwards)){
		//				game.player1Tank.Move(5);
		//			}
		//			else if(Input.GetKey(p1TurnLeft)){
		//				game.player1Tank.Move(7);
		//			}
		//			else if(Input.GetKey(p1TurnRight)){
		//				game.player1Tank.Move(3);
		//			}
		//
		//		}

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


		if(game.player.canShoot && game.player.energy >= 25){
			if(Input.GetKeyDown(p1Shoot)){
				game.player.Shoot();
			}

		}
			
		if (game.player.rig.velocity.magnitude < 0.5 && game.player.energy < 1000)
	    {

			game.player.energy = game.player.energy + 2;
		}
		if (game.player.rig.velocity.magnitude < 0.5) {
			game.player.health = game.player.health -2;
		}
		if (game.player.health <= 5) {
			game.player.gameObject.SetActive (false);
		}
	}
}
