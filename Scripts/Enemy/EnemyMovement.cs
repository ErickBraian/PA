using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	[Header("Components")]
	[SerializeField] UnityEngine.AI.NavMeshAgent navMeshAgent;   // aqui o UnityEngine.Ai puxa só a variavel NavMesh e não precisa chamar um namespace ex:
	//UnityEngine.UI.Slider slide;     << esse é um exemplo
	[SerializeField] Animator animator;

	float originalSpeed;
	bool isRunningAway;
	Vector3 runAwayPosition;

	static WaitForSeconds updateDelay = new WaitForSeconds(0.5f); //

	void Reset(){
		navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		animator = GetComponent<Animator> ();
	}

	void OnEnable () {
		if (navMeshAgent != null) {
			navMeshAgent.enabled = true;
		}
		isRunningAway = false;
		StartCoroutine (ChasePlayer());
	}


	IEnumerator ChasePlayer(){
		yield return null;

		while (navMeshAgent.enabled) {  //olha o perigo.
			
			Transform target = GameManager.Instance.enemyTarget;// trocar pela referencia do enemyTarget no gamemanager.
			if (isRunningAway) {
				navMeshAgent.SetDestination (runAwayPosition);
			}else if (target !=null) {
				navMeshAgent.SetDestination (target.position);
			}

			yield return updateDelay;
		}

	}


	public void Defeated(){
		navMeshAgent.enabled = false;
	}

	//TO DO : 
	//Freeze (quando recebe ataque de Frost)
	//Unfreeze (retorna o movimento após efeito do ataque frost)
	//RunAway (quando recebe ataque stink)
	//ComeBack (após efeito do ataque stink)
}
