using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Round : MonoBehaviour {

	public Text roundsText;

	void Update(){
		roundsText.text = PlayerStatus.Rounds.ToString ();
	}

}
