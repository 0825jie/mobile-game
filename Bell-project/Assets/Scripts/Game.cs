using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour 
{
	[Header("Setup")]
//	public Color player1Color = Color.green;			//The colour that player 1's tank will be when the game starts.
//	public Color player2Color = Color.red;				//The colour that player 2's tank will be when the game starts.
	public bool oneHitKill = false;						//Will a projectile instantly kill its target?
	public bool canDamageOwnTank = true;				//Can a tank damage itself by shooting a projectile?
	public int respawnDelay = 1;						//The amount of time a player will wait between dying and respawning.
	public int maxScore = 5;							//The score that when a player reaches, will end the game.
	public int maxProjectileBounces = 4;				//The maximum amount of times a projectile can bounce off walls.

	[Space(10)]
	public int playerStartHealth = 1000;						//The health the player tanks will get when the game starts.
	public int playerStartEnergy = 1000;
	public int playerStartDamage = 1;						//The damage the player tanks will get when the game starts.
	public float playerStartMoveSpeed = 70;				//The move speed the player tanks will get when the game starts.
	public float playerStartProNormalSpeed = 13;			//The projectile speed the player tanks will get when the game starts.
	public float playerStartProFireSpeed = 50;
	public float playerStartProLightingSpeed = 13;
	public float playerStartProEatSpeed = 13;
	public float playerStartProExplodeSpeed = 50;
//	public float playerStartReloadSpeed = 1;				//The reload speed the player tanks will get when the game starts.
	public int playerStartProjectileComsume = 20;
	public int playerEnergyRecoverSpeed = 10;
	public int playerHealthRecoverSpeed = 10;

	[Header("Player")]
	public Player player;							//Player 1's tank. 


	[Header("Spawn Points")]
	public List<GameObject> spawnPoints = new List<GameObject>();	//A list of all the spawn points, which the players can spawn at.

	[Header("Prefabs")]
	public GameObject wallPrefab;						//The wall prefab, which will be spawned at the start of the game to make up the level.

	[Header("Components")]
	public UI ui;										//The UI.cs script, located in the GameManager game object.

	void Start ()
	{

		//Tank Bools
		player.canMove = true;
		player.canShoot = true;


		//Tank Start Values
		player.SetStartValues ();

		ui.SetBars ();

	}

	void Update ()
	{
		//Checking Scores
//		if(player1Score >= maxScore){	//Does player 1 reach the score amount to win the game?
//			WinGame(0);					//Player 1 wins the game.
//		}		
//		if(player2Score >= maxScore){	//Does player 2 reach the score amount to win the game?
//			WinGame(1);					//Player 2 wins the game.
//		}
	}

	//Called when a player's score reaches the maxScore.
	//The "playerId" value, is the id of the player that won the game.
//	void WinGame (int playerId)
//	{
//		//Disable movement and shooting for the tanks.
//		player1Tank.canMove = false;
//		player1Tank.canShoot = false;
//
//		player2Tank.canMove = false;
//		player2Tank.canShoot = false;
//
//		ui.SetWinScreen(playerId);	//Call the SetWinScreen function in UI.cs, and send over the winning player's id.
//	}

	//Called when the level loads. It reads the map file and spawns in walls and spawn points.
}
