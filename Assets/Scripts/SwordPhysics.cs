using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPhysics : MonoBehaviour {
	public float rotationSpeed;
	public float desiredAngleLeft;
	public float desiredAngleRight;
	public FetchInput fetchinput;

	void Start(){
		fetchinput = GameObject.Find ("Main Camera").GetComponent<FetchInput> ();
	}
	void Update () {
		if (fetchinput.getLeftKey) {
			float angle = Mathf.Lerp (transform.localEulerAngles.z, desiredAngleRight, rotationSpeed * Time.fixedDeltaTime);
			ChangeRotation (angle);
		} else if (fetchinput.getRightKey) {
			float angle = Mathf.Lerp (transform.localEulerAngles.z, desiredAngleLeft, rotationSpeed * Time.fixedDeltaTime);
			ChangeRotation (angle);
		} else {
			float angle = Mathf.Lerp (transform.localEulerAngles.z, 180, rotationSpeed * Time.fixedDeltaTime);
			ChangeRotation (angle);
		}
	}
	void ChangeRotation(float angle){
		transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.y, angle);
	}
}
