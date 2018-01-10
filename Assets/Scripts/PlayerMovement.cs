using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[SerializeField]private float jumpForce;
	[SerializeField]private int maxJumps;
	private int amountOfJumps;
	public int getMaxJumps{get{return maxJumps;}set{maxJumps = value;}}
	public int getAmountOfJumps {get{return amountOfJumps;}set{amountOfJumps = value;}}
	public float dashTime;
	public float dashSpeed;
	public float rotationSpeed;
	public float movementSpeed;
	public FetchInput fetchinput;
	private SwordPhysics swordphysics;
	private Rigidbody2D rb;
	void Start(){
		rb = GetComponent<Rigidbody2D> ();
		fetchinput = GameObject.Find ("Main Camera").GetComponent<FetchInput> ();
		swordphysics = GameObject.Find ("Sword").GetComponent<SwordPhysics> ();
	}
	void Update () {
		if (fetchinput.getLeftKey) {
			WalkDirectionX (-movementSpeed / 100);
			float angle = Mathf.LerpAngle (transform.localEulerAngles.z, swordphysics.desiredAngleLeft / 4, rotationSpeed * Time.fixedDeltaTime);
			ChangeRotation (angle);
		} else if (fetchinput.getRightKey) {
			WalkDirectionX (movementSpeed / 100);
			float angle = Mathf.LerpAngle (transform.localEulerAngles.z, -swordphysics.desiredAngleLeft / 4, rotationSpeed * Time.fixedDeltaTime);
			ChangeRotation (angle);
		} else {
			float angle = Mathf.LerpAngle (transform.localEulerAngles.z, 0, rotationSpeed * Time.fixedDeltaTime);
			ChangeRotation (angle);
		}
		if (Input.GetKeyDown (KeyCode.Space) && amountOfJumps > 1) {
			rb.velocity = Vector2.up * jumpForce;
			amountOfJumps--;
		} 
		if (rb.velocity.y < 0) {
			rb.velocity += Vector2.up * Physics2D.gravity.y * 1.5f * Time.fixedDeltaTime;
		}
	}
	void WalkDirectionX(float numb){
		transform.position += new Vector3 (numb, 0, 0);
	}
	void ChangeRotation(float angle){
		transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.y, angle);
	}
}
