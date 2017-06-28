using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FetchInput : MonoBehaviour{

	private bool upKey;
	private bool leftKey;
	private bool rightKey;
	private bool downKey;
	private bool spaceKey;
	private int lastKeyPressed;
	public int getLastKey{get{return lastKeyPressed;}}
	public bool getUpKey{get {return upKey;}}
	public bool getLeftKey{get{return leftKey;}}
	public bool getRightKey{get{return rightKey;}}
	public bool getDownKey{get{return downKey;}}
	public bool getSpaceKey{get{return spaceKey;}}

	void Update () {
		if (Input.GetKeyDown (KeyCode.W)) {
			upKey = true;
		} else if(Input.GetKeyUp(KeyCode.W)){
			upKey = false;
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			lastKeyPressed = 2;
			leftKey = true;
		} else if(Input.GetKeyUp(KeyCode.A)){
			leftKey = false;
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			lastKeyPressed = 4;
			rightKey = true;
		} else if(Input.GetKeyUp(KeyCode.D)){
			rightKey = false;
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			downKey = true;
		} else if(Input.GetKeyUp(KeyCode.S)){
			downKey = false;
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			spaceKey = true;
		} else if (Input.GetKeyUp(KeyCode.Space)) {
			spaceKey = false;
		}
	}
}