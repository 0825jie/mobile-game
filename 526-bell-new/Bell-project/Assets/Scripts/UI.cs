using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	[Header("bar")]
	public Slider energyBar;
	public Slider healthBar;

	public SliderUITextUpdate HealthText;
	public SliderUITextUpdate EnergyText;


	public Game game;

	// Use this for initialization
	public void SetBars () {
		energyBar.maxValue = game.playerStartEnergy;
		energyBar.value = game.playerStartEnergy;
		healthBar.maxValue = game.playerStartHealth;
		healthBar.value = game.playerStartHealth;
	}

	void Start() {
		
	}
	// Update is called once per frame
	void Update () {
		energyBar.value = game.player.energy;
		healthBar.value = game.player.health;
		HealthText.textUpdate(healthBar.value,healthBar.maxValue);
		EnergyText.textUpdate(energyBar.value,energyBar.maxValue);

	}
}
