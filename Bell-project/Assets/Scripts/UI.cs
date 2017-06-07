using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	[Header("bar")]
	public Slider energyBar;
	public Slider healthBar;

	public Games game;

	// Use this for initialization
	public void SetBar () {
		energyBar.maxValue = 1000;
		energyBar.value = 1000;
		healthBar.maxValue = 1000;
		healthBar.value = 1000;
	}

	void Start() {
		
	}
	// Update is called once per frame
	void Update () {
		energyBar.value = game.player1.energy;
		healthBar.value = game.player1.health;
		Debug.Log ("UI");
		Debug.Log(energyBar.value);
	}
}
