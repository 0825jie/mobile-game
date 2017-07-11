using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using System.Collections;
public class eat : MonoBehaviour {
	public Player player;
	public Button yourButton;
	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		player.eat();

	}
}
