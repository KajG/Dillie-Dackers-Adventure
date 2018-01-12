using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
	public Transform playerPos;
	public float damage;
	public float damageMultiplier;
	public float chaseDistance;
	public float attackDistance;
	public float moveSpeed;
	public bool isAttacking;
	public float attackTime;
	public float swingSpeed;
	private float originalSpeed;
	private float originalHealth;
	private Transform sword;
	private DamageTextEffect damageText;
	void Start(){
		playerPos = GameObject.Find ("Player").GetComponent<Transform> ();
		damageText = GameObject.Find ("Main Camera").GetComponent<DamageTextEffect> ();
		sword = transform.GetChild (1);
		originalSpeed = moveSpeed;
		originalHealth = GetComponent<EnemyHealth>().getHealth;
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
		transform.position += desiredDirection * moveSpeed * Time.deltaTime;
		if (Vector3.Distance (transform.position, playerPos.position) <= attackDistance) {
			isAttacking = true;
			StartCoroutine (Attack ());
		}
	}
	IEnumerator Attack(){
		float randomDamage = Random.Range (damage, damage * damageMultiplier);
		Vector3 originalAngle = sword.localEulerAngles;
		float time = 0f;
		while (time <= attackTime) {
			time += Time.fixedDeltaTime;
			sword.localEulerAngles += new Vector3 (0, 0, time * 1.5f);
			if (time >= attackTime * 0.9f) {
				sword.localEulerAngles -= new Vector3 (0, 0, swingSpeed);
			}
			yield return null;
		}
		sword.localEulerAngles = originalAngle;
		if (Vector3.Distance (transform.position, playerPos.position) <= attackDistance && Time.timeScale != 0) {
			playerPos.GetComponent<PlayerHealth> ().TakeDamage(randomDamage);
			damageText.CreateText (randomDamage, damage, playerPos, false);
			StartCoroutine (Attack ());
		} else {
			isAttacking = false;
		}
	}
	public void ResetStats(){
		GetComponent<EnemyHealth> ().getHealth = originalHealth;
		moveSpeed = originalSpeed;
	}
}
