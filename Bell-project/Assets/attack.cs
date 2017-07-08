using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using System.Collections;
public class attack : MonoBehaviour {
	public Player player;
	public Button yourButton;
	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		player.Shoot ();
		Debug.Log("You have clicked the button!");
	}
}
