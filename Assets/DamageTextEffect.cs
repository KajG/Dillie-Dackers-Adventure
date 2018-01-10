using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextEffect : MonoBehaviour {
	public float speed;
	public float randomSpawnLimit;
	public float fontSizeScale;
	public int fontSize;
	public Font font;
	void Start () {
		
	}
	
	void Update () {
		
	}
	public void CreateText(float damage, Transform objTrans){
		GameObject obj = new GameObject ();
		TextMesh text = obj.AddComponent<TextMesh> ();
		text.GetComponent<Renderer> ().material = font.material;
		text.text = "-" + damage;
		text.fontSize = fontSize;
		text.transform.localScale = new Vector3(fontSizeScale, fontSizeScale, fontSizeScale);
		text.color = new Color (2, 2, 0);
		text.font = font;
		obj.name = "damageText";
		obj.transform.position = new Vector3(objTrans.position.x + Random.Range(-randomSpawnLimit, randomSpawnLimit), objTrans.position.y + objTrans.GetComponent<BoxCollider2D>().bounds.size.y / 2, objTrans.position.z);
		StartCoroutine (TextEffect (text, obj));
	}
	public IEnumerator TextEffect(TextMesh text, GameObject obj){
		float alpha = 1;
		while (alpha >= 0) {
			text.color = new Color (text.color.r, text.color.g, text.color.b, alpha);
			alpha -= Time.fixedDeltaTime;
			obj.transform.position += new Vector3 (0, speed, 0);
			yield return null; 
		}
		Destroy (obj);
	}
}
