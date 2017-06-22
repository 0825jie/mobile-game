using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGenerator : MonoBehaviour {

	public GameObject box;                // The enemy prefab to be spawned.
	public float spawnTime = 20f;            // How long between each spawn.
	public Transform[] spawnPoints;  
	public float destoryTime = 10f;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	void Spawn ()
	{
		// If the player has no health left...

		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		if(checkIfPosEmpty(spawnPoints[spawnPointIndex].position))
		{
			GameObject g = Instantiate (box, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
			Destroy (g, destoryTime);

		}
//		Instantiate (box, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}

	// Update is called once per frame
	void Update () {

	}



	public bool checkIfPosEmpty(Vector3 targetPos)
	{
		GameObject[] allMovableThings = GameObject.FindGameObjectsWithTag("healthbox");
		foreach(GameObject current in allMovableThings)
		{
			if(current.transform.position == targetPos)
				return false;
		}
		return true;
	}
}
