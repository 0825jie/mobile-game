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
    public Animator  dongzuo;
	void Start ()
	{
		speed = startSpeed;
		health = startHealth;
		dongzuo.SetTrigger ("Move");
	}


	void Die ()
	{
		isDead = true;
		GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect,3f);       
		Destroy(gameObject,1f);
		GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
	}


	public void TakeDamage (float amount)
	{    dongzuo.SetTrigger ("Take Damge");
		health -= amount;
		healthBar.value = health;
		
		//healthBar.fillAmount = health / startHealth;
		//Canvas c = gameObject.Find("Canvas"); 

		if (health <= 0)
		{    
			dongzuo.SetTrigger("Die");
			Die();

		}
	}





}
