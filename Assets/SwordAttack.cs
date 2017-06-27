using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SwordAttack : MonoBehaviour {
	[SerializeField]private BoxCollider2D col;
	[SerializeField]private GameObject anim;
	[SerializeField]private float damage;
	[SerializeField]private float swordAnimTime;
	[SerializeField]private bool someoneHit;
	public List<GameObject> enemies = new List<GameObject>();
	private CheckEnemy checkenemy;
	private FetchInput fetchinput;
	void Start () {
		checkenemy = GameObject.Find ("Player").GetComponent<CheckEnemy> ();
		fetchinput = GameObject.Find ("Main Camera").GetComponent<FetchInput> ();
		col = GameObject.Find ("Collider").GetComponent<BoxCollider2D> ();
	}
	void Update () {
		if (fetchinput.getLastKey == 2) {
			col.offset = new Vector2(-0.96f, col.offset.y);
		} else {
			col.offset = new Vector2(0.96f, col.offset.y);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			Attack (damage);
			AttackAnim ();
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy") {
			checkenemy.SetEnemyIndex (other.gameObject);
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Enemy") {
			//someoneHit = false;
		}
	}
	void Attack(float damage){
		StartCoroutine (Attacking(damage));
	}
	void AttackAnim(){
		Destroy (Instantiate (anim, new Vector3(col.transform.position.x + col.offset.x * 2, col.transform.position.y, 0), Quaternion.identity), swordAnimTime);
	}
	IEnumerator Attacking(float damage){
		yield return new WaitForSeconds (swordAnimTime);
		checkenemy.enemies [checkenemy.enemyIndex].GetComponent<EnemyHealth> ().TakeDamage (damage);
	}
}
