using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	[SerializeField]private float health;
	public float getHealth {get{return health;}set{health = value;}}
	public void TakeDamage(float damage){
		if (damage < health) {
			health -= damage;
		} else {
			Destroy (gameObject);
		}
	}
}
