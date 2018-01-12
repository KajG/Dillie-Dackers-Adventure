using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
	[SerializeField]private float health;
	[SerializeField]private GameObject sliceAnimation;
	private float maxHealth;
	public float maxSize;
	private Slider healthBar;
	public float getHealth {get{return health;}set{health = value;}}
	private ScoreController score;
	private EnemyBehaviour enemy;
	public float sliceAnimationTime;
	void Start(){
		healthBar = GetComponentInChildren<Slider> ();
		score = GameObject.Find ("UICanvas").GetComponent<ScoreController> ();
		enemy = GetComponent <EnemyBehaviour> ();
		healthBar.maxValue = health;
		healthBar.value = health;
		maxHealth = health;
	}
	public void TakeDamage(float damage){
		if (damage < health) {
			Destroy(Instantiate (sliceAnimation, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity), sliceAnimationTime);
			health -= damage;
		} else {
			Destroy (gameObject);
			float scoreMultiplier = (maxHealth * enemy.damage / 100);
			print (scoreMultiplier);
			score.AddScore ((int)scoreMultiplier);
		}
		healthBar.value = health;
	}
}
