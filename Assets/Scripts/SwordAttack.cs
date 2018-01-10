using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SwordAttack : MonoBehaviour {
	[SerializeField]private BoxCollider2D col;
	[SerializeField]private GameObject attackAnim;
	[SerializeField]private GameObject dashAnim;
	[SerializeField]private float damage;
	[SerializeField]private float swordAnimTime;
	[SerializeField]private bool someoneHit;
	public List<GameObject> enemies = new List<GameObject>();
	public float getDamage{get{return damage;}set{damage = value;}}
	private CheckEnemy checkenemy;
	private FetchInput fetchinput;
	private SwordPhysics swordphysics;
	private DamageTextEffect damageText;
	void Start () {
		checkenemy = GameObject.Find ("RaycastPlayer").GetComponent<CheckEnemy> ();
		fetchinput = GameObject.Find ("Main Camera").GetComponent<FetchInput> ();
		col = GameObject.Find ("Collider").GetComponent<BoxCollider2D> ();
		swordphysics = GameObject.Find ("Sword").GetComponent<SwordPhysics> ();
		damageText = GameObject.Find ("Main Camera").GetComponents ();
	}
	void Update () {
		if (fetchinput.getLastKey == FetchInput.KeyPressed.A) {
			col.offset = new Vector2(1.2f, col.offset.y);
		} else if(fetchinput.getLastKey == FetchInput.KeyPressed.D){
			col.offset = new Vector2(-1.4f, col.offset.y);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			Attack (damage);
			AttackAnim ();
			swordphysics.AttackAnimation (fetchinput.getLastKey);
		}
	}
	public void Attack(float damage){
		for (int i = 0; i < checkenemy.enemyIndexes.Count; i++) {
			checkenemy.enemies [checkenemy.enemyIndexes[i]].GetComponent<EnemyHealth> ().TakeDamage (damage);
			damageText.CreateText (checkenemy.enemies [damage, checkenemy.enemyIndexes [i]].transform);
		}
	}
	public void AttackAnim(){
		Instantiate (attackAnim, new Vector3 (col.transform.position.x + col.offset.x * -2, col.transform.position.y, 0), Quaternion.identity);
	}
	public void DashAnim(){
		Instantiate (dashAnim, new Vector3 (col.transform.position.x + col.offset.x * -3, col.transform.position.y, 0), Quaternion.identity);
	}

}
