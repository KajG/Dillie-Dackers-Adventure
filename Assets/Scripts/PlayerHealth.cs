using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour {
	[SerializeField]private float health;
	private Slider healthBar;
	public float getHealth {get{return health;}set{health = value;}}
	void Start(){
		healthBar = GameObject.Find("HealthBarPlayer").GetComponent<Slider> ();
		healthBar.maxValue = health;
		healthBar.value = health;
	}
	public void TakeDamage(float damage){
		if (damage < health) {
			health -= damage;
		} else {
			gameObject.SetActive (false);
			Time.timeScale = 0;
		}
		healthBar.value = health;
	}
}