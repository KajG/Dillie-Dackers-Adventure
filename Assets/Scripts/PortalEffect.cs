using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEffect : MonoBehaviour {
	[SerializeField]private float speed;
	private bool alphaActive;
	private SpriteRenderer rend;
	private float alpha = 1;
	void Start () {
		rend = GetComponent<SpriteRenderer> ();
		alphaActive = true;
	}
	void Update () {
		StartCoroutine (ChangeAlpha ());
	}
	IEnumerator ChangeAlpha(){
		if (alpha >= 1) {
			alphaActive = true;
		} else if(alpha <= 0){
			alphaActive = false;
		}
		if (alphaActive) {
			alpha -= Time.fixedDeltaTime * speed;
		} else {
			alpha += Time.fixedDeltaTime * speed;
		}
		rend.color = new Color (rend.color.r, rend.color.g, rend.color.b, alpha);
		yield return null;
	}
}
