using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class Healthcontrol : MonoBehaviour {
	[SerializeField] private Graphic m_TargetGraphic;
	[SerializeField] private Text progressLabel;
	[SerializeField] private Text maxLabel;
	public Game game;
	private float countTime = 0.5f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		countTime -= Time.deltaTime;
		Image image = this.m_TargetGraphic as Image;
		float ratio = (float)game.player.health /(float)game.player.maxHealth;;
		image.fillAmount = ratio;
//		float curNumber = Random.Range (0f, 10f); 
		if (ratio < 0.2f) {
			image.color = Color.red;
		} else if (ratio < 0.4f) {
			image.color = Color.yellow;
		} else {
			image.color = Color.green;
		}

		if (countTime <= 0.05f) {
		this.progressLabel.text = (game.player.health).ToString ("0");
		this.maxLabel.text = "/ " + (game.player.maxHealth).ToString ("0");
			countTime = 0.5f;
		}
	}
}
