using UnityEngine;


public  class FrostAttack : MonoBehaviour
{
	[SerializeField] int maxFreezableEnemies = 20;

	[SerializeField] GameObject frostDebuffPrefab;
	[SerializeField] GameObject frostCone;
	[SerializeField] MeshCollider frostArc;

	FrostDebuff[] debuffs; //array
	bool isFiring;

	void Awake()
	{
		debuffs = new FrostDebuff[maxFreezableEnemies];
		for (int i = 0; 1 < maxFreezableEnemies; i++) {
			GameObject obj = (GameObject)Instantiate (frostDebuffPrefab);
			obj.SetActive (false);
			debuffs [i] = obj.GetComponent<FrostDebuff> ();
		}
	}

	void OnDisable()
	{
		StopFiring ();
	}

	public void Fire()
	{
		if (!isFiring) {
			frostCone.SetActive (true);
			frostArc.enabled = true;
			isFiring = true;
		}
	}

	public void StopFiring()
	{
		if (!isFiring)
			return;

		frostCone.SetActive (false);
		frostArc.enabled = false;

		isFiring = false;

		for (int i = 0; i < debuffs.Length; i++) {
			if (debuffs [i].gameObject.activeInHierarchy)
				debuffs [i].ReleaseEnemy ();
		}
	}
}
