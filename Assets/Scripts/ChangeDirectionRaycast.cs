using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirectionRaycast : MonoBehaviour {
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			transform.localEulerAngles = new Vector3(0, 180, 0);
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			transform.localEulerAngles = new Vector3(0, 0, 0);
		}
	}
}
