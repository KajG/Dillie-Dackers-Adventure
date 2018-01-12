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
			float angle = Mathf.LerpAngle (transform.localEulerAngles.z, desiredAngleRight, rotationSpeed * Time.fixedDeltaTime);
			ChangeRotation (angle);
		} else if (fetchinput.getRightKey) {
			float angle = Mathf.LerpAngle (transform.localEulerAngles.z, desiredAngleLeft, rotationSpeed * Time.fixedDeltaTime);
			ChangeRotation (angle);
		} else {
			float angle = Mathf.LerpAngle (transform.localEulerAngles.z, 0, rotationSpeed * Time.fixedDeltaTime);
			ChangeRotation (angle);
		}
	}
	void ChangeRotation(float angle){
		transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.y, angle);
	}
	public void AttackAnimation(FetchInput.KeyPressed lastKeyPressed){
		if (lastKeyPressed == FetchInput.KeyPressed.A) {
			ChangeRotation (100);
		}
		if (lastKeyPressed == FetchInput.KeyPressed.D) {
			ChangeRotation (-100);
		}
	}
}
