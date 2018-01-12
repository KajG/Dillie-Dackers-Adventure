using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {
	private Transform playerPos;
	[SerializeField]private float speed;
	void Start () {
		playerPos = GameObject.Find ("Player").GetComponent<Transform> ();
	}
	void Update () {
		float x = Mathf.Lerp (transform.position.x, playerPos.position.x, Time.fixedDeltaTime * speed);
		transform.position = new Vector3 (x, transform.position.y, transform.position.z);
	}
}
