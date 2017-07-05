using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour {
	private PlayerMovement playermovement;
	void Start () {
		playermovement = GetComponent<PlayerMovement> ();
	}
	
	void Update () {
		
	}
	void OnCollisionStay2D(Collision2D other){
		if (other.gameObject.tag == "Floor") {
			playermovement.getAmountOfJumps = playermovement.getMaxJumps;
		}
	}
}
