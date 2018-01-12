using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour {
	[SerializeField]private BoxCollider2D col;
	[SerializeField]private GameObject attackAnim;
	[SerializeField]private GameObject dashAnim;
	[SerializeField]private int damage;
	[SerializeField]private bool someoneHit;
	public float critChance;
	public float critMultiplier;
	public float dashDamageMultiplier;
	public float slashDamageMultiplier;
	public float slashStartCooldown;
	public float dashStartCooldown;
	private float slashCooldown;
	public float dashCooldown;
	public List<GameObject> enemies = new List<GameObject>();
	public int getDamage{get{return damage;}set{damage = value;}}
	public float dashTime;
	public float dashSpeed;
	public Transform player;
	private CheckEnemy checkenemy;
	private FetchInput fetchinput;
	private SwordPhysics swordphysics;
	private DamageTextEffect damageText;
	void Start () {
		checkenemy = GameObject.Find ("RaycastPlayer").GetComponent<CheckEnemy> ();
		fetchinput = GameObject.Find ("Main Camera").GetComponent<FetchInput> ();
		col = GameObject.Find ("Collider").GetComponent<BoxCollider2D> ();
		swordphysics = GameObject.Find ("Sword").GetComponent<SwordPhysics> ();
		damageText = GameObject.Find ("Main Camera").GetComponent<DamageTextEffect>();
		player = GameObject.Find ("Player").GetComponent<Transform> ();
	}
	void Update () {
		if (fetchinput.getLastKey == FetchInput.KeyPressed.A) {
			col.offset = new Vector2(1.2f, col.offset.y);
		} else if(fetchinput.getLastKey == FetchInput.KeyPressed.D){
			col.offset = new Vector2(-1.4f, col.offset.y);
		}
		if (Input.GetMouseButtonDown (0) && slashCooldown <= 0) {
			Attack (damage, "slash");
			AttackAnim ();
			swordphysics.AttackAnimation (fetchinput.getLastKey);
			slashCooldown = slashStartCooldown;
		} else {
			slashCooldown -= Time.fixedDeltaTime;
		}
		if (dashCooldown <= 0) {
			if (Input.GetMouseButtonDown (1) && fetchinput.getLastKey == FetchInput.KeyPressed.A) {
				StartCoroutine (DashDirectionX (-dashSpeed, dashTime));
				dashCooldown = dashStartCooldown;
			}
			if (Input.GetMouseButtonDown (1) && fetchinput.getLastKey == FetchInput.KeyPressed.D) {
				StartCoroutine (DashDirectionX (dashSpeed, dashTime));
				dashCooldown = dashStartCooldown;
			}
		} else if(dashTime >= 0){
			dashCooldown -= Time.fixedDeltaTime;
		}
	}
	public void Attack(float damage, string typeOfAttack){
		for (int i = 0; i < checkenemy.enemyIndexes.Count; i++) {
			float randomDamage;
			bool crit = false;
			if (typeOfAttack == "slash") {
				randomDamage = Random.Range (damage, damage * slashDamageMultiplier);
				if (randomDamage >= critChance * (slashDamageMultiplier / 10) + (damage * (slashDamageMultiplier / 2))) {
					crit = true;
					randomDamage *= Random.Range(1.2f, critMultiplier);
				}
			} else {
				randomDamage = Random.Range (damage, damage * dashDamageMultiplier);
				if (randomDamage >= critChance * (dashDamageMultiplier / 10) + (damage * (dashDamageMultiplier / 2))) {
					crit = true;
					randomDamage *= Random.Range(1.2f, critMultiplier);
				}
			}
			checkenemy.enemies [checkenemy.enemyIndexes[i]].GetComponent<EnemyHealth> ().TakeDamage (randomDamage);
			damageText.CreateText (randomDamage, damage, checkenemy.enemies [checkenemy.enemyIndexes [i]].transform, crit);
		}
	}
	public void AttackAnim(){
		Instantiate (attackAnim, new Vector3 (col.transform.position.x + col.offset.x * -2, col.transform.position.y, 0), Quaternion.identity);
	}
	public void DashAnim(){
		Instantiate (dashAnim, new Vector3 (col.transform.position.x + col.offset.x * -3, col.transform.position.y, 0), Quaternion.identity);
	}
	IEnumerator DashDirectionX(float numb, float timer){
		bool hit = false;
		float time = timer;
		while(time >= 0){
			if (time <= timer / 1.6f && !hit) {
				DashAnim ();
				Attack (damage, "dash");
				swordphysics.AttackAnimation (fetchinput.getLastKey);
				hit = true;
			}
			checkenemy.distance = 5;
			time -= Time.fixedDeltaTime;
			player.position += new Vector3 (numb, 0, 0);
			yield return null;
		}
		checkenemy.distance = 2;
	}
}
