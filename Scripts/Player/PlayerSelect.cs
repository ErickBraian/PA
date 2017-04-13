using UnityEngine;

public class PlayerSelect : MonoBehaviour {

	[SerializeField] PlayerSelect otherCharacter;


	[SerializeField] PlayerHealth playerHealth;
	[SerializeField] Rigidbody rigidbody;
	[SerializeField] CapsuleCollider capsuleCollider;
	[SerializeField] Animator animator;

	void Reset(){
		playerHealth = GetComponent<PlayerHealth> ();
		rigidbody = GetComponent<Rigidbody> ();
		capsuleCollider = GetComponent<CapsuleCollider> ();
		animator = GetComponent<Animator> ();
	}

	void OnMouseUp(){	
		
		GameManager.Instance.PlayerChosen (playerHealth);
		if (otherCharacter != null) {
			otherCharacter.DisableSelectableCharacter ();
		}
		enabled = false;
	}

	public void DisableSelectableCharacter(){
		capsuleCollider.enabled = false;
		animator.SetTrigger ("Die");
	}

	void DeathCompelte(){
		rigidbody.drag = 0;
		Destroy (gameObject, 1f);
	}
}

