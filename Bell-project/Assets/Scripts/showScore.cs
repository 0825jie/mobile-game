using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class showScore : MonoBehaviour {
	public Text showScoreText;
	public Text showbreakNew;
	// Use this for initialization
	void Start () {
		showScoreText.text = Timer.finalScore;
		showbreakNew.text = Timer.cong;
	}
	
	// Update is called once per frame

}
