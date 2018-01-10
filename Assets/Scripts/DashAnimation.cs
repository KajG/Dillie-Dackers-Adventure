using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAnimation : MonoBehaviour {

	public float moveSpeed;
	public float alphaSpeed;
	private string direction;
	private FetchInput fetchinput;
	private SpriteRenderer sprite;
	void Start () {
		fetchinput = GameObject.Find ("Main Camera").GetComponent<FetchInput> ();
		sprite = GetComponent<SpriteRenderer> ();
		if (fetchinput.getLastKey == FetchInput.KeyPressed.D) {
			transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
			direction = "right";
		} else {
			direction = "left";
		}
		StartCoroutine (SlashEffect ());
	}
	IEnumerator SlashEffect(){
		float alpha = 1;
		while (alpha >= 0) {
			if (direction == "left") {
				transform.position -= new Vector3 (moveSpeed, 0, 0);
			} else if (direction == "right") {
				{
					transform.position += new Vector3 (moveSpeed, 0, 0);
				}
			}
			alpha -= Time.fixedDeltaTime * alphaSpeed;
			sprite.color = new Color (sprite.color.r, sprite.color.g, sprite.color.b, alpha);
			yield return null;
		}
		Destroy (this.gameObject);
	}
}
