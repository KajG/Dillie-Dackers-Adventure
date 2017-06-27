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
	}
	
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.right, distance, layermask);
		if (hit.collider != null && hit.collider.tag == "Enemy") {
			print ("hitting + " + hit.collider.name);
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
