using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	[SerializeField]float smoothing = 5;
	[SerializeField]Vector3 offset =  new Vector3(0f,15f,-22f);

	private Transform playerTransform;

	void Start()
	{
		playerTransform = GameManager.Instance.player.transform;
	}

	void FixedUpdate(){
		Vector3 targetCamPos = GameManager.Instance.player.transform.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);

	}

}
