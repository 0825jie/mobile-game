using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float startSpeed = 10f;

	[HideInInspector]
	public float speed;

	public float startHealth = 100;
	private float health;


	public int worth = 50;

	public GameObject deathEffect;

	[Header("Unity Stuff")]
	public Slider healthBar;

	private bool isDead = false;
	public SliderUITextUpdate Healthbar;

	void Start ()
	{
		speed = startSpeed;
		health = startHealth;
	}

	public void TakeDamage (float amount)
	{
		health -= amount;
		healthBar.value = health;
		Debug.Log ("jianxie!!!!!!!!!!!!!!!!");
		//healthBar.fillAmount = health / startHealth;
		//Canvas c = gameObject.Find("Canvas"); 

		if (health <= 0 && !isDead)
		{
			Die();
		}
	}



	void Die ()
	{
		isDead = true;



		GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 5f);



		Destroy(gameObject);
	}

}
