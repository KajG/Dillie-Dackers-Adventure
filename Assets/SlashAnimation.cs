using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAnimation : MonoBehaviour {

	private FetchInput fetchinput;
	void Start () {
		fetchinput = GameObject.Find ("Main Camera").GetComponent<FetchInput> ();
		if (fetchinput.getLastKey == FetchInput.KeyPressed.A) {
			transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		}
	}
}
