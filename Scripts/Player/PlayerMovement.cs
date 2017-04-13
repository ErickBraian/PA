using UnityEngine;

[RequireComponent(typeof(Animator)), RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
	
	[HideInInspector]public Vector3 moveDirection = Vector3.zero;       //Direção na qual o player deve mover-se.
	[HideInInspector]public Vector3 lookDirection = Vector3.forward;    // Direção na qual o player deve olhar.

	[SerializeField] float speed = 6f;
	[SerializeField] Animator animator;
	[SerializeField] Rigidbody rigidbody;

	bool CanMove = true;

	void Reset(){
		animator = GetComponent<Animator>();
		rigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate(){
		if (!CanMove) {
			return;
		}
		//Remove qualquer valode Y a direção de movimento.
		moveDirection.Set (moveDirection.x, 0, moveDirection.z); 
		rigidbody.MovePosition(transform.position + moveDirection.normalized * speed * Time.deltaTime);
		//Remove qualquer valode Y a direção que o personagem olhar.
		lookDirection.Set (lookDirection.x, 0, lookDirection.z);
		rigidbody.MoveRotation (Quaternion.LookRotation(lookDirection));

		//Altera parametros do animator para iniciar movimentação.
		animator.SetBool("IsWalking", moveDirection.sqrMagnitude > 0); // [moveDirection.sqrMagnitude > 0] seria uma "if" dentro de um setBoosl

	}


	public void Defeated(){
		CanMove = false;
	}
}