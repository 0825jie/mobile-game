using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class attack : MonoBehaviour {
	public Player player;
	public Button yourButton;
	public GameObject weap;
	public Sprite imge1;
	public Sprite imge2;
	public Sprite imge3;
	public Sprite imge4;
	public Sprite imge5;



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
