using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1AI : MonoBehaviour {
	[SerializeField]private EnemyAI enemyai;
	[SerializeField]private Transform playerPos;
	[SerializeField]private float distance;
	[SerializeField]private float walkSpeed;
	[SerializeField]private int lightStompPercent;
	[SerializeField]private float lightStompDamage;
	[SerializeField]private float heavyStompDamage;
	[SerializeField]private float lightStompMaxTimer;
	[SerializeField]private float heavyStompMaxTimer;
	private float lightStompTimer;
	private float heavyStompTimer;
	void Start () {
		enemyai = GameObject.Find ("Enemy").GetComponent<EnemyAI> ();
		playerPos = GameObject.Find ("Player").GetComponent<Transform> ();
	}
	
	void Update () {
		if (lightStompTimer >= 0) {
			lightStompTimer -= Time.fixedDeltaTime;
		}
		if (heavyStompTimer >= 0) {
			heavyStompTimer -= Time.fixedDeltaTime;
		}
		if (Vector3.Distance (playerPos.position, transform.position) <= distance) {
			enemyai.Walk (walkSpeed);
		}
		if (Vector3.Distance (playerPos.position, transform.position) <= distance / 4) {
			if (lightStompTimer <= 0) {
				enemyai.LightStomp (lightStompDamage);
				lightStompTimer = lightStompMaxTimer;
			} else if (heavyStompTimer <= 0) {
				enemyai.HeavyStomp (heavyStompDamage);
				heavyStompTimer = heavyStompMaxTimer;
			} 
		}
	}
}
