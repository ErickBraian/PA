using UnityEngine;


public class PlayerAttack : MonoBehaviour
{

	[SerializeField] LightningAttack lightningAttack;
	[SerializeField] FrostAttack frostAttack;
	[SerializeField] StinkAttack stinkAttack;
	[SerializeField] SlimeAttack slimeAttack;
	[SerializeField] int numberOfAttacks;

//	[SerializeField] CountDown countDown;

	int attackIndex = 0; //tipo de ataque selecionado
	float attackCooldown = 0f; //tempo necessario para realizar novo ataque
	float timeOfLastAttack; //tempo no qual o ultimo ataque foi realizado
	bool canAttack = true; //condição para ataque (permitido ou nao atacar)

	public void Fire(){
		
		if (!canAttack || !ReadyToAttack()) 
			return;
		


		switch (attackIndex) {
			case 0:
				ShootLightning ();
				break;

		case 1:
				ToogleFrost (true);
				break;
		}

	}

	public void StopFiring(){
		if (!canAttack) 
			return;

		switch (attackIndex){
		case 1:
			ToogleFrost (false);
			break;
		case 2:
			ShootStink ();
			break;
		case 3:
			ShootSlime();
			break;
		}
	}

	bool ReadyToAttack()
	{
		return Time.time >= timeOfLastAttack + attackCooldown;
	}

	public void SwitchAttack()
	{
		if (!canAttack) {
			return;
		}

		attackIndex++;
		if (attackIndex >= numberOfAttacks) {
			attackIndex = 0;
		}

		switch (attackIndex) {
		case 0:
			if (lightningAttack != null)
				lightningAttack.gameObject.SetActive (true);
				break;

		case 1:
			if (frostAttack != null)
				frostAttack.gameObject.SetActive (true);
			break;

		case 2:
			if (stinkAttack != null)
				stinkAttack.gameObject.SetActive (true);
			break;

		case 3:
			if (slimeAttack != null)
				slimeAttack.gameObject.SetActive (true);
			break;
		}
	}
		
	void ShootLightning(){
		if (lightningAttack == null)
			return;
		

		lightningAttack.Fire ();
		attackCooldown = lightningAttack.coolDown;
		BeginCountdown ();
	}
	void ToogleFrost(bool isAttacking){

	}

	void ShootStink(){
		
	}

	void ShootSlime(){
		
	}

	void BeginCountdown(){
		timeOfLastAttack = Time.time;
	}

	void DisableAttacks()
	{
		if (lightningAttack != null)
			lightningAttack.gameObject.SetActive (false);

		if (frostAttack != null)
			frostAttack.gameObject.SetActive (false);

		if (stinkAttack != null)
			stinkAttack.gameObject.SetActive (false);

		if (slimeAttack != null)
			slimeAttack.gameObject.SetActive (false);
	}

	public void Defeated ()
	{
		
	}
}