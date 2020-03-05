using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public Text roundsText;

	void OnEnable(){
		roundsText.text = PlayerStatus.Rounds.ToString ();
	}

	public void Menu(){
		SceneManager.LoadScene (1);
	}
		
}
