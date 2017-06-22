using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour {
	public Game game;
	public Text timerText;
	private float startTime;
	private bool finished = false;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(game.player.health <= 0)
		{
			finished = true;
			timerText.color = Color.yellow;
		}

		if (finished)
			return;

		float t = Time.time - startTime;
		string minute = ((int)t / 60).ToString();
		string second = (t % 60).ToString ("f2");

		timerText.text = minute + ":" + second;
	}
		
}
