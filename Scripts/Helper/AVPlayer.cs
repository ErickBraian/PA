using UnityEngine;


public class AVPlayer : MonoBehaviour
{
	[SerializeField] ParticleSystem particleEffect;
	[SerializeField] AudioSource audioEffect;

	void Reset(){
		particleEffect = GetComponent<ParticleSystem> ();
		audioEffect = GetComponent<AudioSource> ();
	}

	public void Play(){
		if (particleEffect != null) {
			particleEffect.Play (true);	
		}
		if (audioEffect != null) {
			audioEffect.Play ();	
		}
	}
}

