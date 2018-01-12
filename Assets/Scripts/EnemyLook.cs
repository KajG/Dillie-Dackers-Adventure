using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLook : MonoBehaviour {
	private Transform player;
	private float enemyScale;
	void Start(){
		player = GameObject.Find("Player").GetComponent<Transform>();
		enemyScale = transform.localScale.x;
	}
	void Update(){
		Vector3 pos = transform.position - player.position;
		if (pos.x <= 0) {
			transform.localScale = new Vector3 (enemyScale, transform.localScale.y, transform.localScale.z);
		} else {
			transform.localScale = new Vector3 (-enemyScale, transform.localScale.y, transform.localScale.z);
		}
	}

}
