using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	[Header ("Stats")]
	public Animator animator;
	public int preFace;
	public Vector3 preAngle;
	public int id;
	//The unique identifier for this player.
	public int health;
	//The current health of the tank.
	public int maxHealth;
	public int energy;
	public int maxEnergy;
	//The maximum health of this tank.

	public int damage;
	//How much damage this tank can do when shooting a projectile.
	public float moveSpeed;
	//How fast the tank can move.
	//	public float turnSpeed;					//How fast the tank can turn.
	public float proNormalSpeed;
	//How fast the tank's projectiles can move.
	public float proFireSpeed;
	public float proLightingSpeed;
	public float proEatSpeed;
	public float proExplodeSpeed;
	public float proWindSpeed;
	//	public float reloadSpeed;				//How many seconds it takes to reload the tank, so that it can shoot again.
	//	private float reloadTimer;				//A timer counting up and resets after shooting.
	public int healthRecoverSpeed;
	public int energyRecoverSpeed;
	public int projectileConsume;
	//How fast the tank's projectiles can move.

	public int shootState;





	AudioSource bulletaudio;


	[HideInInspector]
	public Vector3 direction;
	//The direction that the tank is facing. Used for movement direction.

	[Header ("Bools")]
	public bool canMove;
	//Can the tank move if it wants to?
	public bool canShoot;
	//Can the tank shoot if it wants to?
	//	public VirtualJoystick joystick;
	[Header ("Components / Objects")]
	public Rigidbody rig;
	//The tank's Rigidbody2D component.
	public GameObject pronormal;
	//The projectile prefab of which the tank can shoot.
	public GameObject lighting;
	//The projectile prefab of which the tank can shoot.
	public GameObject fire;
	public GameObject explode;
	public GameObject wind;
	public GameObject eatBullet;

	public GameObject deathParticleEffect;
	//The particle effect prefab that plays when the tank dies.
	public Transform muzzle;
	//The muzzle of the tank. This is where the projectile will spawn.
	public Game game;
	//The Game.cs script, located on the GameManager game object.

	public Transform partTorotate;
	public GameObject healthIcon;
	public GameObject energyIcon;

	public GameObject lightningShield;
	public GameObject fireShield;
	public GameObject coldShield;
	public GameObject windShield;


	public Transform target;
	public float range;
    public GameObject bureet;
	public string enemytag1 = "enemy";
	public string enemytag2 = "enemy-fire";
	public string enemytag3 = "enemy-lighting";
	public string enemytag4 = "enemy-wind";

	public float turnspeed = 10f;
	public string bulletType = "shoot";
	public float time;








	private GameObject weap;
	public Sprite imge1;
	public Sprite imge2;
	public Sprite imge3;
	public Sprite imge4;
	public Sprite imge5;
	private bool isStartTimer;
	public float clickstate=1;
	private float timer = 0;
	public Image filledimage;

	void Updateweap( int stall)
	{  
		
	}
			
	void lockontaget()
	{

					Vector3 dir = target.position - transform.position;
		           transform.forward = dir;

		//		Quaternion lookRotation = Quaternion.LookRotation (dir);
//		Vector3 rotation = Quaternion.Lerp (partTorotate.rotation, lookRotation, Time.deltaTime * turnspeed).eulerAngles;
//		partTorotate.rotation = Quaternion.Euler (0f,rotation.y,0f);
	
	}








	void Start ()
	{
		direction = Vector3.zero;	//Sets the tank's direction up, as that is the default rotation of the sprite.

		preFace = 1;

		preAngle = new Vector3 (0, 0, -1);
		bulletaudio = GetComponent<AudioSource> ();
		InvokeRepeating ("Updatetarget", 0f, 0.5f);
	
		time = 0.0f;
		shootState = 5;
	}

	void Updatetarget ()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("enemy");
		//	GameObject[] enemies2 = GameObject.FindGameObjectsWithTag (enemytag2);
//		GameObject[] enemies3 = GameObject.FindGameObjectsWithTag (enemytag3);
//		GameObject[] enemies4 = GameObject.FindGameObjectsWithTag (enemytag4);
//
//		GameObject[] enemies = { };
//
//		enemies1.CopyTo(enemies, 0);
//
//		enemies2.CopyTo(enemies, enemies1.Length);
//
//		enemies3.CopyTo (enemies, enemies1.Length + enemies2.Length);
//
//		enemies4.CopyTo (enemies, enemies1.Length + enemies2.Length+enemies3.Length);

	






		float shortest = Mathf.Infinity;
		GameObject neartest = null;
		foreach (GameObject enemy in enemies) {
		
			float distanceToenemy = Vector3.Distance (transform.position, enemy.transform.position);
			if (distanceToenemy < shortest) {
				shortest = distanceToenemy;
				neartest = enemy;
			}
		
		
		}
		if (neartest != null && shortest <= range) {
			target = neartest.transform;
		} else {
		
			target = null;
		}
	}

	private void onDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawSphere (transform.position, range);
	}



	//	Called by the Game.cs script when the game starts.
	public void SetStartValues ()
	{
		//Sets the tank's stats based on the Game.cs start values.
		health = game.playerStartHealth;
		maxHealth = game.playerStartHealth;
		energy = game.playerStartEnergy;
		maxEnergy = game.playerStartEnergy;
//			damage = game.tankStartDamage;
		moveSpeed = game.playerStartMoveSpeed;
//			turnSpeed = game.tankStartTurnSpeed;
		proNormalSpeed = game.playerStartProNormalSpeed;
		proFireSpeed = game.playerStartProFireSpeed;
		proLightingSpeed = game.playerStartProLightingSpeed;
		proEatSpeed = game.playerStartProEatSpeed;
		proExplodeSpeed = game.playerStartProExplodeSpeed;
		proWindSpeed = game.playerStartProWindSpeed;
		projectileConsume = game.playerStartProjectileComsume;

		energyRecoverSpeed = game.playerEnergyRecoverSpeed;
		healthRecoverSpeed = game.playerHealthRecoverSpeed;

//			reloadSpeed = game.tankStartReloadSpeed;
	}
	//
	void Update ( )
	{   
		weap = GameObject.FindGameObjectWithTag ("ss");
		if (shootState== 5) {
			filledimage.fillAmount = 1;
			weap.GetComponent<Image> ().sprite = imge5;
			timer = 0;
		}

		if (shootState == 4) {
			

			weap.GetComponent<Image> ().sprite = imge4;
		

			timer += Time.deltaTime;
			filledimage.fillAmount = (8f - timer) / 8f;

			if (timer == 8f) {
				timer = 0;


			}


		}




		if (shootState == 3) {
			weap.GetComponent<Image> ().sprite = imge3;


			isStartTimer = true;
			clickstate = 0;
			timer += Time.deltaTime;
			filledimage.fillAmount = (8f - timer) / 8f;

			if (timer == 8f) {


				timer = 0;
				isStartTimer = false;
				clickstate = 1;
			}
		}
		if (shootState == 2) {
			weap.GetComponent<Image> ().sprite = imge2;
			isStartTimer = true;
			clickstate = 0;
			timer += Time.deltaTime;
			filledimage.fillAmount = (8f - timer) / 8f;

			if (timer == 8f) {


				timer = 0;
				isStartTimer = false;
				clickstate = 1;

			}

		}
		if (shootState == 1) {
			weap.GetComponent<Image> ().sprite = imge1;
			isStartTimer = true;
			clickstate = 0;
			timer += Time.deltaTime;
			filledimage.fillAmount = (8f - timer) / 8f;

			if (timer == 8f) {
				filledimage.fillAmount = 1;

				timer = 0;
				isStartTimer = false;
				clickstate = 1;
			}

		}
		//reloadTimer += Time.deltaTime;
		lockontaget ();


		if (shootState == 1 || shootState == 2 || shootState == 3 ||
		   shootState == 4) {
		
			time += Time.deltaTime;
		}
	


	

		if (time > 10f && shootState == 1) {
			shootState = 5;
			time = 0;
		}


		if (time > 10f && shootState == 2) {
			
			shootState = 5;
			time = 0;
		}

		if (time > 10f && shootState == 3) {

			shootState = 5;
			time = 0;
		}


		if (time > 10f && shootState == 4) {

			shootState = 5;
			time = 0;
		}
















	}

	public void ChangeState1 ()
	{
		health -= 100;
		
	}

	public void JoyMove (float x, float y)
	{
		Vector3 nextAngle = new Vector3 (x, 0, y);

		if (x != 0 && y != 0) {    
			float angle = angle_360 (preAngle, nextAngle);
			transform.Rotate (0, angle, 0);
			preAngle = nextAngle;
			animator.SetTrigger("run");

		}
			
		if (x == 0 || y == 0) {
			

        }


		if (game.player.health <= 2) {
			animator.SetTrigger ("dead");	


		}


		direction = new Vector3 (x, 0, y);
		rig.velocity = direction * 50 * moveSpeed * Time.deltaTime;	
	}

	//Called by the Controls.cs script. When a player presses their movement keys, it calls this function
	//sending over a "y" value, set to either 1 or 0, depending if they are moving forward or backwards.
	public void Move (int y)
	{
      
		int nextFace = y;
//		transform.Rotate(0,0,(preFace - nextFace) * 45);

		switch (y) {
		case 1:
			direction = new Vector3 (0, 0, 1);


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
			direction = new Vector3 (0, 0, 1);
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
//		transform.Rotate(0,0,(preFace - nextFace) * 45);
		preFace = y;
	




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
		switch (shootState) {
		case 1:
			explodeShoot ();
			break;
		case 2:
			windShoot ();
			break;
		case 3:
            iceShoot ();
			break;
		    case 4:
			lightningShoot();

			break;

		case 5:
			normalshoot ();
			break;




		}

	}






	public void normalshoot ()
	{
		GameObject proj = Instantiate (pronormal, muzzle.transform.position, Quaternion.identity) as GameObject;	//Spawns the projectile at the muzzle.
		ProNormal projScript = proj.GetComponent<ProNormal> ();	
		Destroy (proj, 5f);
		//play udio
		bulletaudio.Play ();  
		projScript.rig.velocity = transform.forward.normalized * proNormalSpeed;		//Makes the projectile move in the same direction that the tank is facing.

		//				reloadTimer = 0.0f;															//Sets the reloadTimer to 0, so that we can't shoot straight away.
		//			}
		if (energy - projectileConsume < 0) {
			energy = 0;
		} else {
			energy -= projectileConsume;
		}

	}


//	public void coldshoot ()
//	{
//		GameObject proj = Instantiate (pronormal, muzzle.transform.position, Quaternion.identity) as GameObject;	//Spawns the projectile at the muzzle.
//		ProNormal projScript = proj.GetComponent<ProNormal> ();	
//		Destroy (proj, 5f);
//		//play udio
//		bulletaudio.Play ();  
//		projScript.rig.velocity = transform.forward.normalized * proNormalSpeed;		//Makes the projectile move in the same direction that the tank is facing.
//
//		//				reloadTimer = 0.0f;															//Sets the reloadTimer to 0, so that we can't shoot straight away.
//		//			}
//		if (energy - projectileConsume < 0) {
//			energy = 0;
//		} else {
//			energy -= projectileConsume;
//		}
//	}




//	public void lightshoot ()
//	{
//		GameObject proj = Instantiate (pronormal, muzzle.transform.position, Quaternion.identity) as GameObject;	//Spawns the projectile at the muzzle.
//		ProLighting projScript = proj.GetComponent<ProLighting> ();	
//		Destroy (proj, 5f);
//		//play udio
//		bulletaudio.Play ();  
//		projScript.rig.velocity = transform.forward.normalized * proNormalSpeed;		//Makes the projectile move in the same direction that the tank is facing.
//
//		//				reloadTimer = 0.0f;															//Sets the reloadTimer to 0, so that we can't shoot straight away.
//		//			}
//		if (energy - projectileConsume < 0) {
//			energy = 0;
//		} else {
//			energy -= projectileConsume;
//		}
//	}








	public void lightningShoot ()
	{
////		Vector3 muzzPos = new Vector3 (muzzle.transform.position.x,muzzle.transform.position.y,-muzzle.transform.position.z);
//		GameObject proj = Instantiate(projectile, muzzle.transform.position, Quaternion.identity) as GameObject;	//Spawns the projectile at the muzzle.
//		Projectile projScript = proj.GetComponent<Projectile>();	
//
//		Destroy(proj,5f);
//		//play udio
//		bulletaudio.Play();  
//	
//
//		if (bulletDirection.magnitude >0) {
//
//			projScript.rig.velocity = bulletDirection.normalized * projectileSpeed;		//Makes the projectile move in the same direction that the tank is facing.
//
//		}
//
//		if (energy - projectileConsume < 0) {
//			energy = 0;
//		}
//		else {
//			energy -= (projectileConsume * 3);
//		}
//		DrawTool.DrawCircleSolid(game.player.transform, game.player.transform.localPosition, 30); 
		GameObject light = Instantiate (lighting, muzzle.transform.position, Quaternion.identity) as GameObject;	//Spawns the projectile at the muzzle.
//		ProLighting lightScript = lighting.GetComponent<ProLighting>();	
		Destroy (light, 2f);
		GameObject[] enermy1 = GameObject.FindGameObjectsWithTag ("enemy-ice");

		GameObject[] enermy2 = GameObject.FindGameObjectsWithTag ("enemy-fire");
		GameObject[] enermy3 = GameObject.FindGameObjectsWithTag ("enemy-wind");
		GameObject[] enermy4 = GameObject.FindGameObjectsWithTag ("enemy-lighting");

		GameObject[] enermy = new GameObject[enermy1.Length + enermy2.Length + enermy3.Length + enermy4.Length];
		enermy1.CopyTo (enermy, 0);
		enermy2.CopyTo (enermy, enermy1.Length);
		enermy3.CopyTo (enermy, enermy1.Length + enermy2.Length);
		enermy4.CopyTo (enermy, enermy1.Length + enermy2.Length + enermy3.Length);
	


		foreach (GameObject eachEnermy in enermy) {
			if (Vector3.Distance (game.player.transform.position, eachEnermy.transform.position) < 40) {
//				Destroy (eachEnermy);
				Enemy enemy = eachEnermy.GetComponent<Enemy> ();
				enemy.TakeDamage (50);
			}
		}

		if (energy - projectileConsume < 0) {
			energy = 0;
		} else {
			energy -= projectileConsume * 3;
		}


	}

	public void iceShoot ()
	{
		GameObject fires = Instantiate (fire, muzzle.transform.position, Quaternion.identity) as GameObject;	//Spawns the projectile at the muzzle.
		ProFire projScript = fires.GetComponent<ProFire> ();	
		Destroy (fires, 5f);
		projScript.rig.velocity = transform.forward.normalized * proFireSpeed;		//Makes the projectile move in the same direction that the tank is facing.

	
	}

	public void explodeShoot ()
	{

		GameObject explodes = Instantiate (explode, muzzle.transform.position, Quaternion.identity) as GameObject;	//Spawns the projectile at the muzzle.
		ProExplode projScript = explodes.GetComponent<ProExplode> ();
		Destroy (explodes, 5f);
		projScript.rig.velocity = transform.forward.normalized * proExplodeSpeed * 2;

	}
	public void windShoot() {
//		GameObject winds = Instantiate (wind, transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
		GameObject winds = Instantiate (wind, transform.position - new Vector3(0,10,0), Quaternion.Euler(0, 0, 0)) as GameObject;
		ProWind projScript = winds.GetComponent<ProWind> ();
		Destroy (winds, 5f);
		projScript.rig.velocity = transform.forward.normalized * proWindSpeed * 2;



//		Destroy (winds, 2f);
	}



	public void eat ()
	{
		
		GameObject eatBullets = Instantiate (eatBullet, muzzle.transform.position, Quaternion.identity) as GameObject;	//Spawns the projectile at the muzzle.
		ProEat projScript = eatBullets.GetComponent<ProEat> ();
		Destroy (eatBullets, 7f);
		projScript.rig.velocity = transform.forward.normalized * proEatSpeed;
	}

	public void changeState1 ()
	{
		
		GameObject  fireShields= Instantiate (fireShield, muzzle.transform.position, Quaternion.identity) as GameObject;
		fireShields.transform.parent = gameObject.transform;
		Destroy (fireShields, 7f);
	}




	public void changeState2 ()
	{
		GameObject windShields = Instantiate (windShield, muzzle.transform.position, Quaternion.identity) as GameObject;
		windShields.transform.parent = gameObject.transform;
		Destroy (windShields, 7f);
	}

	public void changeState3 ()
	{
		GameObject coldShields = Instantiate (coldShield, muzzle.transform.position, Quaternion.identity) as GameObject;
		coldShields.transform.parent = gameObject.transform;

		Destroy (coldShields, 7f);
	}

	public void changeState4 ()
	{


		GameObject lightningShields = Instantiate (lightningShield, muzzle.transform.position, Quaternion.identity) as GameObject;
		lightningShields.transform.parent = gameObject.transform;
		Destroy (lightningShields, 7f);
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

	private float angle_360 (Vector3 from_, Vector3 to_)
	{  
		Vector3 v3 = Vector3.Cross (from_, to_);  
		if (v3.y > 0)
			return Vector3.Angle (from_, to_);
		else
			return 360 - Vector3.Angle (from_, to_);  
	}

	private void OnCollisionEnter (Collision collision)
	{
		if (collision.transform.tag == "healthbox") {
			float curNumber = Random.Range (0f, 10f);
			if (curNumber < 6) {
				health = health + 500;
				GameObject g1 = Instantiate (healthIcon, collision.transform.position, collision.transform.rotation);
				Destroy (g1, 0.1f);
			} else {
				energy = energy + 500;
				GameObject g2 = Instantiate (energyIcon, collision.transform.position, collision.transform.rotation);
				Destroy (g2, 0.1f);
			}
//			else if (curNumber < 7) {
//				moveSpeed = moveSpeed * 2;
//			}
//			else if (curNumber < 9) {
//				moveSpeed = moveSpeed / 2;
//			}
//			else if (curNumber < 10) {
//				health = health - 500;
//			}

			if (health > game.player.maxHealth) {
				health = game.player.maxHealth;
			}
			Destroy (collision.gameObject);
//			gameObject.SetActive (false);
		}

	}

	public void TakeDamage (int damage)
	{
		health -= damage;
	}
}
