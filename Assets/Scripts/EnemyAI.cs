using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	private Transform playerPos;
	private PlayerHealth playerhealth;
	void Start () {
		playerPos = GameObject.Find ("Player").GetComponent<Transform> ();
		playerhealth = GameObject.Find ("Player").GetComponent<PlayerHealth> ();
	}
	
	public void LightStomp(float damage){
		playerhealth.TakeDamage (damage);
		print("Damage lightStomp: " + damage);
	}
	public void HeavyStomp(float damage){
		playerhealth.TakeDamage (damage);
		print ("Damage heavyStomp: " + damage);
	}
	public void Idle(){

	}
	public void Walk(float walkSpeed){
		Vector3 desiredDirection = playerPos.position - transform.position;
		desiredDirection.Normalize ();
		transform.position += new Vector3((desiredDirection.x * walkSpeed), 0, 0);
	}
}
