using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashFade : MonoBehaviour {

	[SerializeField] Image image;
	[SerializeField] Color flashColor = new Color (1f, 0f, 0f, 0.1f) ;
	[SerializeField] float flashSpeed = 5f;

	public void Flash(){
		StopCoroutine (Fade ());
		image.color = flashColor;
		StartCoroutine (Fade ());
	}

	IEnumerator Fade(){
		while (image.color.a > 0.1f) {
			image.color = Color.Lerp (image.color, Color.clear, flashSpeed * Time.deltaTime);   //lerp serve para interpolar(fazer uma transição).
			yield return null;
		}
		image.color = Color.clear;
	}

}
