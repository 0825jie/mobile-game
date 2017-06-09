using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controls : MonoBehaviour 
{
	public VirtualJoystick joystick;

	[Header("Player 1 Controls")]
	public KeyCode p1MoveForward;
	public KeyCode p1MoveBackwards;
	public KeyCode p1TurnLeft;
	public KeyCode p1TurnRight;
	public KeyCode p1Shoot;

	[Header("Player 2 Controls")]
	public KeyCode p2MoveForward;
	public KeyCode p2MoveBackwards;
	public KeyCode p2TurnLeft;
	public KeyCode p2TurnRight;
	public KeyCode p2Shoot;

	[Header("Components")]
	public Games game;

	void Update ()
	{
		Debug.Log("Tian");
		//Quit Game
//		if(Input.GetKeyDown(KeyCode.Escape)){
//			game.ui.GoToMenu();
//		}

		//Player 1
		game.player1.rig.velocity = Vector3.zero;


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

		if (game.player1.canMove) {
//			int a = joystick.Test();
			//			Debug.Log (a);
			float posx = joystick.Horizontal();
			float posy = joystick.Vertical();
			//			int a = joystick.Test;
			//			Debug.Log ("heyheyhey");
			//			Debug.Log (posx);
			game.player1.JoyMove(posx,posy);
		}


		if(game.player1.canShoot && game.player1.energy >= 25){
			if(Input.GetKeyDown(p1Shoot)){
				game.player1.Shoot();
			}

		}

//		//Player 2
//		game.player2Tank.rig.velocity = Vector2.zero;
//
//
//		if(game.player2Tank.canMove){
//			if (Input.GetKey (p2TurnRight) && Input.GetKey (p2MoveForward)) {
//				game.player2Tank.Move(2);
//			}
//			else if (Input.GetKey (p2TurnRight) && Input.GetKey (p2MoveBackwards)) {
//				game.player2Tank.Move(4);
//
//			}
//			else if (Input.GetKey (p2TurnLeft) && Input.GetKey (p2MoveBackwards)) {
//				game.player2Tank.Move(6);
//
//			}
//			else if (Input.GetKey (p2TurnLeft) && Input.GetKey (p2MoveForward)) {
//				game.player2Tank.Move(8);
//
//			}
//			else if(Input.GetKey(p2MoveForward)){
//				game.player2Tank.Move(1);
//			}
//			else if(Input.GetKey(p2MoveBackwards)){
//				game.player2Tank.Move(5);
//			}
//			else if(Input.GetKey(p2TurnLeft)){
//				game.player2Tank.Move(7);
//			}
//			else if(Input.GetKey(p2TurnRight)){
//				game.player2Tank.Move(3);
//			}
//
//		}
//		if(game.player2Tank.canShoot){
//			if(Input.GetKeyDown(p2Shoot)){
//				game.player2Tank.Shoot();
//			}
//		}
		if (game.player1.rig.velocity.magnitude < 0.5 && game.player1.energy < 1000)
	    {
			
			Debug.Log (game.player1.rig.velocity.magnitude);
			Debug.Log (game.player1.energy);
			game.player1.energy++;
		}
		if (game.player1.rig.velocity.magnitude < 0.5) {
			game.player1.health = game.player1.health -2;
		}
		if (game.player1.health <= 5) {
			game.player1.gameObject.SetActive (false);
		}
	}
}
