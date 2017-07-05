using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[SerializeField]private float jumpForce;
	[SerializeField]private int maxJumps;
	private int amountOfJumps;
	public int getMaxJumps{get{return maxJumps;}set{maxJumps = value;}}
	public int getAmountOfJumps {get{return amountOfJumps;}set{amountOfJumps = value;}}
	private Rigidbody2D rig;
	public float movementSpeed;
	public FetchInput fetchinput;

	void Start(){
		rig = GetComponent<Rigidbody2D> ();
		fetchinput = GameObject.Find ("Main Camera").GetComponent<FetchInput> ();
	}
	void Update () {
		if (fetchinput.getLeftKey) {
			GoDirection (-movementSpeed / 100);
		}
		if (fetchinput.getRightKey) {
			GoDirection (movementSpeed / 100);
		}
		if (Input.GetKeyDown (KeyCode.W) && amountOfJumps > 1) {
			rig.AddForce (new Vector2(0, jumpForce), ForceMode2D.Impulse);
			amountOfJumps--;
		}
	}
	void GoDirection(float numb){
		transform.position += new Vector3 (numb, 0, 0);
	}
}
