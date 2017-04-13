using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	[Header("Health Proprieties")]
	[SerializeField] int maxHealth = 100;
	[SerializeField] int scoreValue = 10;

	[Header("Script References")]
	[SerializeField]EnemyMovement enemyMovement;
//	[SerializeField]EnemyAttack enemyAttack;

	[Header("Components")]

	[SerializeField] Animator animator;
	[SerializeField] AudioSource audioSource;
	[SerializeField] CapsuleCollider capsuleCollider;

	int currentHealth;
	bool isSinking;


	[SerializeField] float deathEffectTime = 2f;

	void Reset(){
		enemyMovement = GetComponent<EnemyMovement> ();
//		enemyAttack = GetComponent<EnemyAttack> ();
		animator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource> ();
		capsuleCollider = GetComponent<CapsuleCollider> ();
	}

	void OnEnable(){
		currentHealth = maxHealth;
	}

	void Update(){
		if (!isSinking) {
			return;
		}
		transform.Translate (-Vector3.up * 2.5f * Time.deltaTime);
	}

	public void TakeDamage(int amount){
		if (currentHealth <= 0) {
			return;
		}

		currentHealth -= amount;

		if (currentHealth <=0) {
			Defeated ();
		}

		//Torcar um som.
		if (audioSource != null) {
			audioSource.Play ();
		}
		//Tocar particulas.
	}


	void Defeated(){
		capsuleCollider.isTrigger = true;
	
		animator.enabled = true;  // segurança para o caso do ataque frost
		animator.SetTrigger ("Dead");	//roda animação de morte.

		//desativa enemyAtack.
		enemyMovement.Defeated();//desativa o enemyMovement.
		//atribui pontos ao player.
		Invoke("TurnOFF", deathEffectTime);
	}

	void TurnOFF(){
		gameObject.SetActive (false);
	}

	public void StartSinking(){
		isSinking = true;
	}

}
