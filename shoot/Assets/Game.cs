﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour 
{
	[Header("Setup")]
	            
	public bool oneHitKill = false;                        //Will a projectile instantly kill its target?
	public bool canDamageOwnTank = true;                //Can a tank damage itself by shooting a projectile?
	public int respawnDelay = 1;                        //The amount of time a player will wait between dying and respawning.
	public int maxScore = 5;                            //The score that when a player reaches, will end the game.
	public int maxProjectileBounces = 4;                //The maximum amount of times a projectile can bounce off walls.

	[Space(10)]
	public int tankStartHealth = 2;                        //The health the player tanks will get when the game starts.
	public int tankStartDamage = 1;                        //The damage the player tanks will get when the game starts.
	public float tankStartMoveSpeed = 70;                //The move speed the player tanks will get when the game starts.
	public float tankStartTurnSpeed = 100;                //The turn speed the player tanks will get when the game starts.
	public float tankStartProjectileSpeed = 13;            //The projectile speed the player tanks will get when the game starts.
	public float tankStartReloadSpeed = 1;                //The reload speed the player tanks will get when the game starts.





	[Header("Scores")]

	public int playerScore;




	[Header("Maincharacter")]
	public Trojan player;           

	[Header("Spawn Points")]
	public List<GameObject> spawnPoints = new List<GameObject>();    //A list of all the spawn points, which the players can spawn at.

	[Header("Prefabs")]
	public GameObject wallPrefab;                        //The wall prefab, which will be spawned at the start of the game to make up the level.

	[Header("Components")]
//	public UI ui;                                       //The UI.cs script, located in the GameManager game object.

	private string mapToLoad;                            //The name of the map that is going to be loaded.

	void Start ()
	{
		//Load The Map
		mapToLoad = PlayerPrefs.GetString("MapToLoad");                                    
		TextAsset map = Resources.Load<TextAsset>("Maps/" + mapToLoad) as TextAsset;
		LoadMap(map.text);


		player.canMove = true;
		player.canShoot = true;

	
		//Set Tank Spawn Position
		player.transform.position = spawnPoints[0].transform.position;
		}

	void Update ()
	{
		//Checking Scores
		if(playerScore >= maxScore){    //Does player 1 reach the score amount to win the game?
			EndGame(0);                    //Player 1 wins the game.
		}        

	}

	//Called when a player's score reaches the maxScore.
	//The "playerId" value, is the id of the player that won the game.
	void EndGame (int playerId)
	{
		//Disable movement and shooting for the tanks.
		player.canMove = false;
		player.canShoot = false;

	
		  //Call the SetWinScreen function in UI.cs, and send over the winning player's id.
	}

	//Called when the level loads. It reads the map file and spawns in walls and spawn points.
	void LoadMap (string map)
	{
		string[] lines = map.Split("\n"[0]);    //Splits the file into seperate lines, each indicating a seperate tile.

		for(int x = 0; x < lines.Length; x++){                //Loop through all the tiles.
			if(lines[x] != ""){                                //Is the line not blank?
				string[] parts = lines[x].Split(","[0]);    //Then split that line at every comma.

				if(parts[0].Contains("Wall")){                //Is this tile a walll?
					GameObject wall = Instantiate(wallPrefab, new Vector3(float.Parse(parts[1]), float.Parse(parts[2]), 0), Quaternion.identity) as GameObject;    //Spawn in the wall game object.
				}
				else if(parts[0].Contains("SpawnPoint")){    //Is this tile a spawn point?
					GameObject spawnPoint = new GameObject("SpawnPoint");    //Spawn a blank game object which will be the spawn point.
					spawnPoint.transform.position = new Vector3(float.Parse(parts[1]), float.Parse(parts[2]), 0);    //Set the spawn point position.
					spawnPoints.Add(spawnPoint);            //Add the spawn point to the spawnPoints list.
				}
			}
		}
	}
}

