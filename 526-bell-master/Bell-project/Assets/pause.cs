﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause : MonoBehaviour {
	public bool p;
	public Text pauseButton;
	// Use this for initialization
	void Start () {
		p = false;
	}

	// Update is called once per frame
	void Update () {

	}

	public void clicPause(){
		p = !p;
		if (!p) {
			Time.timeScale = 1;
			pauseButton.text = "Pause";
		} else {
			Time.timeScale = 0;
			pauseButton.text = "Restart";
		}
	}

}
