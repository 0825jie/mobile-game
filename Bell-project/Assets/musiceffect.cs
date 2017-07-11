using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class musiceffect : MonoBehaviour {

	public Slider volumeButton2;
	public AudioSource audio1;

	// Update is called once per frame
	void Update () {
		audio1.volume = volumeButton2.value;
	}
}
