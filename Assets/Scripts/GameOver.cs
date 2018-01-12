using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour {
	private GameObject sword;
	private GameObject player;
	void Start () {
		gameObject.SetActive (false);
		sword = GameObject.Find ("Sword");
		player = GameObject.Find ("Player");
	}
	public void Retry(){
		Time.timeScale = 1;
		SceneManager.LoadScene (0);
	}
	public void Quit(){
		Application.Quit ();
	}
	public void GameOverScreen(){
		Time.timeScale = 0;
		gameObject.SetActive (true);
		player.SetActive (false);
		sword.SetActive (false);
	}
}
