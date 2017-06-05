using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Games : MonoBehaviour {
	public Player player1;
	public Color player1Color = Color.green;

	// Use this for initialization
	void Start () {
		player1.canMove = true;
		player1.GetComponent<SpriteRenderer> ().color = player1Color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
