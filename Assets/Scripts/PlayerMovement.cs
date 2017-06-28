using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float movementSpeed;
	public FetchInput fetchinput;

	void Start(){
		fetchinput = GameObject.Find ("Main Camera").GetComponent<FetchInput> ();
	}
	void Update () {
		if (fetchinput.getLeftKey) {
			GoDirection (-movementSpeed / 100);
		}
		if (fetchinput.getRightKey) {
			GoDirection (movementSpeed / 100);
		}
	}
	void GoDirection(float numb){
		transform.position += new Vector3 (numb, 0, 0);
	}
}
