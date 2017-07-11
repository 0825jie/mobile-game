using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeMusic : MonoBehaviour {

	public Slider volume;
	public AudioSource audio;
	
	// Update is called once per frame
	void Update () {
		audio.volume = volume.value;
	}
}
