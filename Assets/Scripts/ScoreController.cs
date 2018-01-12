using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	private SpawnController spawnController;
	public string scoreUiText;
	public string roundUiText;
	private Text scoreText;
	private Text roundText;
	public float score;
	void Start () {
		roundText = GameObject.Find ("RoundText").GetComponent<Text> ();
		scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
		spawnController = GameObject.Find ("Main Camera").GetComponent<SpawnController> ();
		RefreshScore ();
		RefreshRound ();
	}
	public void AddScore(float amount){
		score += amount;
		RefreshScore ();
	}
	void RefreshScore(){
		scoreText.text = scoreUiText + score;
	}
	public void RefreshRound(){
		roundText.text = roundUiText + spawnController.rounds;
	}
}
