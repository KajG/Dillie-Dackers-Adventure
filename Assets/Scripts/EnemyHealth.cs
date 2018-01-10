using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
	[SerializeField]private int health;
	private Slider healthBar;
	public int getHealth {get{return health;}set{health = value;}}
	void Start(){
		healthBar = GetComponentInChildren<Slider> ();
		healthBar.maxValue = health;
		healthBar.value = health;
	}
	public void TakeDamage(int damage){
		if (damage < health) {
			health -= damage;
		} else {
			Destroy (gameObject);
		}
		healthBar.value = health;
	}
}
