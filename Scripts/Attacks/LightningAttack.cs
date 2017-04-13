using UnityEngine;


public class LightningAttack : MonoBehaviour
{
	[Header("Weapon Specs")]public float coolDown = 1f;
	[SerializeField] int damage = 20;
	[SerializeField] float range = 20f;
	[SerializeField] LayerMask strikebleMask;

	[Header("Weapon References")]
	[SerializeField] LightningBolt lightningBolt;
	[SerializeField] AVPlayer lightningHit;

	public void Fire(){
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, range, strikebleMask)) {
			lightningHit.transform.position = hit.point;
			lightningHit.Play ();

			lightningBolt.endPoint = hit.point;

			//Tirar vida do inimigo (script EnemyHealth).
			EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();  // >>> pega o enemyHealt do inimigo que foi "hitado"
			if (enemyHealth != null) {
				enemyHealth.TakeDamage (damage);
			}


		} else {
			lightningBolt.endPoint = ray.GetPoint (range);
		}
		lightningBolt.gameObject.SetActive (true);
	}

}
