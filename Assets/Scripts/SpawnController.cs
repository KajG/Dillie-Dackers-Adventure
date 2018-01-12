using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
	[SerializeField]private GameObject enemy;
	[SerializeField]private float maxTimer;
	private string enemyName;
	public float rounds;
	private float roundTimer;
	private List<GameObject> spawnPoints = new List<GameObject> ();
	private CheckEnemy checkEnemy;
	private ScoreController round;
	void Start () {
		checkEnemy = GameObject.Find ("RaycastPlayer").GetComponent<CheckEnemy> ();
		round = GameObject.Find ("UICanvas").GetComponent<ScoreController> ();
		spawnPoints.AddRange(GameObject.FindGameObjectsWithTag("Portal"));
		roundTimer = maxTimer;
		enemyName = enemy.name;
	}
	void Update () {
		roundTimer -= Time.fixedDeltaTime;
		if (roundTimer <= 0) {
			roundTimer = maxTimer;
			rounds++;
			roundTimer -= (rounds / 40);
			Spawn ();
			round.RefreshRound ();
		}
	}
	void Spawn(){
		int randomIndex = Random.Range (0, spawnPoints.Count);
		print (randomIndex);
		GameObject obj = Instantiate (enemy, spawnPoints [randomIndex].transform.position, Quaternion.identity);
		enemy.GetComponent<EnemyHealth> ().getHealth += (rounds * 2);
		enemy.GetComponent<EnemyBehaviour> ().moveSpeed += rounds / 10;
		obj.name = enemyName;
		checkEnemy.CheckEnemies ();
	}
}
