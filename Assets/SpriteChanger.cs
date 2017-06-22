using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour {
	public FetchInput fetchinput;
	void Start () {
		fetchinput = GameObject.Find ("Main Camera").GetComponent<FetchInput> ();
	}
	
	void Update () {
		if (fetchinput.getLeftKey) {
			transform.localScale = new Vector3 (0.3f, transform.localScale.y, transform.localScale.z);
		}
		if (fetchinput.getRightKey) {
			transform.localScale = new Vector3 (-0.3f, transform.localScale.y, transform.localScale.z);
		}
	}
}
