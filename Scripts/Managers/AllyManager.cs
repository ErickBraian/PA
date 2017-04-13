using UnityEngine;
using UnityEngine.UI;

public class AllyManager : MonoBehaviour
{
	[SerializeField] int allyCost;
	[SerializeField] GameObject allyPrefab;
	[SerializeField] Transform allySpawnPoint;
	[SerializeField] Image allyImage;

	Ally ally;
	int allyPoints;

	void Awake(){
		GameObject obj = (GameObject)Instantiate (allyPrefab);
		obj.transform.parent = transform;
		ally = obj.GetComponent<Ally> ();
		obj.SetActive (false);

		if (allyImage != null) {
			allyImage.enabled = false;
		}

	}


	/*feito por Samuel
	 * 
	public void AddScore(int scoreValue){
		allyPoints += scoreValue;
		if (allyPoints >= allyCost) {
			AllyIsSpawnable ();
		}
	}

	bool AllyIsSpawnable(){
		Instantiate (allyPrefab, allySpawnPoint.transform.position, allySpawnPoint, transform.rotation);
		return false;
	}	
	
	*/
	//feito pelo professor
	public void AddPoints(int points){
		allyPoints += points;
		//verifica se pode spawnar
		if (CanSummonAlly()) {
			allyImage.enabled = true;
		}
		//se sim, libera o botão.
	}

	bool CanSummonAlly(){
		return (allyPoints >= allyCost) && !ally.gameObject.activeSelf;
	}

	public Ally SummonedAlly(){
		if (!CanSummonAlly ()) {
			return null;
		}

		ally.transform.position = allySpawnPoint.position;
		ally.transform.rotation = allySpawnPoint.rotation;

		ally.gameObject.SetActive (true);
		ally.Move(GameManager.Instance.enemyTarget.position); //Manda o aliado criado ir para a posição do player

		if (allyImage != null) {
			allyImage.enabled = false;
		}

		return ally;
	}

	public void UnSummonAlly(){
		//TO DO: modoficar essa regra de pontuação dos aliados
		allyPoints = 0;
		ally.gameObject.SetActive (false);
	}

}

