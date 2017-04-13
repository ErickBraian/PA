using UnityEngine;


public class LightningBolt : MonoBehaviour
{

	[HideInInspector] public Vector3 endPoint;

	[Header("Bolt Properties")]
	[SerializeField] float rayHeight = 2f;  // altura em relação ao chão.
	[SerializeField] float effectDuration = 0.75f;
	[SerializeField] float phaseDuration = 0.1f;

	[Header("Bolt Renderinh")]
	[SerializeField] LineRenderer rayRenderer;
	[SerializeField] AnimationCurve[] rayPhases;

	int phaseIndex = 0;
	float timeToChangePhase;
	float timeSinceEffectStarted;
	Vector3 vectorOfBolt;

	void OnEnable(){
		timeToChangePhase = 0;
		timeSinceEffectStarted = 0;

	}

	void Update(){
		timeSinceEffectStarted +=Time.deltaTime;
		if (timeSinceEffectStarted >= effectDuration) {
			gameObject.SetActive (false);
		}

		vectorOfBolt = endPoint - transform.position;  //q

		if (timeSinceEffectStarted >= timeToChangePhase) {
			timeToChangePhase = timeSinceEffectStarted + phaseDuration;
			ChangePhase ();
		}
	}

	void ChangePhase(){
		phaseIndex++;
		if (phaseIndex >= rayPhases.Length) {
			phaseIndex = 0;
		}
		AnimationCurve curve = rayPhases [phaseIndex];
		rayRenderer.numPositions = curve.keys.Length;
		for (int index = 0; index < curve.keys.Length; ++index) {
			Keyframe key = curve.keys [index];
			Vector3 point = transform.position + vectorOfBolt * key.time;
			point += Vector3.up * key.value * rayHeight;
			rayRenderer.SetPosition (index, point);
		}

	}


}

