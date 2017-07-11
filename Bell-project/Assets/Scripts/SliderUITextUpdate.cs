using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUITextUpdate : MonoBehaviour {

	string sliderTextString = "500";
	public Text sliderText;
	public Slider mainSlider;

	void Awake(){
		mainSlider.maxValue = 500;
	}

	public void textUpdate(float textUpdateNumber1, float textUpdateNumber2)
	{
		sliderTextString = textUpdateNumber1.ToString () + "/" + textUpdateNumber2.ToString ();
		sliderText.text = sliderTextString;
	} 
}
