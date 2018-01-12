using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordStickPlayer : MonoBehaviour {
	private Transform player;
	void Start () {
		player = GameObject.Find ("Player").GetComponent<Transform> ();
	}
    void Update () {
		transform.position = player.position;
	}
}
