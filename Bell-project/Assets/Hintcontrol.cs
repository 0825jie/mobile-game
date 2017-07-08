using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hintcontrol : MonoBehaviour {
	private float displayTime1 = 3f;
	private float displayTime2 = 3f;
	public Text hint1;
	public Text hint2;
	private int count;
	private float timeCount;
	// Use this for initialization
	void Start () {
		count = 1;
	}

	// Update is called once per frame
	void Update () {
		timeCount += Time.deltaTime;
		displayTime1 -= Time.deltaTime;
		displayTime2 -= Time.deltaTime;
		if (displayTime1 <= 0.1f) {
			hint1.text = "";
		}
		if (displayTime2 <= 0.1f) {
			hint2.text = "";
		}

	}
	public void setText (string word) {
		count++;
		if (hint1.text == "") {
			displayTime1 = 3f;
			hint1.text = word;	
		} else if (hint2.text == "") {
			displayTime1 = 2f;
			hint2.text = word;
		} else {
			hint1.text = hint2.text;
			hint2.text = word;
			displayTime1 = 2f;
			displayTime1 = 3f;
		}

	}
	public float getCount() {
		return timeCount;
	}

}
