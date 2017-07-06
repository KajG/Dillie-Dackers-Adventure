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
	private Rigidbody2D rig;
	public float movementSpeed;
	public FetchInput fetchinput;
	private CheckEnemy checkenemy;
	private SwordAttack swordattack;

	void Start(){
		rig = GetComponent<Rigidbody2D> ();
		swordattack = GameObject.Find ("Sword").GetComponent<SwordAttack> ();
		checkenemy = GameObject.Find ("RaycastPlayer").GetComponent<CheckEnemy> ();
		fetchinput = GameObject.Find ("Main Camera").GetComponent<FetchInput> ();
	}
	void Update () {
		if (fetchinput.getLeftKey) {
			WalkDirectionX (-movementSpeed / 100);
		}
		if (fetchinput.getRightKey) {
			WalkDirectionX (movementSpeed / 100);
		}
		if (Input.GetKeyDown (KeyCode.W) && amountOfJumps > 1) {
			rig.AddForce (new Vector2(0, jumpForce), ForceMode2D.Impulse);
			amountOfJumps--;
		}
		if (Input.GetKeyDown (KeyCode.LeftShift) && fetchinput.getLastKey == 2) {
			StartCoroutine(DashDirectionX (-dashSpeed, dashTime));
		}
		if (Input.GetKeyDown (KeyCode.LeftShift) && fetchinput.getLastKey == 4) {
			StartCoroutine(DashDirectionX (dashSpeed, dashTime));
		}
	}
	void WalkDirectionX(float numb){
		transform.position += new Vector3 (numb, 0, 0);
	}
	IEnumerator DashDirectionX(float numb, float timer){
		bool hit = false;
		float time = timer;
		while(time >= 0){
			if (time <= timer / 1.6f && !hit) {
				swordattack.AttackAnim ();
				swordattack.Attack (swordattack.getDamage * 1.5f);
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
