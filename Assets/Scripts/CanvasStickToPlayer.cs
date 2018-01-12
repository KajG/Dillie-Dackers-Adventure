using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasStickToPlayer : MonoBehaviour {
	public Transform playerPos;
	void Start () {
		playerPos = GameObject.Find ("Player").GetComponent<Transform> ();
	}
	void Update () {
		transform.position = new Vector3(playerPos.position.x, playerPos.position.y, 0);
	}
}
