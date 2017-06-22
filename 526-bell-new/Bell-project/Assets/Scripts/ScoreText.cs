
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreText : MonoBehaviour {
	public Timer time;
	public Text score;
	// Use this for initialization
	void Start () {
		Debug.Log ("this is time : " + time.lastTime);
		Debug.Log (time.lastTime);
		score.text = time.lastTime;
	}
	

}
