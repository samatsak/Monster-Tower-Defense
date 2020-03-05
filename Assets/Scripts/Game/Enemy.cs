using System.Collections;
using System.Collections.Generic;
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
	public Image healthBar;

	public bool isDead = false;
	Animator anim;

	void Start ()
	{
		speed = startSpeed;
		health = startHealth;
		anim = GetComponent<Animator> ();
	}

	public void TakeDamage (float amount)
	{
		health -= amount;

		healthBar.fillAmount = health / startHealth;

		if (health <= 0 && !isDead)
		{
			Die();
		}

	}

	public void Slow (float pct)
	{
		speed = startSpeed * (1f - pct);
	}

	void Die ()
	{
		gameObject.tag = "Untagged";
		isDead = true;
		anim.SetBool ("condition", true);

		PlayerStatus.Kill++;

		PlayerStatus.Money += worth;
		PlayerStatus.TotalMoney += worth;

		GameObject effect = (GameObject)PhotonNetwork.Instantiate (deathEffect.name, transform.position, Quaternion.identity, 0);
		Destroy(effect, 5f);

		WaveSpawner.EnemiesAlive--;

		Destroy(gameObject,5f);
	}
}
