using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class V2: MonoBehaviour, IDragHandler, IPointerUpHandler,IPointerDownHandler {
	private Image bgImg;
	private Image joystickImg;
	private Vector3 inputVector;
	public Player Playerone;

	private void Start()
	{
		bgImg = GetComponent<Image> ();
		joystickImg = transform.GetChild (0).GetComponent<Image> ();
	}

	public virtual void OnPointerDown(PointerEventData ped)
	{
		Playerone.Shoot ();
	}
	public virtual void OnPointerUp(PointerEventData ped)
	{
		inputVector = Vector3.zero;
		joystickImg.rectTransform.anchoredPosition = Vector3.zero;
	}

	public virtual void OnDrag(PointerEventData ped)
	{
		Playerone.Shoot ();
	}
	public float Horizontal()
	{
		if (inputVector.x != 0)
			return inputVector.x;
		else
			return Input.GetAxis ("Horizontal");
	}
	public float Vertical()
	{
		if (inputVector.y != 0)
			return inputVector.y;
		else
			return Input.GetAxis ("Vertical");
	}
	public int Test() {
		return 8888;	
	}
}
