using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextEffect : MonoBehaviour {
	public TextMesh text;
	public float speed;
	void Start () {
		
	}
	
	void Update () {
		
	}
	public void CreateText(float damage, Transform objTrans){
		float alpha = 1;
		GameObject obj = Instantiate(text, objTrans.position, Quaternion.identity);
		//obj.text = ("-" + damage);
		while (alpha >= 0) {

		}
	}
}
