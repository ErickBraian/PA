using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour {
	void Update () {
		if (MouseLocation.Instance != null && MouseLocation.Instance.isValid) {
			transform.LookAt (MouseLocation.Instance.mousePosition);
		}
	}
}
