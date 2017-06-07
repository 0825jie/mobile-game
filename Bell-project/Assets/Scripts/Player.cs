using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour 
{
	[Header("Stats")]

	public int preFace;
	public Vector3 preAngle;
	public int id;							//The unique identifier for this player.
	public int health;						//The current health of the tank.
	public int maxHealth = 500;					//The maximum health of this tank.
	public int energy = 500;
	public int damage;						//How much damage this tank can do when shooting a projectile.
	public float moveSpeed;					//How fast the tank can move.
	public float turnSpeed;					//How fast the tank can turn.
	public float projectileSpeed;			//How fast the tank's projectiles can move.
	public float reloadSpeed;				//How many seconds it takes to reload the tank, so that it can shoot again.
	private float reloadTimer;				//A timer counting up and resets after shooting.

	[HideInInspector]
	public Vector3 direction;				//The direction that the tank is facing. Used for movement direction.
	public Vector3 bulletDirection;
	[Header("Bools")]
	public bool canMove;					//Can the tank move if it wants to?
	public bool canShoot;					//Can the tank shoot if it wants to?
	//	public VirtualJoystick joystick;
	[Header("Components / Objects")]
	public Rigidbody rig;					//The tank's Rigidbody2D component. 
	public GameObject projectile;			//The projectile prefab of which the tank can shoot.
	public GameObject deathParticleEffect;	//The particle effect prefab that plays when the tank dies.
	public Transform muzzle;				//The muzzle of the tank. This is where the projectile will spawn.
	public Games game;						//The Game.cs script, located on the GameManager game object.

	void Start ()
	{
		direction = Vector3.zero;	//Sets the tank's direction up, as that is the default rotation of the sprite.
		bulletDirection = Vector3.zero;
		energy = 500;
		preFace = 1;
		preAngle = new Vector3(0,0,-1);
	}

	//Called by the Game.cs script when the game starts.
	//	public void SetStartValues ()
	//	{
	//		//Sets the tank's stats based on the Game.cs start values.
	//		health = game.tankStartHealth;
	//		maxHealth = game.tankStartHealth;
	//		damage = game.tankStartDamage;
	//		moveSpeed = game.tankStartMoveSpeed;
	//		turnSpeed = game.tankStartTurnSpeed;
	//		projectileSpeed = game.tankStartProjectileSpeed;
	//		reloadSpeed = game.tankStartReloadSpeed;
	//	}
	//
	void Update ()
	{
		reloadTimer += Time.deltaTime;
	}
	public void JoyMove (float x, float y) {
		Vector3 nextAngle = new Vector3 (x, 0, y);

		Debug.Log (x);
		Debug.Log (y);
//		float angle = 0;
		if (x != 0 && y != 0) 
		{
//			float angle = Vector3.Angle(nextAngle, preAngle);
			float angle = angle_360(preAngle,nextAngle);
			Debug.Log (360); 
			Debug.Log (angle);

			transform.Rotate(0,angle,0);
			preAngle = nextAngle;
			Debug.Log (angle);
			bulletDirection = new Vector3 (x, 0, y);
		}


		//		Debug.Log (angle);
		direction = new Vector3 (x, 0, y);

//		transform.Rotate(0,0,angle);

		rig.velocity = direction * 500 * Time.deltaTime;	
	}

	//Called by the Controls.cs script. When a player presses their movement keys, it calls this function
	//sending over a "y" value, set to either 1 or 0, depending if they are moving forward or backwards.
	public void Move (int y)
	{

		int nextFace = y;
//		transform.Rotate(0,0,(preFace - nextFace) * 45);
		preFace = y;
		switch (y) 
		{
		case 1:
			direction = new Vector3 (0, 0, 1);
			transform.Rotate(0,0,(preFace - nextFace) * 45);

			break;
		case 2:
			direction = new Vector3 (1, 0, 1);
			break;
		case 3:
			direction = new Vector3 (1, 0, 0);
			break;
		case 4:
			direction = new Vector3 (1, 0, -1);
			break;
		case 5:
			direction = new Vector3 (0, 0, -1);
			break;
		case 6:
			direction = new Vector3 (-1, 0, -1);
			break;
		case 7:
			direction = new Vector3 (-1, 0, 0);
			break;
		case 8:
			direction = new Vector3 (-1, 0, 1);
			break;
		}

		//		switch (y) 
		//		{
		//		case 1: 
		//
		//			if (direction == Vector3.up) {
		//				
		//			} else if (direction == Vector3.down) {
		//				transform.Rotate (0, 0, 180);
		//			
		//			} else if (direction == Vector3.left) {
		//				transform.Rotate (0, 0, -90);
		//			
		//			} else if (direction == Vector3.right) {
		//				transform.Rotate (0, 0, 90);
		//			}
		//			direction = Vector3.up;
		//		
		//
		//				break;
		//		case -1: 
		//				
		//
		//			if (direction == Vector3.up) {
		//				transform.Rotate (0, 0, 180);
		//			} else if (direction == Vector3.down) {
		//				
		//			
		//			} else if (direction == Vector3.left) {
		//				transform.Rotate (0, 0, 90);
		//			
		//			} else if (direction == Vector3.right) {
		//				transform.Rotate (0, 0, -90);
		//			}
		//			direction = Vector3.down;
		//				break;
		//		case 2: 
		//			if (direction == Vector3.up) {
		//				transform.Rotate (0, 0, 90);
		//			} else if (direction == Vector3.down) {
		//				transform.Rotate (0, 0, -90);
		//
		//			} else if (direction == Vector3.left) {
		//				
		//
		//			} else if (direction == Vector3.right) {
		//				transform.Rotate (0, 0, 180);
		//			}
		//			direction = Vector3.left;
		//				break;
		//		case -2: 
		//			if (direction == Vector3.up) {
		//				transform.Rotate (0, 0, -90);
		//			} else if (direction == Vector3.down) {
		//				transform.Rotate (0, 0, 90);
		//
		//			} else if (direction == Vector3.left) {
		//				transform.Rotate (0, 0, 180);
		//
		//			} else if (direction == Vector3.right) {
		//
		//			}
		//			direction = Vector3.right;
		//				break;
		//			
		//		
		//		case 3:
		//			direction = new Vector3(1,1,0);
		//			break;
		//
		//		}




		rig.velocity = direction * moveSpeed * Time.deltaTime;	
	}

	//Called by the Controls.cs script. When a player presses their turn keys, it calls this function
	//sending over an "x" value, set to either 1 or 0, depending if they are moving left or right.
	//	public void Turn (int x)
	//	{
	//		transform.Rotate(-Vector3.forward * x * turnSpeed * Time.deltaTime);
	//		direction = transform.rotation * Vector3.up;
	//	}
	//
//	Called by the Contols.cs script. When a player presses their shoot key, it calls this function, making the tank shoot.
		public void Shoot ()
		{
		Vector3 muzzPos = new Vector3 (muzzle.transform.position.x,muzzle.transform.position.y,-muzzle.transform.position.z);

//			if(reloadTimer >= reloadSpeed){													//Is the reloadTimer more than or equals to the reloadSpeed? Have we waiting enough time to reload?
		GameObject proj = Instantiate(projectile, muzzle.transform.position, Quaternion.identity) as GameObject;	//Spawns the projectile at the muzzle.
				Projectile projScript = proj.GetComponent<Projectile>();					//Gets the Projectile.cs component of the projectile object.
//				projScript.tankId = id;														//Sets the projectile's tankId, so that it knows which tank it was shot by.
//				projScript.damage = damage;													//Sets the projectile's damage.
//				projScript.game = game;														
		Debug.Log(proj);
		if (bulletDirection.magnitude >0) {
			Debug.Log(bulletDirection);

			projScript.rig.velocity = bulletDirection.normalized * 10;		//Makes the projectile move in the same direction that the tank is facing.

		}
		Debug.Log(energy);
				reloadTimer = 0.0f;															//Sets the reloadTimer to 0, so that we can't shoot straight away.
//			}
		if (energy - 25 < 0) {
			energy = 0;
		}
		else {
			energy-=25;
		}
	}

	//Called when the tank gets hit by a projectile. It sends over a "dmg" value, which is how much health the tank will lose. 
	//	public void Damage (int dmg)
	//	{
	//		if(game.oneHitKill){	//Is the game set to one hit kill?
	//			Die();				//If so instantly kill the tank.
	//			return;
	//		}
	//
	//		if(health - dmg <= 0){	//If the tank's health will go under 0 when it gets damaged.
	//			Die();				//Kill the tank since its health will be under 0.
	//		}else{					//Otherwise...
	//			health -= dmg;		//Subtract the dmg from the tank's health.
	//		}
	//	}

	//Called when the tank's health is or under 0.
	//	public void Die ()
	//	{
	//		if(id == 0){				//If the tank is player 1.
	//			game.player2Score++;	//Add 1 to player 2's score.
	//		}
	//		if(id == 1){				//If the tank is player 2.
	//			game.player1Score++;	//Add 1 to player 1's score.
	//		}
	//
	//		canMove = false;			//The tank can now not move.
	//		canShoot = false;			//The tank can now not shoot.
	//
	//		//Particle Effect
	//		GameObject deathEffect = Instantiate(deathParticleEffect, transform.position, Quaternion.identity) as GameObject;	//Spawn the death particle effect at the tank's position.
	//		Destroy(deathEffect, 1.5f);						//Destroy that effect in 1.5 seconds.
	//
	//		transform.position = new Vector3(0, 100, 0);	//Set the tanks position outside of the map, so that it is not visible when dead.
	//
	//		StartCoroutine(RespawnTimer());					//Start the RespawnTimer coroutine.
	//	}

	//Called when the tank has been dead and is ready to rejoin the game.
	//	public void Respawn ()
	//	{
	//		canMove = true;
	//		canShoot = true;
	//
	//		health = maxHealth;
	//
	//		transform.position = game.spawnPoints[Random.Range(0, game.spawnPoints.Count)].transform.position;	//Sets the tank's position to a random spawn point.
	//	}

	//Called when the tank dies, and needs to wait a certain time before respawning.
	//	IEnumerator RespawnTimer ()
	//	{
	//		yield return new WaitForSeconds(game.respawnDelay);	//Waits how ever long was set in the Game.cs script.
	//
	//		Respawn();											//Respawns the tank.
	//	}

	private float angle_360(Vector3 from_, Vector3 to_){  
		Vector3 v3 = Vector3.Cross(from_,to_);  
		if(v3.y > 0)  
			return Vector3.Angle(from_,to_);  
		else  
			return 360-Vector3.Angle(from_,to_);  
	} 
}
