using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class Healthcontrol : MonoBehaviour {
	[SerializeField] private Graphic m_TargetGraphic;
	[SerializeField] private Text progressLabel;
	[SerializeField] private Text maxLabel;
	public Game game;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		Image image = this.m_TargetGraphic as Image;
		image.fillAmount = (float)game.player.health /(float)game.player.maxHealth;
		this.progressLabel.text = (image.fillAmount * 100).ToString ("0");
	}
}
