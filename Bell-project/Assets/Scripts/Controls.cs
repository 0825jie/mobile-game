using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controls : MonoBehaviour 
{
	public VirtualJoystick joystick;
	public VirtualJoystick joystick2;

	[Header("Player  Controls")]
	public KeyCode p1MoveUp;
	public KeyCode p1MoveDown;
	public KeyCode p1MoveLeft;
	public KeyCode p1MoveRight;
	public KeyCode p1Shoot;

	public KeyCode p1State1;
	public KeyCode p1State2;
	public KeyCode p1State3;
	public KeyCode p1State4;

	public KeyCode p1Super;
	public KeyCode p1FireShoot;
	public KeyCode p1ExplodeShoot;
	public KeyCode p1Eat;

	public KeyCode p1State0;
	public KeyCode p1Recover;

	[Header("Components")]
	public Game game;
	public DrawTool draw;
	public Animator animator;


	public float targetTime=80.0f;
	void Update ()
	{

		//Quit Game
//		if(Input.GetKeyDown(KeyCode.Escape)){
//			game.ui.GoToMenu();
//		}

		//Player 1
		game.player.rig.velocity = Vector3.zero;
		if (game.player.canMove) {
		if (Input.GetKeyDown (p1State1)) {
		game.player.moveSpeed = game.player.moveSpeed * (float)1.2;
		}
		if (Input.GetKeyDown (p1State2)) {
			
			game.player.moveSpeed = game.player.moveSpeed / (float)1.2;
		}
		if (Input.GetKeyDown (p1State3)) {

			game.player.moveSpeed = game.player.moveSpeed / (float)1.2;
		}
		if (Input.GetKeyDown (p1State4)) {

			game.player.health = 0;
		}
		if (Input.GetKeyDown (p1Recover)) {
			
			game.player.health = game.playerStartHealth;
			game.player.energy = game.playerStartEnergy;
		}
		if (Input.GetKeyDown (p1Super)) {
			game.player.superShoot();
		}
		if (Input.GetKeyDown (p1FireShoot)) {
			game.player.fireShoot();
		}
		if (Input.GetKeyDown (p1ExplodeShoot)) {
			game.player.explodeShoot ();
		}
		if (Input.GetKeyDown (p1Eat)) {
			game.player.eat();
		}


			float posx = joystick.Horizontal();
			float posy = joystick.Vertical();
			game.player.JoyMove(posx,posy);
		}


		if(game.player.canMove && game.player.energy >= game.player.projectileConsume){
			if(Input.GetKeyDown(p1Shoot)){
				if (game.player.bulletType == "shoot") {
					game.player.Shoot();
                    animator.SetTrigger("attack");
				}

				if (game.player.bulletType == "cold") {
					game.player.superShoot();
					targetTime -= Time.deltaTime;
					if (targetTime <= 0.0f) {
						game.player.bulletType = "shoot";
						 targetTime=80.0f;
					}

				}
			}

		}


		if (game.player.rig.velocity.magnitude > 0.5 && game.player.health<game.playerStartHealth)
		{

			game.player.health = game.player.health +  (int)(Time.deltaTime *game.player.healthRecoverSpeed) ;
		}


			
		if (game.player.rig.velocity.magnitude < 0.5 && game.player.energy < game.playerStartEnergy)
	    {

			game.player.energy = game.player.energy +(int)(Time.deltaTime * game.player.energyRecoverSpeed *5 );
		}
		if (game.player.rig.velocity.magnitude < 0.5) {
			game.player.health = game.player.health -   (int)(Time.deltaTime * game.player.healthRecoverSpeed * 4);
		}
		if (game.player.health <= 5) {
			game.player.canMove = false;
			animator.SetTrigger ("dead");	


		}
	}
}
