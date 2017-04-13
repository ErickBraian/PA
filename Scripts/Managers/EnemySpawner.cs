using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	[Header("Spawner Properties")]
	[SerializeField] GameObject enemyPrefab;
	[SerializeField] int maxEnemies = 10; // 10 por conta do poolling.
	[SerializeField] float spawnRate = 5f;

	EnemyHealth[] enemies; // esse é a coleção(polling) em array.
//	List<EnemyHealth> enemies; // esse é a coleção(polling) em lista.

	WaitForSeconds spawnDelay; //otimiza o waitForSeconds

	void Awake(){
		//cria um array para armazenar o POLL de objetos
		enemies = new EnemyHealth[maxEnemies];  //quantidade dos inimigos dentro do poolling em array.
//		enemies = new List<EnemyHealth>(); //quantidade dos inimigos dentro do poolling em Lista.

		//percorre o array, criando objetos e preenchendo-o com a referência para este

		/*Comentário referente ao {int tamanhoDoArray = enemies.Length;}
		 *economia de processamento, evita que dentro do for faça a leitura do 
		 *número de vezes em que é o enemies.Length, se enemies.Length 
		 *for 5000, ele fará a leitura 5000 vezes, porém se
		 *colocar uma variável fixa com o valor já predefinido ele lerá apenas uma vez
		*/int tamanhoDoArray = enemies.Length;
		for (int i = 0; i < tamanhoDoArray; i++) {
			GameObject obj = Instantiate (enemyPrefab) as GameObject; //cast
			EnemyHealth enemy = obj.GetComponent<EnemyHealth> ();
			obj.transform.SetParent (transform);
			obj.SetActive (false);
			enemies [i] = enemy;
		}
		spawnDelay = new WaitForSeconds (spawnRate); //otimiza o waitForSeconds
	}

	IEnumerator Start(){
		while (true) {
			yield return spawnDelay; //otimiza o waitForSeconds
			SpawnEnemy ();
		}
	}

	void SpawnEnemy(){
		for (int i = 0; i < maxEnemies; i++) {
			if (!enemies[i].gameObject.activeSelf) {
				enemies [i].transform.position = transform.position;
				enemies [i].transform.rotation = transform.rotation;
				enemies [i].gameObject.SetActive (true);
				return;
			}
		}
	}

}
