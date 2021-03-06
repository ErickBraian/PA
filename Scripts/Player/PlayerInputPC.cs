﻿using UnityEngine;


public class PlayerInputPC : MonoBehaviour {

	[SerializeField] PlayerMovement playerMovement = null;
	[SerializeField] PlayerAttack playerAttack = null;
	[SerializeField] PauseMenu pauseMenu = null;


	void Reset(){ //Metódo da unity. Prevê e preenche no Inpesctor autimaticamente as posições necessárias.s
		playerMovement = GetComponent<PlayerMovement>();
		playerAttack = GetComponent<PlayerAttack>();
		pauseMenu = FindObjectOfType<PauseMenu> (); // Procura em QUALQUER objeto dentro da Cena algum deles que tenha o script PauseMenu.
	}


	#if UNITY_ANDROID || UNITY_IOS || UNITY_WP8
	void Awake(){
	Destroy(this);
	}
	#endif

	void Update(){ 
		//Implementar a chamada do pause

		if (!CanUpdate())
			return;

		HandleMoveInput ();
		HandleAttackInput ();

	}

	bool CanUpdate(){//método boleano     //Evita Processar o Update desnecessáriamente.
		//ToDo: Verificar se o jogo está pausado
		if (GameManager.Instance.player == null || GameManager.Instance.player.transform != transform) {
			return false;
		}

		return true;
	}


	/// <summary>
	/// Handles the move input.
	/// </summary>
	void HandleMoveInput(){
		if (playerMovement == null) {
			Debug.Log ("Script playerMovement não encontrado");
			return;
		}

		float horizontal = Input.GetAxisRaw ("Horizontal");
		float vertical = Input.GetAxisRaw ("Vertical");

		//informa o playerMovement sobre o input realizado.
		playerMovement.moveDirection = new Vector3 (horizontal, 0, vertical);

		if (MouseLocation.Instance != null && MouseLocation.Instance.isValid) {
			Vector3 lookPoint = MouseLocation.Instance.mousePosition - playerMovement.transform.position;
			playerMovement.lookDirection = lookPoint;
		}
	}

	void HandleAttackInput(){
		if(playerAttack == null){
			Debug.Log ("Script Player Atack não encontrado");
			return;
		}

		if (Input.GetButtonDown("SwitchAttack")) {
			playerAttack.SwitchAttack ();
		}

		if (Input.GetButton("Fire1")) {
			//chama o metodo Fire() no Player Atack;
			playerAttack.Fire();

		}
		if (Input.GetButtonUp("Fire1")) {
			playerAttack.StopFiring ();
		}
	}

	void HandleAllyInput(){
		if (Input.GetButtonDown("SummonAlly") && GameManager.Instance != null) {
			GameManager.Instance.SummonAlly ();
		}
	}

}