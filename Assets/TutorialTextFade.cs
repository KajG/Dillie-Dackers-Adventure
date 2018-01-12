using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTextFade : MonoBehaviour {
	private TextMesh text;

	void Start () {
		text = GetComponent<TextMesh> ();
		StartCoroutine (FadeText ());
	}
	
	void Update () {
		
	}
	IEnumerator FadeText(){
		float alpha = 1;
		while (alpha >= 0) {
			alpha -= Time.fixedDeltaTime / 10;
			text.color = new Color (text.color.r, text.color.g, text.color.b, alpha);
			yield return null;
		}
		Destroy (gameObject);
	}
}
