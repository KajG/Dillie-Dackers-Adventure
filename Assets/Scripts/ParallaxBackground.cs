using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour {
	[SerializeField]private float scrollingSpeed;
	[SerializeField]private float speed;
	[Range(0.2f, 0.99f)][SerializeField]private float backgroundDistance;
	private Transform playerPos;
	void Start () {
		playerPos = GameObject.Find ("Player").GetComponent<Transform> ();
	}
	void Update () {
		float x = Mathf.Lerp (transform.position.x, playerPos.position.x, Time.fixedDeltaTime * scrollingSpeed);
		transform.position = new Vector3 (x * backgroundDistance, transform.position.y, transform.position.z);
	}
}
