using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static bool GameIsOver;

	private bool checkEndGame;

	public GameObject gameOverUI;

	public Text textEndGame;

	void Start(){
		GameIsOver = false;
		checkEndGame = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameIsOver)
			return;
		
		if(PlayerStatus.Lives <= 0){
			Lose ();
		}

		if (checkEndGame) {
			EndGame ();
		}
	}

	void EndGame(){
		GameIsOver = true;
		gameOverUI.SetActive (true);
	}

	public void Win(){
		Debug.Log ("A");
		if(!checkEndGame){
			Debug.Log ("B");
			checkEndGame = true;
			textEndGame.text = "VICTORY";
		}
	}

	public void Lose(){
		if(!checkEndGame){
			checkEndGame = true;
			textEndGame.text = "GAME OVER";
		}
	}
}
