using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonMusic : MonoBehaviour {

	public Slider volumeButton;
	public AudioSource audio2;

	// Update is called once per frame
	void Update () {
		audio2.volume = volumeButton.value;
	}
}
