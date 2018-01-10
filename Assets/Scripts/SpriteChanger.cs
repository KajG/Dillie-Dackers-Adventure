using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour {
	public FetchInput fetchinput;
	float getScale;
	void Start () {
		fetchinput = GameObject.Find ("Main Camera").GetComponent<FetchInput> ();
		getScale = transform.localScale.x;
	}
	void Update () {
		if (fetchinput.getLeftKey) {
			transform.localScale = new Vector3 (-getScale, transform.localScale.y, transform.localScale.z);
		}
		if (fetchinput.getRightKey) {
			transform.localScale = new Vector3 (getScale, transform.localScale.y, transform.localScale.z);
		}
	}
}
