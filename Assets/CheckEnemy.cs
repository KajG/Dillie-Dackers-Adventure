using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemy : MonoBehaviour {
	public List<GameObject> enemies = new List<GameObject>();
	public LayerMask layermask;
	public float distance;
	public int enemyIndex;
	public List<int> enemyIndexes = new List<int> ();
	void Start () {
		enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
	}
	void Update () {
		RaycastHit2D[] hits = Physics2D.RaycastAll (transform.position, transform.right, distance, layermask);
		List<GameObject> objs = new List<GameObject> ();
		for (int i = 0; i < hits.Length; i++) {
			if (hits[i].collider != null && hits[i].collider.tag == "Enemy") {
				objs.Add (hits [i].transform.gameObject);
			}
		}
		SetEnemyIndex (objs);
	}
	public void SetEnemyIndex(List<GameObject> obj){
		List<int> tempList = new List<int> ();
		for (int i = 0; i < obj.Count; i++) {
			for (int j = 0; j < enemies.Count; j++) {
				if (obj [i] == enemies [j]) {
					tempList.Add (j);
				}
			}
		}
		enemyIndexes = tempList;
		print (enemyIndexes.Count);
	}
}
