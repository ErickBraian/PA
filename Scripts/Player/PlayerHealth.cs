using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	[Header("Healt Properties")]
	[SerializeField] int maxHealth = 100;
	[SerializeField] AudioClip deathClip = null;

	[Header("Script References")]
	[SerializeField] PlayerMovement playerMovement;
	[SerializeField] PlayerAttack playerAtack;

	[Header("Components")]
	[SerializeField] Animator animator;
	[SerializeField] AudioSource audioSource;

	[Header("UI")]
	[SerializeField] FlashFade damageImage;
	[SerializeField] Slider healthSlider;

	int currentHealth;

	void Awake(){
		currentHealth = maxHealth;
	}

	public void TakeDamage(int amount){
		if (!isAlive()) {
			return;
		}

		currentHealth -= amount;
		damageImage.Flash ();


		if (!isAlive()) {			
			playerMovement.Defeated ();
			playerAtack.Defeated ();

			animator.SetTrigger ("Die");
			audioSource.clip = deathClip;
			GameManager.Instance.PlayerDied ();
		}
		audioSource.Play ();


	}

	public bool isAlive(){
		return currentHealth > 0; /// é a mesma coisa que 
		/*
			if (currentHealht > 0) {
				return true;
			}else{
				return false;
			}
		*/
	}

	void DeathComplete(){
		if (GameManager.Instance.player == this) {
			GameManager.Instance.PlayerDeathCompete ();
		}
	}
}
