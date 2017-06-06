using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playershooter : MonoBehaviour {
	public float shootRate = 2;  
	public float attack = 30;  
	private float timer = 0;  
	private ParticleSystem particleSystem;  
	private LineRenderer lineRenderer; 



	// Use this for initialization
	void Start () {
		particleSystem = this.GetComponentInChildren<ParticleSystem>();  
		lineRenderer = this.GetComponent<Renderer>() as LineRenderer;
	}

	void OnEnable()
	{
		EasyButton.On_ButtonPress += On_ButtonPress;  

	}


	void On_ButtonPress(string buttonName)  
	{     
		//如果按下的是fire Button  
		if (buttonName == "Fire")  
		{  
			timer += Time.deltaTime;  
			if (timer > 1 / shootRate)  
			{  
				timer -= 1 / shootRate;  
				Shoot();  
			}  
		}  
	}  






	// Update is called once per frame
	void Update () {}

	void Shoot() {  
		GetComponent<Light>().enabled = true;  
		particleSystem.Play();  
		this.lineRenderer.enabled = true;  
		lineRenderer.SetPosition(0, transform.position);  
		Ray ray = new Ray(transform.position, transform.forward);  
		RaycastHit hitInfo;  
		if (Physics.Raycast(ray, out hitInfo))
		{  
			lineRenderer.SetPosition(1, hitInfo.point);  
			//判断当前的射击有没有碰撞到敌人  
			if (hitInfo.collider.tag == Tags.enemy) {  
				hitInfo.collider.GetComponent<EnemyHealth>().TakeDamage(attack,hitInfo.point);  
			}  

		} else {  
			lineRenderer.SetPosition(1, transform.position + transform.forward * 100);  
		}  
		//播放射击音效  
		GetComponent<AudioSource>().Play();  

		Invoke("ClearEffect", 0.05f);  
	}  









}
