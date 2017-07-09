using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class Energycontrol : MonoBehaviour {
	[SerializeField] private Graphic m_TargetGraphic;
	[SerializeField] private Text progressLabel;
	[SerializeField] private Text maxLabel;
	private float countTime = 0.5f;
	public Game game;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		countTime -= Time.deltaTime;
		Image image = this.m_TargetGraphic as Image;
		float ratio = (float)game.player.energy /(float)game.player.maxEnergy;;
		image.fillAmount = ratio;
		//		float curNumber = Random.Range (0f, 10f); 
//		if (ratio < 0.2f) {
//			image.color = Color.red;
//		} else if (ratio < 0.4f) {
//			image.color = Color.yellow;
//		} else {
//			image.color = Color.green;
//		}

		if (countTime <= 0.05f) {
			this.progressLabel.text = (game.player.energy).ToString ("0");
			this.maxLabel.text = "/ " + (game.player.maxEnergy).ToString ("0");
			countTime = 0.5f;
		}
	}
}
