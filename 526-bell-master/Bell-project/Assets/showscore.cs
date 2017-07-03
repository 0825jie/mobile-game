using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class showscore : MonoBehaviour {
	public Text showScoreText;
	// Use this for initialization
	void Start () {
		showScoreText.text = Timer.finalScore;
	}

	// Update is called once per frame

}
