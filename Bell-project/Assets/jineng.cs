using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jineng: MonoBehaviour {
	public GameObject m_object;
	public float calltime=10;
	private Image filledimage;
	private float timer = 0;
	private bool isStartTimer;
	public Player player;
	public Button yourButton;
	// Use this for initialization

	void TaskOnClick()
	{
		player.eat();

	}
	// Update is called once per frame
	void Update() 
	{
		if (isStartTimer) {
			timer += Time.deltaTime;
			filledimage.fillAmount = (calltime - timer) / calltime;
		}
		if (timer >= calltime) {
			filledimage.fillAmount = 0;
			timer = 0;
			isStartTimer = false;
		}
	}
	public void onclick()
	{
		isStartTimer = true;
		TaskOnClick ();

	}



	public void appear()
	{

		m_object.SetActive (true);

	}

	public void disappear()
	{
	
		m_object.SetActive (false);
	}














}
