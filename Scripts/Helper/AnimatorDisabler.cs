using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorDisabler : MonoBehaviour {
	[SerializeField]Animator animator;

	void Start(){
		animator.enabled = false;
	}
}
