using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashTimeBar : MonoBehaviour {
	private SwordAttack swordattack;
	private Slider staminaBar;
	void Start () {
		swordattack = GameObject.Find ("Sword").GetComponent<SwordAttack> ();
		staminaBar = GameObject.Find ("DashBar").GetComponent<Slider> ();
		staminaBar.maxValue = swordattack.dashStartCooldown;
		staminaBar.minValue = 0;
	}
	void Update () {
		staminaBar.value = swordattack.dashCooldown;
	}
}
