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
	private Rigidbody2D rig;
	public float movementSpeed;
	public FetchInput fetchinput;
	private CheckEnemy checkenemy;
	private SwordAttack swordattack;
	private SwordPhysics swordphysics;

	void Start(){
		rig = GetComponent<Rigidbody2D> ();
		swordattack = GameObject.Find ("Sword").GetComponent<SwordAttack> ();
		checkenemy = GameObject.Find ("RaycastPlayer").GetComponent<CheckEnemy> ();
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
		if (Input.GetKeyDown (KeyCode.W) && amountOfJumps > 1) {
			rig.AddForce (new Vector2(0, jumpForce), ForceMode2D.Impulse);
			amountOfJumps--;
		}
		if (Input.GetKeyDown (KeyCode.LeftShift) && fetchinput.getLastKey == FetchInput.KeyPressed.A) {
			StartCoroutine(DashDirectionX (-dashSpeed, dashTime));
		}
		if (Input.GetKeyDown (KeyCode.LeftShift) && fetchinput.getLastKey == FetchInput.KeyPressed.D) {
			StartCoroutine(DashDirectionX (dashSpeed, dashTime));
		}
	}
	void WalkDirectionX(float numb){
		transform.position += new Vector3 (numb, 0, 0);
	}
	void ChangeRotation(float angle){
		transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.y, angle);
	}
	IEnumerator DashDirectionX(float numb, float timer){
		bool hit = false;
		float time = timer;
		while(time >= 0){
			if (time <= timer / 1.6f && !hit) {
				swordattack.DashAnim ();
				swordattack.Attack (swordattack.getDamage * 1.5f);
				swordphysics.AttackAnimation (fetchinput.getLastKey);
				hit = true;
			}
			checkenemy.distance = 5;
			time -= Time.fixedDeltaTime;
			transform.position += new Vector3 (numb, 0, 0);
			yield return null;
		}
		checkenemy.distance = 2;
	}
}
