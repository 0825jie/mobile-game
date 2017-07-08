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
	private bool finished;
	public string lastTime;
	private float t;
	private string minute;
	private string second;
	public static string finalScore;
	public static string cong;
	// Use this for initialization
	void Start () {
		finished = false;
		startTime = Time.time;

	}

	// Update is called once per frame
	void Update () {
		t = Time.time - startTime;
		int a = (int)t / 60;
		minute = (a).ToString();
		float b = t % 60;
		second = (t % 60).ToString ("f2");
		finalText.text = null;

		if(game.player.health <= 0)
		{
			finished = true;
			timerText.text = null;
			finalText.text = "Trojan Game Over !";
			int temp = (int)(a * 60 + b);
			Debug.Log("this is cur time" + temp);
			if (temp > 20) {
				finalScore = lastTime ;
				cong = "New Record!";
				Debug.Log("set new 000000000");
			} else {
				finalScore = lastTime;
				Debug.Log("set new 999999999999");
				cong = "";			
			}
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
