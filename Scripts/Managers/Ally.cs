using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof( UnityEngine.AI.NavMeshAgent))]
public class Ally : MonoBehaviour
{
	[SerializeField] public float duration;
	[SerializeField] UnityEngine.AI.NavMeshAgent navMeshAgent;


	void Reset(){
		navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}

	public void Move(Vector3 point){
		navMeshAgent.SetDestination (point);
	}
}