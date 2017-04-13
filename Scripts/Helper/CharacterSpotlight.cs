using UnityEngine;

public class CharacterSpotlight : MonoBehaviour {


	[SerializeField] GameObject spotPC;
	[SerializeField] GameObject spotMobile;

	void Awake(){
		#if UNITY_ANDROID || UNITY_IOS || UNITY_WP8
			spotMobile.SetActive(true);
		#else
			spotPC.SetActive(true);
		#endif
	}

	void Update(){
		if (GameManager.Instance.player != null) {
			gameObject.SetActive (false);
		}
	}

}
