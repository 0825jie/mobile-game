using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	[Header("bar")]
	public Slider energyBar;
	public Image healthFill;
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
		if (healthBar.value/healthBar.maxValue <0.15) {
			healthFill.color = Color.red;
		}
		else if (healthBar.value/healthBar.maxValue <0.4) {
			healthFill.color = Color.yellow;
		}
		else {
			healthFill.color = Color.green;
		}

		HealthText.textUpdate(healthBar.value,healthBar.maxValue);
		EnergyText.textUpdate(energyBar.value,energyBar.maxValue);

	}
}
