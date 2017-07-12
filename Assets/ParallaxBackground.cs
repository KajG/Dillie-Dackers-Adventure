using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour {
	[SerializeField]private float scrollingSpeed;
	[SerializeField]private float speed;
	private Transform playerPos;
	void Start () {
		playerPos = GameObject.Find ("Player").GetComponent<Transform> ();
	}
	
	void Update () {
		float x = Mathf.Lerp (transform.position.x, playerPos.position.x, Time.fixedDeltaTime * scrollingSpeed);
		transform.position = new Vector3 (x, transform.position.y, transform.position.z);
	}
}
