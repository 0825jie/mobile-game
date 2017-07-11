using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hintcontrol : MonoBehaviour {
	private float displayTime1 = 5f;
	private float displayTime2 = 5f;
	public Text hint1;
	public Text hint2;
	public Text hint3;
	private int count;
	private float timeCount;
	public Player game;
	public Image img;
	private float imgCount = 1.5f;
	// Use this for initialization
	void Start () {
		img.enabled = false;
		count = 1;
	}

	// Update is called once per frame
	void Update () {
		timeCount += Time.deltaTime;
		displayTime1 -= Time.deltaTime;
		displayTime2 -= Time.deltaTime;
		imgCount -= Time.deltaTime;
		if (displayTime1 <= 0.1f) {
			if (hint2.text != "") {
				hint1.text = hint2.text;
				hint2.text = "";
				displayTime1 = 4f;
			} else {
				hint1.text = "";
			}
		}
		if (displayTime2 <= 0.1f) {
			hint2.text = "";
		}
		if (imgCount <= 0.05f) {
			img.enabled = false;
		}
	}
	public void setText (string word) {
		count++;
		if (hint1.text == "") {
			displayTime1 = 8f;
			hint1.text = word;	
		} else if (hint2.text == "") {
			displayTime2 = 8f;
			hint2.text = word;
		} else {
			hint1.text = hint2.text;
			hint2.text = word;
			displayTime1 = 4f;
			displayTime2 = 8f;
		}
		img.enabled = true;
		imgCount = 1.5f;

	}
	public float getCount() {
		return timeCount;
	}

}
