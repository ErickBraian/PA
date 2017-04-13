using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAttack : MonoBehaviour {

	[SerializeField] float timeBeteenAttacks = 0.05f;
	[SerializeField] int attackDamage = 10;
	[SerializeField] Animator animator;

	bool canAttack;
	bool playerInRange;
	WaitForSeconds attackDelay;

	void Reset(){
		animator = GetComponent<Animator> ();
	}

	void Awake(){
		attackDelay = new WaitForSeconds (timeBeteenAttacks);
	}

	void OnEnable(){
		canAttack = true;
		StartCoroutine (AttackPlayer ());
	}

	IEnumerator AttackPlayer(){
		yield return null;
		if (GameManager.Instance == null) {
			yield break;
		}



		while (canAttack && CheckPlayerStatus()) {
			if (playerInRange) {
				GameManager.Instance.player.TakeDamage (attackDamage);
			}
			GameManager.Instance.player.TakeDamage (attackDamage);
		}
		yield return attackDelay;
	}

	void OnTriggerEnter(Collider other){
		if (other.transform == GameManager.Instance.player.transform) { // verifica se o outro collider é o collider do player, caso seja faz a ação.....isso evita que o "other" seja uma parede.
			playerInRange = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.transform == GameManager.Instance.player.transform) { // verifica se o outro collider é o collider do player, caso seja faz a ação.....isso evita que o "other" seja uma parede.
			playerInRange = false;
		}
	}

	bool CheckPlayerStatus(){
		if (GameManager.Instance.player.isAlive()) {
			return true;
		}
		animator.SetTrigger ("PlayerDead");
		Defeated ();
		return false;
	}

	public void Defeated(){
		canAttack = false;
	}
}
