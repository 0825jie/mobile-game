using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	[Header("bar")]
	public Slider energyBar;

	public Games game;

	// Use this for initialization
	public void SetBar () {
		energyBar.maxValue = 1000;
		energyBar.value = 800;

	}

	void Start() {
		
	}
	// Update is called once per frame
	void Update () {
		energyBar.value = game.player1.energy;
		Debug.Log ("UI");
		Debug.Log(energyBar.value);
	}
}
