using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextEffect : MonoBehaviour {
	public float speed;
	public float alphaSpeed;
	public float randomSpawnLimit;
	public float fontSizeScale;
	public int fontSize;
	public float critSize;
	public Font font;

	public void CreateText(float randomDamage, float damage, Transform objTrans, bool crit){
		if (!crit) {
			GameObject obj = new GameObject ();
			TextMesh text = obj.AddComponent<TextMesh> ();
			text.GetComponent<Renderer> ().material = font.material;
			text.text = "-" + (int)randomDamage;
			text.fontSize = fontSize;
			text.transform.localScale = new Vector3 (fontSizeScale, fontSizeScale, fontSizeScale);
			text.color = Color.red;
			text.font = font;
			obj.name = "damageText";
			obj.transform.position = new Vector3 (objTrans.position.x + Random.Range (-randomSpawnLimit, randomSpawnLimit), objTrans.position.y + objTrans.GetComponent<BoxCollider2D> ().bounds.size.y, objTrans.position.z);
			StartCoroutine (TextEffect (text, obj));
		} else {
			GameObject critObj = new GameObject ();
			TextMesh critText = critObj.AddComponent<TextMesh> ();
			critText.GetComponent<Renderer> ().material = font.material;
			critText.text = " CRIT -" + (int)randomDamage;
			critText.fontSize = fontSize;
			critText.transform.localScale = new Vector3 (fontSizeScale * critSize, fontSizeScale * critSize, fontSizeScale * critSize);
			critText.color = Color.yellow;
			critText.font = font;
			critObj.name = "damageText";
			critObj.transform.position = new Vector3 (objTrans.position.x + Random.Range (-randomSpawnLimit, randomSpawnLimit), objTrans.position.y + objTrans.GetComponent<BoxCollider2D> ().bounds.size.y, objTrans.position.z);
			StartCoroutine (TextEffect (critText, critObj));
		}
	}
	public IEnumerator TextEffect(TextMesh text, GameObject obj){
		float alpha = 1;
		while (alpha >= 0) {
			text.color = new Color (text.color.r, text.color.g, text.color.b, alpha);
			alpha -= Time.fixedDeltaTime * alphaSpeed;
			obj.transform.position += new Vector3 (0, speed, 0);
			yield return null; 
		}
		Destroy (obj);
	}
}
