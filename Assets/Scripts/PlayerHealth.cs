using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour {
	[SerializeField]private float health;
	private SpawnController spawnController;
	private GameOver gameOver;
	private Slider healthBar;
	public float getHealth {get{return health;}set{health = value;}}
	void Awake(){
		healthBar = GameObject.Find("HealthBarPlayer").GetComponent<Slider> ();
		gameOver = GameObject.Find ("EndScreen").GetComponent<GameOver> ();
		spawnController = GameObject.Find ("Main Camera").GetComponent<SpawnController> ();
		healthBar.maxValue = health;
		healthBar.value = health;
	}
	public void TakeDamage(float damage){
		if (damage < health) {
			health -= damage;
		} else {
			gameOver.GameOverScreen ();
			spawnController.ResetEnemyStats ();
		}
		healthBar.value = health;
	}
}