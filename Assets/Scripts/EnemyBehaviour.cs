using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
	public Transform playerPos;
	public float damage;
	public float chaseDistance;
	public float attackDistance;
	public float moveSpeed;
	public bool isAttacking;
	public float attackTime;
	public float swingSpeed;
	private Transform sword;
	void Start(){
		playerPos = GameObject.Find ("Player").GetComponent<Transform> ();
		sword = GameObject.Find ("Enemy Sword").GetComponent<Transform> ();
	}
	void Update(){
		if (Vector3.Distance (transform.position, playerPos.position) <= chaseDistance && !isAttacking) {
			Chase ();
		}
	}
	void Chase(){
		if (isAttacking) {
			return;
		}
		Vector3 desiredDirection = playerPos.position - transform.position;
		desiredDirection.Normalize ();
		transform.position += desiredDirection * moveSpeed;
		if (Vector3.Distance (transform.position, playerPos.position) <= attackDistance) {
			isAttacking = true;
			StartCoroutine (Attack ());
		}
	}
	IEnumerator Attack(){
		Vector3 originalAngle = sword.localEulerAngles;
		float time = 0f;
		while (time <= attackTime) {
			time += Time.fixedDeltaTime;
			sword.localEulerAngles += new Vector3 (0, 0, time * 0.9f);
			if (time >= attackTime * 0.9f) {
				sword.localEulerAngles -= new Vector3 (0, 0, swingSpeed);
			}
			yield return null;
		}
		sword.localEulerAngles = originalAngle;
		print ("killemn owplz");
		if (Vector3.Distance (transform.position, playerPos.position) <= attackDistance) {
			playerPos.GetComponent<PlayerHealth> ().TakeDamage(damage);
			StartCoroutine (Attack ());
		} else {
			isAttacking = false;
		}
	}
}
