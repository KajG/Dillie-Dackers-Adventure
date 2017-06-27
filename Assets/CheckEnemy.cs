using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemy : MonoBehaviour {
	public List<GameObject> enemies = new List<GameObject>();
	public LayerMask layermask;
	public float distance;
	public int enemyIndex;
	void Start () {
		enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
		enemyIndex = enemies.Count + 1;
	}
	void Update () {
		RaycastHit2D[] hit = Physics2D.RaycastAll (transform.position, transform.right, distance, layermask);
		if (hit[0].collider != null && hit[0].collider.tag == "Enemy") {
			print ("hitting : " + hit[0].collider.name);
			SetEnemyIndex (hit[0].transform.gameObject);
		} else {
			enemyIndex = enemies.Count + 1;
		}
	}
	public void SetEnemyIndex(GameObject obj){
		for (int i = 0; i < enemies.Count; i++) {
			if (obj == enemies [i]) {
				enemyIndex = i;
			}
		}
	}
}
