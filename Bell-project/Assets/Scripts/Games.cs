using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Games : MonoBehaviour {
	public Player player1;
	public Color player1Color = Color.green;

	public UI ui;
	public int startEnergy = 500;

	// Use this for initialization
	void Start () {
		player1.canMove = true;
		player1.canShoot = true;
//		player1.GetComponent<SpriteRenderer> ().color = player1Color;
		ui.SetBar();
		ui.energyBar.value = 500;
		Debug.Log (111111111111111);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (123);
	}
}
