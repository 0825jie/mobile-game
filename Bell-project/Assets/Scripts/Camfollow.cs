using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camfollow : MonoBehaviour {

	private Vector3 offset;
	public Transform player;

	void Start()
	{
		offset = player.position - transform.position;
	}

	void Update()
	{
		transform.position = Vector3.Lerp(transform.position, player.position - offset,Time.deltaTime*5);
	}
}
