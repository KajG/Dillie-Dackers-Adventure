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
	public delegate void AttackDel (float damage);
	public event AttackDel Attacked;
	public List<GameObject> enemies = new List<GameObject>();
	public EnemyHealth enemyHealth;
	private FetchInput fetchinput;
	private int enemyIndex;
	void Start () {
		fetchinput = GameObject.Find ("Main Camera").GetComponent<FetchInput> ();
		col = GameObject.Find ("Collider").GetComponent<BoxCollider2D> ();
		enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
	}
		
	void Update () {
		if (fetchinput.getLastKey == 2) {
			col.offset = new Vector2(-0.96f, col.offset.y);
		} else {
			col.offset = new Vector2(0.96f, col.offset.y);
		}
		if (Input.GetKeyDown (KeyCode.Space) && someoneHit) {
			Attack (damage);
			AttackAnim ();
		} else if(Input.GetKeyDown(KeyCode.Space)){
			AttackAnim ();
		}
		if (enemies [enemyIndex] == null) {
			enemies.RemoveAt (enemyIndex);
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy") {
			someoneHit = true;
			for (int i = 0; i < enemies.Count; i++) {
				if (other.gameObject == enemies [i]) {
					enemyIndex = i;
				}
			}
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Enemy") {
			someoneHit = false;
			enemyIndex = 0;
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
		enemies [enemyIndex].GetComponent<EnemyHealth> ().TakeDamage (damage);
	}
}
