using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jineng: MonoBehaviour {
	public GameObject m_object;
	public float calltime=10;
	public Image filledimage;
	private float timer = 0;
	private bool isStartTimer;
	public Player player;
	public Button yourButton;
	public KeyCode keycode;
	public float clickstate=1;
	// Use this for initialization

	void TaskOnClick()
	{  
			player.eat ();
	}
	// Update is called once per frame
	void Update() 
	{    
		


		if (isStartTimer) {
			clickstate = 0;
			timer += Time.deltaTime;
			filledimage.fillAmount = (calltime - timer) / calltime;

		}





		if (timer >= calltime) {
			filledimage.fillAmount = 1;
			timer = 0;
			isStartTimer = false;
			clickstate = 1;
	

		}
	}
	public void onclick()
	{
		isStartTimer = true;
		if (clickstate == 0) {
			player.Shoot ();
		
		}
		if (clickstate == 1) 
		{
			TaskOnClick ();
		}

	}



//	public void appear()
//	{
//
//		m_object.SetActive (true);
//
//	}
//
//	public void disappear()
//	{
//	
//		m_object.SetActive (false);
//	}














}
