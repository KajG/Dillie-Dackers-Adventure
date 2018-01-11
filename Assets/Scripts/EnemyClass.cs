using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour {
	public Transform playerPos;
	public float maxDamageTimer;
	private float damageTimer;
	public float damage;
	public float chaseDistance;
	public float attackDistance;
	public float moveSpeed;
	private bool isAttacking;
	public float attackCooldown;
	void Start(){
		playerPos = GameObject.Find ("Player").GetComponent<Transform> ();
	}
	void Update(){
		if (Vector3.Distance (transform.position, playerPos.position) <= chaseDistance && !isAttacking) {
			Chase ();
		}
		if (attackCooldown > 0) {
			attackCooldown -= Time.fixedDeltaTime;
		} else {
			attackCooldown = 0;
		}
	}
	void Chase(){
		if (Vector3.Distance (transform.position, playerPos.position) >= attackDistance) {
			Vector3 desiredDirection = playerPos.position - transform.position;
			desiredDirection.Normalize ();
			transform.position += desiredDirection * moveSpeed;
		} else {
			Attack ();
		}
	}
	void Attack(){
		if (attackCooldown <= 0) {
			isAttacking = true;
			damageTimer = maxDamageTimer;
			while (damageTimer >= 0) {
				damageTimer -= Time.fixedDeltaTime;
			}
			if (Vector3.Distance (transform.position, playerPos.position) <= attackDistance) {
				print ("hit");
				playerPos.GetComponent<PlayerHealth> ().getHealth -= damage;
			}
			isAttacking = false;
			attackCooldown = 5;
		}
	}
}
