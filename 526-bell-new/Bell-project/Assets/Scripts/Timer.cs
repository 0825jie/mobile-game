using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour {
	public Game game;
	public Text timerText;
	public Text finalText;
	private float startTime;
	private bool finished = false;
	public string lastTime;
	private float t;
	private string minute;
	private string second;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		 t = Time.time - startTime;
		 minute = ((int)t / 60).ToString();
		 second = (t % 60).ToString ("f2");
		finalText.text = null;

		if(game.player.health <= 0)
		{
			finished = true;
			timerText.text = null;
			finalText.text = "Your Score: "+lastTime;
			return;

		}

		if (!finished)
			keepChanging ();




	}

	void keepChanging() {
		timerText.text = minute + ":" + second;
		lastTime = minute + ":" + second;
	}
		
}
